using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_AmmyCatun;

namespace Capa_Vista_AmmyCatun
{
    public partial class Transporte : Form
    {
        Capa_Controlador_AmmyCatun.ControladorVehiculo controlador = new Capa_Controlador_AmmyCatun.ControladorVehiculo();
        public Transporte()
        {
            InitializeComponent();
            getId();
            CargarDatosGrid(); // Load data into the DataGridView
        }
        void getId()
        {
            Txt_ID.Text = controlador.getNextId().ToString();
        }

        private void CargarDatosGrid()
        {

            DataTable dt = controlador.CargarVehiculos(); // Método que debes crear en Controlador
            Dgv_Vehiculo.DataSource = dt;
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {

            CargarDatosGrid(); // Reload data in the DataGridView
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {

        }
        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
      
                ControladorVehiculo controladorVehiculo = new ControladorVehiculo();

                // Recopila los datos ingresados en los controles del formulario
                string numeroPlaca = Txt_Placa.Text;
                string marca = Txt_Marca.Text;
                string color = Txt_Color.Text;
                string descripcion = Txt_Desc.Text;
                string horaLlegada =Txt_HLL.Text; // Asumiendo formato "HH:mm"
                string horaSalida = Txt_HS.Text; // Asumiendo formato "HH:mm"
                double pesoTotal;
                int idChofer;

                // Validación de los datos ingresados
                if (!double.TryParse(Txt_Total.Text, out pesoTotal) || pesoTotal <= 0)
                {
                    MessageBox.Show("Por favor, ingresa un peso total válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(Txt_ID.Text, out idChofer) || idChofer <= 0)
                {
                    MessageBox.Show("Por favor, ingresa un ID de chofer válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validación del formato de hora
                if (!TimeSpan.TryParse(horaLlegada, out _) || !TimeSpan.TryParse(horaSalida, out _))
                {
                    MessageBox.Show("Por favor, ingresa un formato de hora válido (HH:mm).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llama al método para guardar el vehículo
                int resultado = controladorVehiculo.guardarVehiculo(numeroPlaca, marca, color, descripcion,
                                                                     horaLlegada, horaSalida, pesoTotal, idChofer);

                // Manejo del resultado
                if (resultado == 1)
                {
                    MessageBox.Show("Vehículo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar los campos después de guardar (opcional)
                   
                }
                else
                {
                    MessageBox.Show("Error al guardar el vehículo, revise los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            {
                string idVehiculo = Txt_ID.Text;

                if (string.IsNullOrWhiteSpace(idVehiculo))
                {
                    MessageBox.Show("Por favor, ingrese un ID de chofer para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar al chofer con ID " + idVehiculo + "?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    controlador.eliminarVehiculo(idVehiculo);
                    getId(); // Actualiza el ID después de eliminar
                }
            }
        }
    }
}

      