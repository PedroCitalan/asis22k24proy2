using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;
using Capa_Modelo_AmmyCatun;
using CrystalDecisions.CrystalReports.ViewerObjectModel;

namespace Capa_Modelo_AmmyCatun
{

    public class Sentencias
    {
        private string sTabla_datos_pedido = "Tbl_datos_pedido";
        private string sTabla_Vehiculos = "Tbl_vehiculos";
        private Conexion cn = new Conexion();

        // Método para Registrar-Ingresar Pedidos Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void registrarPedido(DateTime fechaEmision, DateTime fechaTraslado, string direccionPartida, string direccionLlegada, string numeroOrdenRecojo, string formaPago, string destino, int idRemitente, int idDestinatario, int idvehiculo)
        {
            try
            {
                string sSql = "INSERT INTO " + sTabla_datos_pedido + " (fechaEmision, fechaTraslado, direccionPartida, direccionLlegada, numeroOrdenRecojo, formaPago, destino, fk_id_Remitente, fk_id_Destinatario, fk_id_vehiculo) " +
                              "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@fechaEmision", fechaEmision);
                    cmd.Parameters.AddWithValue("@fechaTraslado", fechaTraslado);
                    cmd.Parameters.AddWithValue("@direccionPartida", direccionPartida);
                    cmd.Parameters.AddWithValue("@direccionLlegada", direccionLlegada);
                    cmd.Parameters.AddWithValue("@numeroOrdenRecojo", numeroOrdenRecojo);
                    cmd.Parameters.AddWithValue("@formaPago", formaPago);
                    cmd.Parameters.AddWithValue("@destino", destino);
                    cmd.Parameters.AddWithValue("@fk_id_Remitente", idRemitente);
                    cmd.Parameters.AddWithValue("@fk_id_Destinatario", idDestinatario);
                    cmd.Parameters.AddWithValue("@fk_id_vehiculo", idvehiculo);

                    int ingreso = cmd.ExecuteNonQuery();
                    MessageBox.Show(ingreso > 0 ? "Pedido registrado correctamente." : "No se pudo registrar el pedido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo guardar el registro en la tabla Tbl_datos_pedido.");
            }
        }

        public int getMaxIdPedido()
        {
            int iIdRegistro = 0;
            string sSql = "SELECT max(Pk_id_guia) FROM Tbl_datos_pedido ;";
            try
            {
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    iIdRegistro = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo obtener el id del registro en la tabla Tbl_pedidos.");
            }
            return iIdRegistro;
        }
        public DataTable cargarPedidos()
        {
            DataTable dtPedidos = new DataTable();
            string sSql = "SELECT * FROM Tbl_datos_pedido";

            try
            {
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    da.Fill(dtPedidos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo obtener los datos de la tabla Tbl_datos_pedido.");
            }

            return dtPedidos;
        }

        // Método para Modifcar Pedidos Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void modificarPedido(int idGuia, DateTime fechaEmision, DateTime fechaTraslado, string direccionPartida, string direccionLlegada, string numeroOrdenRecojo, string formaPago, string destino, int idRemitente, int idDestinatario, int idVehiculo)
        {
            try
            {
                string sSql = "UPDATE Tbl_datos_pedido SET fechaEmision = ?, fechaTraslado = ?, direccionPartida = ?, direccionLlegada = ?, numeroOrdenRecojo = ?, formaPago = ?, destino = ?, Fk_id_remitente = ?, Fk_id_destinatario = ?, Fk_id_vehiculo = ? WHERE Pk_id_guia = ?;";

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@fechaEmision", fechaEmision.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fechaTraslado", fechaTraslado.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@direccionPartida", direccionPartida);
                    cmd.Parameters.AddWithValue("@direccionLlegada", direccionLlegada);
                    cmd.Parameters.AddWithValue("@numeroOrdenRecojo", numeroOrdenRecojo);
                    cmd.Parameters.AddWithValue("@formaPago", formaPago);
                    cmd.Parameters.AddWithValue("@destino", destino);
                    cmd.Parameters.AddWithValue("@Fk_id_remitente", idRemitente);
                    cmd.Parameters.AddWithValue("@Fk_id_destinatario", idDestinatario);
                    cmd.Parameters.AddWithValue("@Fk_id_vehiculo", idVehiculo);
                    cmd.Parameters.AddWithValue("@Pk_id_guia", idGuia);

                    int resultado = cmd.ExecuteNonQuery();
                    MessageBox.Show(resultado > 0 ? "Pedido modificado correctamente." : "No se encontró el pedido para modificar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo modificar el registro en la tabla Tbl_datos_pedido.");
            }

        }
        // Método para Registrar-Ingresar Vehiculos Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void registrarVehiculo(string numeroPlaca, string marca, string color, string descripcion, string horaLlegada, string horaSalida, double pesoTotal, int idChofer)
        {
            try
            {
                string sSql = "INSERT INTO " + sTabla_Vehiculos + "(numeroPlaca, marca, color, descripcion, horaLlegada, horaSalida, pesoTotal, Fk_id_chofer)" +
                              "VALUES (?, ?, ?, ?, ?, ?, ?, ?);";

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@numeroPlaca", numeroPlaca);
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@horaLlegada", horaLlegada);
                    cmd.Parameters.AddWithValue("@horaSalida", horaSalida);
                    cmd.Parameters.AddWithValue("@pesoTotal", pesoTotal);
                    cmd.Parameters.AddWithValue("@Fk_id_chofer", idChofer);


                    int ingreso = cmd.ExecuteNonQuery();
                    MessageBox.Show(ingreso > 0 ? "Vehículo registrado correctamente." : "No se pudo registrar el vehículo.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo guardar el registro en la tabla Tbl_vehiculos.");
            }
        }
        public int getMaxIdVehiculo()
        {
            int iIdRegistro = 0;
            string sSql = "SELECT max(Pk_id_vehiculo) FROM " + sTabla_Vehiculos + ";";
            try
            {
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    iIdRegistro = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo obtener el id del registro en la tabla " + sTabla_Vehiculos);
            }
            return iIdRegistro;
        }


        public DataTable cargarVehiculos()
        {
            DataTable dtVehiculos = new DataTable();
            string sSql = "SELECT * FROM Tbl_vehiculos";

            try
            {
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    da.Fill(dtVehiculos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo obtener los datos de la tabla Tbl_vehiculos.");
            }

            return dtVehiculos;
        }
        // Método para Modificar Vehiculos Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void modificarVehiculo(int idVehiculo, string numeroPlaca, string marca, string color, string descripcion, string horaLlegada, string horaSalida, double pesoTotal, int idChofer)
        {
            try
            {
                string sSql = "UPDATE Tbl_vehiculos SET numeroPlaca = ?, marca = ?, color = ?, descripcion = ?, horaLlegada = ?, horaSalida = ?, pesoTotal = ?, Fk_id_chofer = ? WHERE Pk_id_vehiculo = ?;";

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@numeroPlaca", numeroPlaca);
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@horaLlegada", horaLlegada);
                    cmd.Parameters.AddWithValue("@horaSalida", horaSalida);
                    cmd.Parameters.AddWithValue("@pesoTotal", pesoTotal);
                    cmd.Parameters.AddWithValue("@Fk_id_chofer", idChofer);
                    cmd.Parameters.AddWithValue("@Fk_id_vehiculo", idVehiculo);


                    int ingreso = cmd.ExecuteNonQuery();
                    MessageBox.Show(ingreso > 0 ? "Vehículo modificado correctamente." : "No se encontró el vehículo para modificar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo modificar el registro en la tabla Tbl_vehiculos.");
            }
        }

        // Método para Eliminar Vehiculo Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void eliminarVehiculo(string idVehiculo)
        {
            try
            {
                string sSql = "DELETE FROM " + sTabla_Vehiculos + " WHERE Pk_id_vehiculo = ?;";
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                    int resultado = cmd.ExecuteNonQuery();
                    MessageBox.Show(resultado > 0 ? "Vehículo eliminado correctamente." : "No se encontró el vehículo para eliminar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo eliminar el registro en la tabla Vehiculos.");
            }
        }
        // Método para Eliminar Pedido Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void eliminarPedido(string idGuia)
        {
            try
            {
                string sSql = "DELETE FROM " + sTabla_datos_pedido + " WHERE Pk_id_guia= ?;";
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@idGuia",idGuia);
                    int resultado = cmd.ExecuteNonQuery();
                    MessageBox.Show(resultado > 0 ? "Pedido eliminado correctamente." : "No se encontró el pedido para eliminar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo eliminar el registro en la tabla pedido.");
            }
        }
        // Método para modificar Pedido Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void modificarPedido(DateTime fechaEmision, DateTime fechaTraslado, string direccionPartida, string direccionLlegada, string numeroOrdenRecojo, string formaPago, string destino, int idRemitente, int idDestinatario, int idvehiculo, int idGuia)
        {
            try
            {
                string sSql = "UPDATE Tbl_datos_pedido SET fechaEmision = ?, fechaTraslado = ?, direccionPartida = ?, direccionLlegada = ?, numeroOrdenRecojo = ?, formaPago = ?, destino = ?,  fk_id_Remitente = ?, fk_id_Destinatario = ?, fk_id_vehiculo = ? WHERE Pk_id_guia;"; 
                              

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@fechaEmision", fechaEmision);
                    cmd.Parameters.AddWithValue("@fechaTraslado", fechaTraslado);
                    cmd.Parameters.AddWithValue("@direccionPartida", direccionPartida);
                    cmd.Parameters.AddWithValue("@direccionLlegada", direccionLlegada);
                    cmd.Parameters.AddWithValue("@numeroOrdenRecojo", numeroOrdenRecojo);
                    cmd.Parameters.AddWithValue("@formaPago", formaPago);
                    cmd.Parameters.AddWithValue("@destino", destino);
                    cmd.Parameters.AddWithValue("@fk_id_Remitente", idRemitente);
                    cmd.Parameters.AddWithValue("@fk_id_Destinatario", idDestinatario);
                    cmd.Parameters.AddWithValue("@fk_id_vehiculo", idvehiculo);
                    cmd.Parameters.AddWithValue("@Pk_id_guia", idGuia);

                    int ingreso = cmd.ExecuteNonQuery();
                    MessageBox.Show(ingreso > 0 ? "Pedido registrado correctamente." : "No se pudo registrar el pedido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo guardar el registro en la tabla Tbl_datos_pedido.");
            }
        }
        // Método para agregar el boton de ayuda realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public string modRuta(string idAyuda)
        {
            string sRuta = "";
            string sSql = "SELECT Ruta FROM ayuda WHERE Id_ayuda = ?"; // Parámetro seguro

            using (OdbcCommand command = new OdbcCommand(sSql, cn.conexion()))
            {
                command.Parameters.AddWithValue("id_ayuda", idAyuda);
                using (OdbcDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sRuta = reader.GetString(0); // Asignamos el valor de la columna Ruta
                    }
                }
            }

            return sRuta;
        }

        public string modIndice(string idAyuda)
        {
            string sIndice = "";
            string sSql = "SELECT indice FROM ayuda WHERE id_ayuda = ?"; // Parámetro seguro

            using (OdbcCommand command = new OdbcCommand(sSql, cn.conexion()))
            {
                command.Parameters.AddWithValue("Id_ayuda", idAyuda);
                using (OdbcDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sIndice = reader.GetString(0); // Asignamos el valor de la columna Indice
                    }
                }
            }

            return sIndice;
        }

    }
}

 











