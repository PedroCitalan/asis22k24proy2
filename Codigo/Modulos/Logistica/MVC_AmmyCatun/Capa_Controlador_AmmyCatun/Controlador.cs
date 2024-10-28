using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc; // Para OdbcDataReader
using Capa_Modelo_AmmyCatun; // Para Sentencias
using System.Windows.Forms;
using System.Data;
using System;

namespace Capa_Controlador_AmmyCatun
{
    public class ControladorChofer
    {
        private Capa_Modelo_AmmyCatun.Sentencias sentencias = new Capa_Modelo_AmmyCatun.Sentencias();

        public int guardarChofer(TextBox idChofer, string sNombreEmp, string sNumeroIdent, string sNombre, string sLicencia, string sTelefono, string sDireccion)
        {
            if (string.IsNullOrEmpty(idChofer.Text) || string.IsNullOrEmpty(sNombreEmp) || string.IsNullOrEmpty(sNumeroIdent) ||
                string.IsNullOrEmpty(sNombre) || string.IsNullOrEmpty(sLicencia) || string.IsNullOrEmpty(sTelefono) || string.IsNullOrEmpty(sDireccion))
            {
                MessageBox.Show("Existen campos vacios, revise y vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                sentencias.registrarChofer(idChofer.Text, sNombreEmp, sNumeroIdent, sNombre, sLicencia, sTelefono, sDireccion);
                return 1;
            }
        }

        public object getNextId()
        {
            int nextId = sentencias.getMaxIdChofer();
            nextId++;
            return nextId.ToString();
        }

        public DataTable CargarChoferes()
        {
            return sentencias.cargarChoferes();
        }

        public void eliminarChofer(string idChofer)
        {
            if (string.IsNullOrEmpty(idChofer))
            {
                MessageBox.Show("Existen campos vacios, revise y vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sentencias.eliminarChofer(idChofer);
            }
        }


        public void modificarChofer(string id, string nombreEmp, string numeroIdent, string nombre, string licencia, string telefono, string direccion)
        {
            sentencias.modificarChofer(id, nombreEmp, numeroIdent, nombre, licencia, telefono, direccion);
        }

        public DataTable buscarChofer(string id)
        {
            return sentencias.buscarChofer(id);
        }
    }

    public class ControladorVehiculo
    {
        private Capa_Modelo_AmmyCatun.Sentencias sentencias = new Capa_Modelo_AmmyCatun.Sentencias();


        public DataTable CargarVehiculos()
        {
            return sentencias.cargarVehiculos();
        }

        public object getNextId()
        {
            int nextId = sentencias.getMaxIdVehiculo();
            nextId++;
            return nextId.ToString();
        }
        //Boton de eliminar Transporte
        public void eliminarVehiculo(string idVehiculo)
        {

            if (string.IsNullOrEmpty(idVehiculo))
            {
                MessageBox.Show("Existen campos vacíos, revise y vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sentencias.eliminarVehiculo(idVehiculo);
            }

        }
        public int guardarVehiculo(string numeroPlaca, string marca, string color, string descripcion, string horaLlegada, string horaSalida, double pesoTotal, int idChofer)
        {
            if (string.IsNullOrEmpty(numeroPlaca) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(color) ||
               pesoTotal <= 0 || idChofer <= 0)
            {
                MessageBox.Show("Existen campos vacíos, revise y vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                sentencias.registrarVehiculo(numeroPlaca, marca, color, descripcion, horaLlegada, horaSalida, pesoTotal, idChofer);
                return 1;
            }
        }
        //Guardar datos de pedidos 
        public class ControladorPedido
        {
            private Capa_Modelo_AmmyCatun.Sentencias sentencias = new Capa_Modelo_AmmyCatun.Sentencias();


            // Método para cargar pedidos
            public DataTable CargarPedidos()
            {
                return sentencias.cargarPedidos(); // Asegúrate de que este método esté definido en tu clase Sentencias
            }
        }
    }
    // Método para guardar un pedido
    public class ControladorPedido
    {
        private Capa_Modelo_AmmyCatun.Sentencias sentencias = new Capa_Modelo_AmmyCatun.Sentencias();


        public DataTable CargarPedidos()
        {
            return sentencias.cargarPedidos();
        }


        // Método para obtener el próximo ID de pedido
        public object GetNextIdPedido()
        {
            int nextId = sentencias.getMaxIdPedido(); // Asegúrate de que este método esté definido en tu clase Sentencias
            return (nextId + 1).ToString();
        }

        public int guardarPedido(string direccionPartida, string direccionLlegada, string numeroOrdenRecojo, ComboBox cmbFormaPago, string destino, DateTime fechaEmision, DateTime fechaTraslado, int idRemitente, int idDestinatario, int idvehiculo)
        {
            {
                string formaPago = cmbFormaPago.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(direccionPartida) || string.IsNullOrEmpty(direccionLlegada) || string.IsNullOrEmpty(formaPago) || string.IsNullOrEmpty(destino))
                {
                    MessageBox.Show("Existen campos vacíos, revise y vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                else
                {
                    sentencias.registrarPedido(fechaEmision, fechaTraslado, direccionPartida, direccionLlegada, numeroOrdenRecojo, formaPago, destino, idRemitente, idDestinatario, idvehiculo);
                    MessageBox.Show("Pedido ingresado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;
                }
            }
        }
    }

}




