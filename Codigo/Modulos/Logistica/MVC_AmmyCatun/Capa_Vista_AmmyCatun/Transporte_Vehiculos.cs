using Capa_Controlador_AmmyCatun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_AmmyCatun
{
    public partial class Transporte_Vehiculos : Form
    {
        Capa_Controlador_AmmyCatun.ControladorPedido controlador = new ControladorPedido();

        public Transporte_Vehiculos()
        {
            InitializeComponent();
            CargarComboBoxForma();
            getId();
        }
        void getId()
        {
            Txt_Guia.Text = controlador.getNextId().ToString();
        }



        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            string direccionPartida = Txt_Partida.Text;
            string direccionLlegada = Txt_LLegada.Text;
            string numeroOrdenRecojo = Txt_Recojo.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form2
            Remitente remitenteForm = new Remitente();

            // Mostrar Form2
            remitenteForm.Show();

            // (Opcional) Si quieres ocultar Form1 al abrir Form2
            // this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form2
            Destinatario destinatarioForm = new Destinatario();

            // Mostrar Form2
            destinatarioForm.Show();

            // (Opcional) Si quieres ocultar Form1 al abrir Form2
            // this.Hide();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            {
                string idGuia = Txt_Guia.Text;

                if (string.IsNullOrWhiteSpace(idGuia))
                {
                    MessageBox.Show("Por favor, ingrese un ID de pedido para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar el pedido con ID " + idGuia + "?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    controlador.eliminarPedido(idGuia);
                    getId(); // Actualiza el ID después de eliminar
                    CargarDatosGrid(); // Reload data in the DataGridView
                }
            }
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            CargarDatosGrid(); // Reload data in the DataGridView
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            string direccionPartida = Txt_Partida.Text;
            string direccionLlegada = Txt_LLegada.Text;
            string numeroOrdenRecojo = Txt_Recojo.Text;
            ComboBox cmbFormaPago = Cmb_Forma;
            string destino = Txt_Destino.Text;
            DateTime fechaEmision = dtp_Fecha_Emision.Value;
            DateTime fechaTraslado = dtp_Fecha_Emision.Value;
            int idRemitente = Convert.ToInt32(Txt_ID_1.Text);
            int idDestinatario = Convert.ToInt32(Txt_ID_2.Text);
            int idvehiculo = Convert.ToInt32(Txt_id_Vehiculo.Text);
            int idGuia = Convert.ToInt32(Txt_Guia.Text);

            ControladorPedido controlador = new ControladorPedido();
            controlador.modificarPedido(direccionPartida, direccionLlegada, numeroOrdenRecojo, cmbFormaPago, destino, fechaEmision, fechaTraslado, idRemitente, idDestinatario, idvehiculo, idGuia);

            CargarDatosGrid();
        }

        private void Btn_Reporte_Click(object sender, EventArgs e)
        {
            //Abrir Formulario

            /*nombre del formulario*/
            Reporte_Pedidos reporte = new Reporte_Pedidos();
            reporte.Show();
        }
    
        private void Btn_Ayuda_Click(object sender, EventArgs e)
        {
            string idayuda = "2";
            string Ruta = controlador.MRuta(idayuda);
            string sRutaProyecto = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\..\..\..\"));
            string AsRuta = Path.Combine(sRutaProyecto, "Ayuda", "AyudaPedidos", Ruta);
            string AsIndice = controlador.MIndice(idayuda);

            // Validar que la ruta y el índice no estén vacíos
            if (!string.IsNullOrEmpty(AsRuta) && !string.IsNullOrEmpty(AsIndice))
            {
                // Mostrar la ayuda automáticamente cuando se llama a asignarAyuda
                Help.ShowHelp(this, AsRuta, AsIndice);
            }
            else
            {
                MessageBox.Show("La Ruta o el índice de la ayuda están vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

  






