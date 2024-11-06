﻿using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;
using Capa_Modelo_CierreContable;
using System.Collections.Generic;


namespace Capa_Controlador_CierreContable
{
    public class Controlador
    {
        sentencias sn = new sentencias();

        // Método para llenar una tabla
        public DataTable llenarTbl(string tabla)
        {

            OdbcDataAdapter dt = sn.llenarTbl(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public int ObtenerPeriodoPorMes(string mes)
        {
            mes = mes.ToUpper(); // Convertir el mes a mayúsculas para la comparación

            switch (mes)
            {
                case "ENERO": return 1;
                case "FEBRERO": return 2;
                case "MARZO": return 3;
                case "ABRIL": return 4;
                case "MAYO": return 5;
                case "JUNIO": return 6;
                case "JULIO": return 7;
                case "AGOSTO": return 8;
                case "SEPTIEMBRE": return 9;
                case "OCTUBRE": return 10;
                case "NOVIEMBRE": return 11;
                case "DICIEMBRE": return 12;
                default: return 0; // En caso de mes inválido
            }
        }

        public DataTable ObtenerMesesSinDatos(int ultimoMesConEstadoCero, HashSet<int> idsCuentas)
        {
            DataTable mesesValidos = new DataTable();
            mesesValidos.Columns.Add("Mes"); // Columna para el nombre del mes

            using (OdbcConnection con = sn.ObtenerConexion())
            {
                // Obtener los meses con estado = 1 que sean mayores al último mes con estado = 0
                string query = "SELECT DISTINCT mes FROM tbl_historico_cuentas WHERE mes > ? AND estado = 1 ORDER BY mes";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.Parameters.AddWithValue("?", ultimoMesConEstadoCero);

                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mes = reader.GetInt32(0);
                        DataRow row = mesesValidos.NewRow();
                        row["Mes"] = new DateTime(2024, mes, 1).ToString("MMMM"); // Ajusta el año según sea necesario
                        mesesValidos.Rows.Add(row);
                        break; // Solo queremos el primer mes válido
                    }
                }
            }

            return mesesValidos;
        }






        public DataTable ObtenerCuentas()
        {

            DataTable cuentas = new DataTable();
            try
            {
                string sQuery = "SELECT pk_id_cuenta, nombre_cuenta FROM tbl_cuentas"; // Ajusta la consulta según tu tabla
                using (OdbcConnection con = sn.ObtenerConexion())
                {
                    OdbcDataAdapter adapter = new OdbcDataAdapter(sQuery, con);
                    adapter.Fill(cuentas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener cuentas: {ex.Message}");
            }

            return cuentas;
        }

        public void ConsultarCierreG(string sCuentaSeleccionada, TextBox txt_cargomes, TextBox txt_abonomes, TextBox txt_saldoantmes, TextBox txt_saldoactmes)
        {
            // Consulta para traer las sumas de cargo_mes, abono_mes, saldo_ant y saldo_act
            string sQuery = "SELECT COALESCE(SUM(cargo_mes), 0) AS SumaCargoMes, " +
                           "COALESCE(SUM(abono_mes), 0) AS SumaAbonoMes, " +
                           "COALESCE(SUM(saldo_ant), 0) AS SumaSaldoAnt, " +
                           "COALESCE(SUM(saldo_act), 0) AS SumaSaldoAct " +
                           "FROM tbl_cuentas " +
                           "WHERE nombre_cuenta = ?";

            using (OdbcConnection con = sn.ObtenerConexion())
            {
                try
                {

                    using (OdbcCommand cmd = new OdbcCommand(sQuery, con))
                    {
                        // Asignar el parámetro de cuenta seleccionada
                        cmd.Parameters.AddWithValue("?", sCuentaSeleccionada);

                        using (OdbcDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar valores sumados a los TextBox
                                // Asignar valores formateados a dos decimales a los TextBox
                                txt_cargomes.Text = reader["SumaCargoMes"] != DBNull.Value ? Convert.ToDecimal(reader["SumaCargoMes"]).ToString("F2") : "0.00";
                                txt_abonomes.Text = reader["SumaAbonoMes"] != DBNull.Value ? Convert.ToDecimal(reader["SumaAbonoMes"]).ToString("F2") : "0.00";
                                txt_saldoantmes.Text = reader["SumaSaldoAnt"] != DBNull.Value ? Convert.ToDecimal(reader["SumaSaldoAnt"]).ToString("F2") : "0.00";
                                txt_saldoactmes.Text = reader["SumaSaldoAct"] != DBNull.Value ? Convert.ToDecimal(reader["SumaSaldoAct"]).ToString("F2") : "0.00";

                            }
                            else
                            {
                                // Limpiar TextBox si no hay resultados
                                txt_cargomes.Clear();
                                txt_abonomes.Clear();
                                txt_saldoantmes.Clear();
                                txt_saldoactmes.Clear();
                                MessageBox.Show("No se encontraron datos para la cuenta especificada.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta: " + ex.Message);
                }
            }
        }

        public void GenerarNuevoCierre(int mes, int anio)
        {
            using (OdbcConnection con = sn.ObtenerConexion())
            {
                using (OdbcTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Seleccionar todos los IDs de cuentas
                        string sSelectQuery = "SELECT Pk_id_cuenta, cargo_mes, abono_mes, saldo_ant, saldo_act, cargo_acumulado, abono_acumulado FROM tbl_cuentas";
                        OdbcCommand selectCmd = new OdbcCommand(sSelectQuery, con, transaction);

                        using (OdbcDataReader reader = selectCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int cuentaId = reader.GetInt32(0);
                                decimal cargoMes = reader.GetDecimal(1);
                                decimal abonoMes = reader.GetDecimal(2);
                                decimal saldoAnt = reader.GetDecimal(3);
                                decimal saldoAct = reader.GetDecimal(4);
                                decimal cargoAcumulado = reader.GetDecimal(5);
                                decimal abonoAcumulado = reader.GetDecimal(6);

                                // Copiar el saldo_act a saldo_ant en tbl_cuentas
                                string sUpdateCuentasQuery = @"
                        UPDATE tbl_cuentas
                        SET 
                            saldo_ant = saldo_act, 
                            cargo_acumulado = cargo_acumulado + ?, 
                            abono_acumulado = abono_acumulado + ?, 
                            cargo_mes = 0, 
                            abono_mes = 0, 
                            saldo_act = 0
                        WHERE Pk_id_cuenta = ?";

                                using (OdbcCommand updateCuentasCmd = new OdbcCommand(sUpdateCuentasQuery, con, transaction))
                                {
                                    updateCuentasCmd.Parameters.AddWithValue("?", cargoMes);
                                    updateCuentasCmd.Parameters.AddWithValue("?", abonoMes);
                                    updateCuentasCmd.Parameters.AddWithValue("?", cuentaId);
                                    updateCuentasCmd.ExecuteNonQuery();
                                }

                                // Obtener el saldoanual del mes anterior, si existe
                                decimal deSaldoAnualPrevio = 0;
                                string sSaldoAnualQuery = "SELECT saldoanual FROM tbl_historico_cuentas WHERE Pk_id_cuenta = ? AND mes = ? AND anio = ?";
                                using (OdbcCommand saldoAnualCmd = new OdbcCommand(sSaldoAnualQuery, con, transaction))
                                {
                                    saldoAnualCmd.Parameters.AddWithValue("?", cuentaId);
                                    saldoAnualCmd.Parameters.AddWithValue("?", mes - 1); // Mes anterior
                                    saldoAnualCmd.Parameters.AddWithValue("?", anio);

                                    object result = saldoAnualCmd.ExecuteScalar();
                                    if (result != null)
                                    {
                                        deSaldoAnualPrevio = Convert.ToDecimal(result);
                                    }
                                }

                                // Sumar el saldo_act actual al saldoanual del mes anterior
                                decimal nuevoSaldoAnual = deSaldoAnualPrevio + saldoAct;

                                // Query para actualizar el registro en tbl_historico_cuentas
                                string sUpdateQuery = @"
    UPDATE tbl_historico_cuentas 
    SET 
        saldo_ant = saldo_act, 
        cargo_acumulado = cargo_acumulado + ?, 
        abono_acumulado = abono_acumulado + ?, 
        saldoanual = saldoanual + (cargo_acumulado + ?) - (abono_acumulado + ?), 
        estado = 0
    WHERE 
        Pk_id_cuenta = ? AND mes = ? AND anio = ?";

                                using (OdbcCommand updateCmd = new OdbcCommand(sUpdateQuery, con, transaction))
                                {
                                    // Asignamos los parámetros para cargo_mes, abono_mes, y otros valores
                                    updateCmd.Parameters.AddWithValue("?", cargoMes); // Para sumar al cargo_acumulado
                                    updateCmd.Parameters.AddWithValue("?", abonoMes); // Para sumar al abono_acumulado
                                    updateCmd.Parameters.AddWithValue("?", cargoMes); // Para la resta en saldo_anual (parte del cargo)
                                    updateCmd.Parameters.AddWithValue("?", abonoMes); // Para la resta en saldo_anual (parte del abono)
                                    updateCmd.Parameters.AddWithValue("?", cuentaId); // Para identificar el registro correcto
                                    updateCmd.Parameters.AddWithValue("?", mes);      // Para identificar el mes
                                    updateCmd.Parameters.AddWithValue("?", anio);     // Para identificar el año

                                    updateCmd.ExecuteNonQuery(); // Ejecuta el UPDATE
                                }


                                // Actualizar el estado a 0 en tbl_historico_cuentas
                                string sUpdateHistoricoQuery = "UPDATE tbl_historico_cuentas SET estado = 0 WHERE Pk_id_cuenta = ? AND mes = ? AND anio = ?";
                                using (OdbcCommand updateHistoricoCmd = new OdbcCommand(sUpdateHistoricoQuery, con, transaction))
                                {
                                    updateHistoricoCmd.Parameters.AddWithValue("?", cuentaId);
                                    updateHistoricoCmd.Parameters.AddWithValue("?", mes);
                                    updateHistoricoCmd.Parameters.AddWithValue("?", anio);
                                    updateHistoricoCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                        MessageBox.Show("Cierre mensual guardado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        // Revertir cambios en caso de error
                        transaction.Rollback();
                        MessageBox.Show($"Error al guardar el cierre: {ex.Message}");
                    }
                }
            }
        }


        public void VerificarYActualizarAnoCompleto(int anio)
        {
            using (OdbcConnection con = sn.ObtenerConexion())
            {
                string sQuery = "SELECT COUNT(DISTINCT mes) FROM tbl_historico_cuentas WHERE anio = ?";
                OdbcCommand cmd = new OdbcCommand(sQuery, con);
                cmd.Parameters.AddWithValue("?", anio);

                int mesesConCierre = Convert.ToInt32(cmd.ExecuteScalar());

                // Verificar si ya se completaron los 12 meses
                if (mesesConCierre == 12)
                {
                    int nuevoAnio = anio + 1;
                    MessageBox.Show($"Año actualizado a {nuevoAnio}.");
                    ActualizarSaldoAntYResetearCuentas(nuevoAnio); // Llamar a la función del paso 2 con el nuevo año
                }
            }
        }

        public void ActualizarSaldoAntYResetearCuentas(int anio)
        {
            using (OdbcConnection con = sn.ObtenerConexion())
            {
                using (OdbcTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Actualizar saldo_ant en tbl_cuentas con saldoanual de tbl_historico_cuentas
                        string sUpdateSaldoAntQuery = @"
                    UPDATE tbl_cuentas c
                    JOIN tbl_historico_cuentas h ON c.Pk_id_cuenta = h.Pk_id_cuenta
                    SET c.saldo_ant = h.saldoanual
                    WHERE h.mes = 12 AND h.anio = ?";

                        OdbcCommand updateSaldoAntCmd = new OdbcCommand(sUpdateSaldoAntQuery, con, transaction);
                        updateSaldoAntCmd.Parameters.AddWithValue("?", anio - 1);
                        updateSaldoAntCmd.ExecuteNonQuery();

                        // Reiniciar los valores de columnas flotantes en tbl_cuentas a 0
                        string sResetCuentasQuery = @"
                    UPDATE tbl_cuentas
                    SET 
                        cargo_mes = 0, 
                        abono_mes = 0, 
                        saldo_act = 0, 
                        cargo_acumulado = 0, 
                        abono_acumulado = 0";

                        OdbcCommand resetCuentasCmd = new OdbcCommand(sResetCuentasQuery, con, transaction);
                        resetCuentasCmd.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Saldo anual transferido y valores reiniciados para el nuevo año.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error al actualizar el saldo y reiniciar cuentas: {ex.Message}");
                    }
                }
            }
        }








        // Método para actualizar el ComboBox de meses, asegurando que el último mes no aparezca


        // Método para actualizar el ComboBox de meses, asegurando que el último mes no aparezca
        // Método para actualizar la lista de meses, asegurando que el último mes no aparezca
        public void ActualizarComboBoxMeses()
        {
            using (OdbcConnection con = sn.ObtenerConexion())
            {
                string sQuery = "SELECT DISTINCT mes FROM tbl_historico_cuentas";
                OdbcCommand cmd = new OdbcCommand(sQuery, con);
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    // Clear the list of months and repopulate it, excluding the last entered month
                    List<string> meses = new List<string>();
                    List<int> mesesExistentes = new List<int>();

                    while (reader.Read())
                    {
                        mesesExistentes.Add(reader.GetInt32(0));
                    }

                    // Add months to the list, skipping the last entered month
                    for (int i = 1; i <= 12; i++)
                    {
                        if (!mesesExistentes.Contains(i))
                        {
                            meses.Add(i.ToString()); // Convertir a string y agregar a la lista
                        }
                    }
                }
            }
        }



        public DataTable ObtenerDatosCierre(string sNombreCuenta)
        {
            DataTable datosCierre = new DataTable();
            try
            {
                // Ajustar la consulta para obtener los datos necesarios
                string sQuery;

                if (string.IsNullOrEmpty(sNombreCuenta)) // Si nombreCuenta es null o vacío, selecciona todas las cuentas
                {
                    sQuery = @"SELECT c.Pk_id_cuenta, 
                     tc.nombre_tipocuenta AS nombre_tipo_cuenta, 
                     ec.nombre_tipocuenta AS nombre_encabezado, 
                     c.nombre_cuenta, 
                     c.cargo_mes, 
                     c.abono_mes, 
                     c.saldo_ant, 
                     c.saldo_act, 
                     c.cargo_acumulado, 
                     c.abono_acumulado 
              FROM tbl_cuentas c
              JOIN tbl_tipocuenta tc ON c.Pk_id_tipocuenta = tc.Pk_id_tipocuenta
              JOIN tbl_encabezadoclasecuenta ec ON c.Pk_id_encabezadocuenta = ec.Pk_id_encabezadocuenta"; // Obtener todas las cuentas
                }
                else
                {
                    sQuery = @"SELECT c.Pk_id_cuenta, 
                     tc.nombre_tipocuenta AS nombre_tipo_cuenta, 
                     ec.nombre_tipocuenta AS nombre_encabezado, 
                     c.nombre_cuenta, 
                     c.cargo_mes, 
                     c.abono_mes, 
                     c.saldo_ant, 
                     c.saldo_act, 
                     c.cargo_acumulado, 
                     c.abono_acumulado 
              FROM tbl_cuentas c
              JOIN tbl_tipocuenta tc ON c.Pk_id_tipocuenta = tc.Pk_id_tipocuenta
              JOIN tbl_encabezadoclasecuenta ec ON c.Pk_id_encabezadocuenta = ec.Pk_id_encabezadocuenta
              WHERE c.nombre_cuenta = ?"; // Filtrar por cuenta seleccionada
                }


                using (OdbcConnection con = sn.ObtenerConexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand(sQuery, con))
                    {
                        if (!string.IsNullOrEmpty(sNombreCuenta))
                        {
                            cmd.Parameters.AddWithValue("nombre_cuenta", sNombreCuenta); // Asignar el valor del parámetro
                        }

                        OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                        adapter.Fill(datosCierre);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de cierre: {ex.Message}");
            }

            return datosCierre;
        }


        public int ObtenerUltimoMesConEstadoCero(int anio)
        {
            int ultimoMes = 1; // Por defecto se asigna enero (mes 1)

            using (OdbcConnection con = sn.ObtenerConexion())
            {
                // Consulta para obtener el último mes donde estado = 0 en el año especificado
                string query = "SELECT MAX(mes) FROM tbl_historico_cuentas WHERE anio = ? AND estado = 0";
                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.Parameters.AddWithValue("?", anio);

                var resultado = cmd.ExecuteScalar();
                if (resultado != DBNull.Value)
                {
                    ultimoMes = Convert.ToInt32(resultado);
                }
            }

            return ultimoMes;
        }



        public bool VerificarCierresCompletos(int anio)
        {
            string sQuery = @"
                SELECT COUNT(DISTINCT Mes) AS MesesRegistrados
                FROM tbl_historico_cuentas
                WHERE Anio = ?";

            using (OdbcConnection conn = sn.ObtenerConexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(sQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", anio);
                    int mesesRegistrados = Convert.ToInt32(cmd.ExecuteScalar());

                    // Verificar si existen registros para todos los meses (1 a 12)
                    return mesesRegistrados == 12;
                }
            }
        }





        // Método para actualizar el año en la tabla `tbl_historico_cuentas`
        public void ActualizarAnioHistorico(int anioActual, int nuevoAnio)
        {
            string sQueryActualizarSaldoAnt = @"
                UPDATE tbl_cuentas c
                INNER JOIN tbl_historico_cuentas h ON c.Pk_id_cuenta = h.Pk_id_cuenta
                SET c.saldo_ant = h.saldoanual
                WHERE h.Anio = ? AND h.Mes = 12";

            string sQueryReiniciarSaldos = @"
                UPDATE tbl_cuentas
                SET cargo_mes = 0, abono_mes = 0, saldo_act = 0, 
                    cargo_acumulado = 0, abono_acumulado = 0";

            using (OdbcConnection conn = sn.ObtenerConexion())
            {
                // Ejecutar la primera consulta para actualizar saldo_ant
                using (OdbcCommand cmd1 = new OdbcCommand(sQueryActualizarSaldoAnt, conn))
                {
                    cmd1.Parameters.AddWithValue("?", anioActual);
                    cmd1.ExecuteNonQuery();
                }

                // Ejecutar la segunda consulta para reiniciar saldos
                using (OdbcCommand cmd2 = new OdbcCommand(sQueryReiniciarSaldos, conn))
                {
                    cmd2.ExecuteNonQuery();
                }
            }
        }



        // Modifica el método ActualizarSumasSaldos para incluir la cuenta
        public void ActualizarSumasSaldos(TextBox txt_saldoant, TextBox txt_saldofinal, int periodo, string sCuenta)
        {
            try
            {
                // Llama a ObtenerSumasSaldos pasando periodo y cuenta
                (decimal sumaSaldoAnt, decimal sumaSaldoAct) = sn.ObtenerSumasSaldos(periodo, sCuenta);

                txt_saldoant.Text = sumaSaldoAnt.ToString("N2");
                txt_saldofinal.Text = sumaSaldoAct.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener sumas de saldos: {ex.Message}");
            }
        }



        public string MRuta(string Ruta1)
        {
            string ruta = sn.modRuta(Ruta1);

            return ruta;
        }

        public string MIndice(string Indice1)
        {
            string indice = sn.modIndice(Indice1);

            return indice;
        }

        public bool VerificarRegistrosVacios(string sMes, string sAnio)
        {
            // Obtener el periodo correspondiente al mes
            int periodo = ObtenerPeriodoPorMes(sMes);
            if (periodo < 1 || periodo > 12) // Si el mes no es válido, retorna false
            {
                MessageBox.Show("Mes inválido.");
                return false;
            }

            // Obtener todas las cuentas
            DataTable cuentas = ObtenerCuentas();

            // Recorrer cada cuenta y verificar si hay registros para el mes y año especificados
            foreach (DataRow cuenta in cuentas.Rows)
            {
                string nombreCuenta = cuenta["nombre_cuenta"].ToString();

                // Consulta para verificar si hay registros para el mes y año con un JOIN
                string query = @"
            SELECT COUNT(*) 
            FROM tbl_historico_cuentas hc
            INNER JOIN tbl_cuentas c ON hc.Pk_id_cuenta = c.Pk_id_cuenta
            WHERE c.nombre_cuenta = ? AND hc.mes = ? AND hc.anio = ?";

                using (OdbcConnection con = sn.ObtenerConexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", nombreCuenta);
                        cmd.Parameters.AddWithValue("?", periodo);
                        cmd.Parameters.AddWithValue("?", sAnio);

                        int registros = Convert.ToInt32(cmd.ExecuteScalar());

                        // Si no hay registros para este mes, retorna false
                        if (registros == 0)
                        {
                            MessageBox.Show($"No existe cierre para la cuenta '{nombreCuenta}' en el mes {sMes} del año {sAnio}.");
                            return false;
                        }
                    }
                }
            }

            // Si todas las cuentas tienen registros, retorna true
            return true;
        }

        public void ConsultaCG(int periodo, string sAnio, string sCuenta, DataTable dt1, DataTable dt2)
        {
            // Define la consulta SQL con LEFT JOIN y filtros de mes, año, y cuenta si es necesario
            string sConsulta = @"
        SELECT 
            c.Pk_id_cuenta AS 'ID de Cuenta', 
            c.nombre_cuenta AS 'Nombre de Cuenta', 
            h.mes AS 'Mes', 
            h.anio AS 'Anio', 
            e.nombre_tipocuenta AS 'Encabezado Cuenta', 
            t.nombre_tipocuenta AS 'Tipo de Cuenta', 
            h.cargo_mes AS 'Cargo del Mes', 
            h.abono_mes AS 'Abono del Mes', 
            h.saldo_ant AS 'Saldo Anterior', 
            h.saldo_act AS 'Saldo Actual', 
            h.cargo_acumulado AS 'Cargo Acumulado', 
            h.abono_acumulado AS 'Abono Acumulado', 
            h.saldoanual AS 'Saldo Anual'
        FROM 
            tbl_cuentas AS c
        LEFT JOIN 
            tbl_historico_cuentas AS h ON c.Pk_id_cuenta = h.Pk_id_cuenta
        LEFT JOIN 
            tbl_encabezadoclasecuenta AS e ON c.Pk_id_encabezadocuenta = e.Pk_id_encabezadocuenta
        LEFT JOIN 
            tbl_tipocuenta AS t ON c.Pk_id_tipocuenta = t.PK_id_tipocuenta
        WHERE 
            (h.mes = ? AND h.anio = ?) 
            AND (c.nombre_cuenta = ? OR ? IS NULL)
            OR h.Pk_id_cuenta IS NULL";

            using (OdbcConnection con = sn.ObtenerConexion())
            {
                // Crea un adaptador con la consulta
                OdbcDataAdapter datos = new OdbcDataAdapter(sConsulta, con);

                // Añade los parámetros de mes y año
                datos.SelectCommand.Parameters.AddWithValue("?", periodo);
                datos.SelectCommand.Parameters.AddWithValue("?", sAnio);

                // Añade el parámetro de cuenta si es necesario
                if (!string.IsNullOrEmpty(sCuenta))
                {
                    datos.SelectCommand.Parameters.AddWithValue("?", sCuenta);
                    datos.SelectCommand.Parameters.AddWithValue("?", sCuenta);
                }
                else
                {
                    datos.SelectCommand.Parameters.AddWithValue("?", DBNull.Value);
                    datos.SelectCommand.Parameters.AddWithValue("?", DBNull.Value);
                }

                // Llena ambos DataTables con la misma consulta (si es necesario, se pueden dividir más adelante)
                datos.Fill(dt1);
                datos.Fill(dt2);
            }
        }




    }
}
