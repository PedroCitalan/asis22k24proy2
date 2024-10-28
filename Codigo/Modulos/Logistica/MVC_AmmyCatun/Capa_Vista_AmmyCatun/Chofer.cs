using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Metodo de eliminar chofer Ammy Patricia Catun Lopez 0901-21-4857
namespace Capa_Vista_AmmyCatun
{
    public partial class Chofer : Form
    {
        Capa_Controlador_AmmyCatun.ControladorChofer controlador = new Capa_Controlador_AmmyCatun.ControladorChofer();
        public Chofer()
        {
            InitializeComponent();
            CargarComboBoxLicencias();
            getId();
            CargarDatosGrid(); // Actualiza el DataGridView
                               // Vincular el evento CellClick
            Dgv_chofer.CellClick += Dgv_chofer_CellContentClick;
        }

        private void CargarDatosGrid()
        {
            DataTable dt = controlador.CargarChoferes(); // Método que debes crear en Controlador
            Dgv_chofer.DataSource = dt;
        }


        private void CargarComboBoxLicencias()
        {
            Cmb_Licencia.Items.Add("Tipo A");
            Cmb_Licencia.Items.Add("Tipo B");
            Cmb_Licencia.Items.Add("Tipo C");
        }
        void getId()
        {
            Txt_ID.Text = controlador.getNextId().ToString();
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            controlador.guardarChofer(Txt_ID, Txt_Empresa.Text, Txt_Identificacion.Text, Txt_Nombre.Text, Cmb_Licencia.Text, Txt_Tel.Text, Txt_Dir.Text);
            getId();
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            CargarDatosGrid(); // Llama al método para recargar los datos en el DataGridView
        }


        //Metodo de modificar chofer Ammy Patricia Catun Lopez 0901-21-4857
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            string id = Txt_ID.Text;

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Por favor, seleccione un id de chofer para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamada al método de modificar chofer en el controlador
            controlador.modificarChofer(
                id,
                Txt_Empresa.Text,
                Txt_Identificacion.Text,
                Txt_Nombre.Text,
                Cmb_Licencia.Text,
                Txt_Tel.Text,
                Txt_Dir.Text
            );

            // Actualiza la vista del DataGridView
            CargarDatosGrid();

            // Opcional: Reinicia los campos si es necesario
            getId();
        }


        //Metodo de buscar chofer Ammy Patricia Catun Lopez 0901-21-4857
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            {
                string id = Txt_ID.Text;

                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Por favor, ingrese un ID de chofer para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = controlador.buscarChofer(id);
                if (dt.Rows.Count > 0)
                {
                    // Asignar los valores a los controles del formulario
                    Txt_Empresa.Text = dt.Rows[0]["nombreEmpresa"].ToString();
                    Txt_Identificacion.Text = dt.Rows[0]["numeroIdentificacion"].ToString();
                    Txt_Nombre.Text = dt.Rows[0]["nombre"].ToString();
                    Cmb_Licencia.SelectedItem = dt.Rows[0]["licencia"].ToString();
                    Txt_Tel.Text = dt.Rows[0]["telefono"].ToString();
                    Txt_Dir.Text = dt.Rows[0]["direccion"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró el chofer con ID " + id, "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //Metodo de eliminar chofer Ammy Patricia Catun Lopez 0901-21-4857
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            {
                string idChofer = Txt_ID.Text;

                if (string.IsNullOrWhiteSpace(idChofer))
                {
                    MessageBox.Show("Por favor, ingrese un ID de chofer para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar al chofer con ID " + idChofer + "?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    controlador.eliminarChofer(idChofer);
                    getId(); // Actualiza el ID después de eliminar
                }
            }
        }

        private void Dgv_chofer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se ha seleccionado una fila válida
            {
                DataGridViewRow row = Dgv_chofer.Rows[e.RowIndex];

                // Cargar los datos en los TextBox y ComboBox utilizando el ID
                Txt_ID.Text = row.Cells["Pk_id_chofer"].Value.ToString(); // Aquí tomamos el ID
                Txt_Empresa.Text = row.Cells["nombreEmpresa"].Value.ToString();
                Txt_Identificacion.Text = row.Cells["numeroIdentificacion"].Value.ToString();
                Txt_Nombre.Text = row.Cells["nombre"].Value.ToString();
                Cmb_Licencia.SelectedItem = row.Cells["licencia"].Value.ToString();
                Txt_Tel.Text = row.Cells["telefono"].Value.ToString();
                Txt_Dir.Text = row.Cells["direccion"].Value.ToString();
            }
        }

        private void Cmb_Licencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Boton Elimina Transporte Ammy Patricia Catun Lopez 0901-21-4857

       
    }
}
      

     