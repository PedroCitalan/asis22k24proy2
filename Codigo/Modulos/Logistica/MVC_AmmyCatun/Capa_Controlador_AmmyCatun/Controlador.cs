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
    // Creacion de clase de control datos pedido Realizado por Ammy Patricia Catun Lopez 0901-21-4857
    public class ControladorPedido
    {
        private Capa_Modelo_AmmyCatun.Sentencias sentencias = new Capa_Modelo_AmmyCatun.Sentencias();
        public object getNextId()
        {
            int nextId = sentencias.getMaxIdPedido();
            nextId++;
            return nextId.ToString();
        }

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

        // Método para guardar un datos pedido Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public int guardarPedido(string direccionPartida, string direccionLlegada, string numeroOrdenRecojo, ComboBox cmbFormaPago, string destino, DateTime fechaEmision, DateTime fechaTraslado, int idRemitente, int idDestinatario, int idvehiculo)
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
        // Método para eliminar  datos pedido Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public void eliminarPedido(string idGuia)
        {
            if (string.IsNullOrEmpty(idGuia))
            {
                MessageBox.Show("Existen campos vacios, revise y vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sentencias.eliminarPedido(idGuia);
            }
        }
        // Método para modificar datos pedido Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public int modificarPedido(string direccionPartida, string direccionLlegada, string numeroOrdenRecojo, ComboBox cmbFormaPago, string destino, DateTime fechaEmision, DateTime fechaTraslado, int idRemitente, int idDestinatario, int idvehiculo, int idGuia)
        {

            string formaPago = cmbFormaPago.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(direccionPartida) || string.IsNullOrEmpty(direccionLlegada) || string.IsNullOrEmpty(formaPago) || string.IsNullOrEmpty(destino))

            {
                MessageBox.Show("Existen campos vacíos, revise y vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                sentencias.modificarPedido(fechaEmision, fechaTraslado, direccionPartida, direccionLlegada, numeroOrdenRecojo, formaPago, destino, idRemitente, idDestinatario, idvehiculo, idGuia);
                MessageBox.Show("Pedido modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1;
            }
        }
        public string MIndice(string Indice1)
        {
            string indice = sentencias.modIndice(Indice1);

            return indice;
        }

        public string MRuta(string Ruta1)
        {
            string ruta = sentencias.modRuta(Ruta1);

            return ruta;
        }
    }


    //Clase de controlador  de Transporte-Vehiculo Realizado por Ammy Patricia Catun Lopez 0901-21-4857
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
        // Método para modificar vehiculos Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public int modificarVehiculo(int idVehiculo, string numeroPlaca, string marca, string color, string descripcion, string horaLlegada, string horaSalida, double pesoTotal, int idChofer)
        {
            if (idVehiculo <= 0 || string.IsNullOrEmpty(numeroPlaca) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(color) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(horaLlegada) ||
               string.IsNullOrEmpty(horaSalida) || pesoTotal <= 0 || idChofer <= 0)
            {
                MessageBox.Show("Existen campos vacíos, revise y vuelva a intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                sentencias.modificarVehiculo(idVehiculo, numeroPlaca, marca, color, descripcion, horaLlegada, horaSalida, pesoTotal, idChofer);
                return 1;
            }
        }

        // Método para Eliminar vehiculos Realizado por Ammy Patricia Catun Lopez 0901-21-4857
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
        // // Método para agregar la ayuda en  formulario Realizado por Ammy Patricia Catun Lopez 0901-21-4857
        public string MIndice(string Indice1)
        {
            string indice = sentencias.modIndice(Indice1);

            return indice;
        }

        public string MRuta(string Ruta1)
        {
            string ruta = sentencias.modRuta(Ruta1);

            return ruta;
        }
    }
}


   

      











