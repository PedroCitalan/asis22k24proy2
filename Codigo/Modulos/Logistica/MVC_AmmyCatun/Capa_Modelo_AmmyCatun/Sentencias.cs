using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;
using Capa_Modelo_AmmyCatun;

namespace Capa_Modelo_AmmyCatun
{

    public class Sentencias
    {
        private string sTabla_chofer = "Tbl_chofer";
        private string sTabla_vehiculos = "Tbl_vehiculos";
        private string sTabla_datos_pedido = "Tbl_datos_pedido";
        private Conexion cn = new Conexion();

        // Método de ingreso de chofer
        public void registrarChofer(string id_chofer, string nombreEmp, string numeroIdent, string nombre, string licencia, string telefono, string direccion)
        {
            try
            {
                string sSql = "INSERT INTO " + sTabla_chofer + " (Pk_id_chofer, nombreEmpresa, numeroIdentificacion, nombre, licencia, telefono, direccion) " +
                              "VALUES (?, ?, ?, ?, ?, ?, ?);";
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@id_chofer", id_chofer);
                    cmd.Parameters.AddWithValue("@nombreEmp", nombreEmp);
                    cmd.Parameters.AddWithValue("@numeroIdent", numeroIdent);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@licencia", licencia);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);

                    int ingreso = cmd.ExecuteNonQuery();
                    MessageBox.Show(ingreso > 0 ? "Datos Ingresados Correctamente" : "Datos No Ingresados Correctamente");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo guardar el registro en la tabla " + sTabla_chofer);
            }
        }

        public int getMaxIdChofer()
        {
            int iIdRegistro = 0;
            string sSql = "SELECT max(Pk_id_chofer) FROM " + sTabla_chofer + ";";
            try
            {
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    iIdRegistro = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo obtener el id del registro en la tabla " + sTabla_chofer);
            }
            return iIdRegistro;
        }

        // Método para eliminar chofer
        public void eliminarChofer(string idChofer)
        {
            try
            {
                string sSql = "DELETE FROM " + sTabla_chofer + " WHERE Pk_id_chofer = ?;";
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@idChofer", idChofer);
                    int resultado = cmd.ExecuteNonQuery();
                    MessageBox.Show(resultado > 0 ? "Chofer eliminado correctamente." : "No se encontró el chofer para eliminar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo eliminar el registro en la tabla " + sTabla_chofer);
            }
        }

        public void registrarVehiculo(string numeroPlaca, string marca, string color, string descripcion, string horaLlegada, string horaSalida, double pesoTotal, int idChofer)
        {
            try
            {
                string sSql = "INSERT INTO Tbl_vehiculos (numeroPlaca, marca, color, descripcion, horaLlegada, horaSalida, pesoTotal, Fk_id_chofer) " +
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


        // Método de modificar chofer
        public void modificarChofer(string id, string nombreEmp, string numeroIdent, string nombre, string licencia, string telefono, string direccion)
        {
            try
            {
                // SQL statement to update the driver's details
                string sSql = "UPDATE " + sTabla_chofer + " SET nombreEmpresa = ?, numeroIdentificacion = ?, nombre = ?, licencia = ?, telefono = ?, direccion = ? WHERE Pk_id_chofer = ?;";

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    // Add parameters to the command
                    cmd.Parameters.AddWithValue("@nombreEmp", nombreEmp);
                    cmd.Parameters.AddWithValue("@numeroIdent", numeroIdent);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@licencia", licencia);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@pk_id_chofer", id);

                    // Execute the update command
                    int resultado = cmd.ExecuteNonQuery();

                    // Show a message based on the result
                    MessageBox.Show(resultado > 0 ? "Chofer modificado correctamente." : "No se encontró el chofer para modificar.");
                }
            }
            catch (Exception ex)
            {
                // Log the error message
                Console.WriteLine(ex.Message + " \nNo se pudo modificar el registro en la tabla " + sTabla_chofer);
            }
        }

        public void registrarPedido(DateTime fechaEmision, DateTime fechaTraslado, string direccionPartida, string direccionLlegada, string numeroOrdenRecojo, string formaPago, string destino, int idRemitente, int idDestinatario, int idvehiculo)
        {
            try
            {
                string sSql = "INSERT INTO " + sTabla_datos_pedido + " (fechaEmision, fechaTraslado, direccionPartida, direccionLlegada, numeroOrdenRecojo, formaPago, destino, fk_id_Remitente, fk_id_Destinatario, fk_id_vehiculo) " +
                              "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    _ = cmd.Parameters.AddWithValue("@fechaEmision", fechaEmision);
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

        public void registrarRemitente(string nombre, string numeroIdentificacion, string telefono, string correoElectronico)
        {
            string sSql = "INSERT INTO Tbl_remitente (nombre, numeroIdentificacion, telefono, correoElectronico) VALUES (?, ?, ?, ?);";
            {

                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@numeroIdentificacion", numeroIdentificacion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método de buscar chofer
        public DataTable buscarChofer(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                string sSql = "SELECT * FROM " + sTabla_chofer + " WHERE Pk_id_chofer = ?;";
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    cmd.Parameters.AddWithValue("@pk_id_Chofer", id);
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo buscar el registro en la tabla " + sTabla_chofer);
            }
            return dt;
        }

        public DataTable cargarChoferes()
        {
            DataTable dt = new DataTable();
            try
            {
                string sSql = "SELECT * FROM " + sTabla_chofer + ";";
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo cargar los choferes desde la tabla " + sTabla_chofer);
            }
            return dt;
        }


        public int getMaxIdVehiculo()
        {
            int iIdRegistro = 0;
            string sSql = "SELECT max(Pk_id_vehiculo) FROM " + sTabla_vehiculos + ";";
            try
            {
                using (OdbcCommand cmd = new OdbcCommand(sSql, cn.conexion()))
                {
                    iIdRegistro = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " \nNo se pudo obtener el id del registro en la tabla " + sTabla_vehiculos);
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

        //Boton de eliminar 
        public void eliminarVehiculo(string idVehiculo)
        {
            try
            {
                string sSql = "DELETE FROM " + sTabla_vehiculos + "WHERE Id = Pk_id_chofer;";
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
    }
}

        //Formulario de ingreso de remitente 
    
      






