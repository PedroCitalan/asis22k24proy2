using Capa_Controlador_AmmyCatun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_AmmyCatun
{
    public partial class Transporte_Vehiculos : Form
    {
     

        public Transporte_Vehiculos()
        {
            InitializeComponent();
            CargarComboBoxForma();
        }


        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
                    string direccionPartida = Txt_Partida.Text;
                    string direccionLlegada = Txt_LLegada.Text;
                    string numeroOrdenRecojo =Txt_Recojo.Text;
                    ComboBox cmbFormaPago = Cmb_Forma;
                    string destino = Txt_Destino.Text;
                    DateTime fechaEmision = dtp_Fecha_Emision.Value;
                    DateTime fechaTraslado = dtp_Fecha_Emision.Value;
                    int idRemitente = Convert.ToInt32(Txt_ID_1.Text);
                    int idDestinatario = Convert.ToInt32(Txt_ID_2.Text);
                    int idvehiculo = Convert.ToInt32(Txt_id_Vehiculo.Text);

            ControladorPedido controlador = new ControladorPedido();
                    controlador.guardarPedido(direccionPartida, direccionLlegada, numeroOrdenRecojo, cmbFormaPago, destino, fechaEmision, fechaTraslado, idRemitente, idDestinatario, idvehiculo);

                    CargarDatosGrid();
                }

      
        private void CargarDatosGrid()
        {
            ControladorPedido controlador = new ControladorPedido();
            DataTable dtPedidos = controlador.CargarPedidos();

            Dgv_Cliente.DataSource = dtPedidos;
        }


   

        private void CargarComboBoxForma()
        {
            // Agregar opciones de forma de pago
            Cmb_Forma.Items.Add("Efectivo");
            Cmb_Forma.Items.Add("Tarjeta de Crédito");
            Cmb_Forma.Items.Add("Tarjeta de Débito");
            Cmb_Forma.Items.Add("Transferencia Bancaria");
            Cmb_Forma.Items.Add("Cheque");

            // Establecer la selección predeterminada a nulo
            Cmb_Forma.SelectedIndex = -1;

            // Cargar los datos en el DataGridView
            CargarDatosGrid();
        }
    }
}





