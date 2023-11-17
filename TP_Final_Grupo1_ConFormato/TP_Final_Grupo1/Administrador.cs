using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Logica;

namespace TP_Final_Grupo1
{
    public partial class Administrador : Form
    {
        private TipoIvaLogica tipoIvaLogica;

        public Administrador()
        {
            InitializeComponent();
            tipoIvaLogica = new TipoIvaLogica();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblOpcion1.Visible = true;
            lblOpcion2.Visible = true;
            txtOpcion1.Text = "";
            txtOpcion2.Text = "";
            lblOpcion1.Text = "Descripcion";
            lblOpcion2.Text = "Porcentaje";
            txtOpcion1.Visible = true;
            txtOpcion2.Visible = true;
            btn_Agregar.Visible = true;
            btn_Modificar.Visible = false;
            chkHabilitado.Visible = true;
            ConfigurarColumnasTipoIvaDataGridView();
            CargarDatosTipoIvaDataGridView();
        }

        private void ConfigurarColumnasTipoIvaDataGridView()
        {
            dgvOpcion.Columns.Clear(); // Limpiar las columnas existentes

            // Configurar las columnas para Tipo de IVA
            dgvOpcion.Columns.Add("Descripcion", "Descripción");
            dgvOpcion.Columns.Add("Porcentaje", "Porcentaje");
            dgvOpcion.Columns.Add("Habilitado", "Habilitado");
        }

        private void CargarTiposIvaEnComboBox()
        {
            List<TipoIva> tiposIva = tipoIvaLogica.ObtenerTiposIva();

            // Agrego un elemento vacío al principio de la lista
            tiposIva.Insert(0, new TipoIva { IdTipoIva = 0, Descripcion = "Seleccionar" });

            // Asigna la lista de tipos de IVA al ComboBox
            cboOpcion.DataSource = tiposIva;
            cboOpcion.DisplayMember = "Descripcion"; // Muestro la descripción en el ComboBox
            cboOpcion.ValueMember = "IdTipoIva"; // Uso el IdTipoIva como valor seleccionado

            //cboOpcion.SelectedIndex = 0;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están completos
            if (CamposCompletos())
            {
                // Crear un nuevo TipoIva con la información ingresada
                TipoIva nuevoTipoIva = new TipoIva
                {
                    Descripcion = txtOpcion1.Text,
                    Porcentaje = Convert.ToDouble(txtOpcion2.Text),
                    Habilitado = chkHabilitado.Checked ? 1 : 0 
                };

                // Agregar el TipoIva usando la lógica correspondiente
                tipoIvaLogica.AgregarTipoIva(nuevoTipoIva);

                // Limpiar los campos después de agregar
                LimpiarCampos();

                // recargar el ComboBox con la lista actualizada de tipos de IVA
                CargarTiposIvaEnComboBox();

                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LimpiarCampos()
        {
            txtOpcion1.Text = "";
            txtOpcion2.Text = "";
            txtOpcion3.Text = "";
        }

        // Método para verificar si los campos están completos
        private bool CamposCompletos()
        {
            return !string.IsNullOrEmpty(txtOpcion1.Text) && !string.IsNullOrEmpty(txtOpcion2.Text);
        }

        private void ActualizarDataGridView()
        {
            // Limpiar las filas existentes en el DataGridView
            dgvOpcion.Rows.Clear();

            // Obtener la lista actualizada de tipos de IVA
            List<TipoIva> tiposIva = tipoIvaLogica.ObtenerTiposIva();

            // Iterar sobre la lista y agregar filas al DataGridView
            foreach (TipoIva tipoIva in tiposIva)
            {
                dgvOpcion.Rows.Add(tipoIva.Descripcion, tipoIva.Porcentaje, tipoIva.Habilitado == 1 ? "Sí" : "No");
            }
        }

        private void CargarDatosTipoIvaDataGridView()
        {
            List<TipoIva> tiposIva = tipoIvaLogica.ObtenerTiposIva();

            // Configura las columnas para Tipo de IVA
            ConfigurarColumnasTipoIvaDataGridView();

            // Itera sobre la lista de tipos de IVA y agrega una fila por cada uno al DataGridView
            foreach (TipoIva tipoIva in tiposIva)
            {
                dgvOpcion.Rows.Add(tipoIva.Descripcion, tipoIva.Porcentaje, tipoIva.Habilitado == 1 ? "Sí" : "No");
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            // Obtén los datos del formulario o de donde sea necesario
            TipoIva tipoIva = ObtenerDatosDelFormulario();

            // Llama al método de la capa de lógica para editar el tipo de IVA
            bool resultado = tipoIvaLogica.EditarTipoIva(tipoIva);

            // Puedes manejar el resultado de acuerdo a tus necesidades (mostrar mensajes, actualizar UI, etc.)
            if (resultado)
            {
                MessageBox.Show("Tipo de IVA editado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosTipoIvaDataGridView();
            }
            else
            {
                MessageBox.Show("Error al editar el tipo de IVA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TipoIva ObtenerDatosDelFormulario()
        {
            // Creo un objeto TipoIva y asigno los valores
            if (cboOpcion.SelectedItem != null && cboOpcion.SelectedItem is TipoIva tipoIvaSeleccionado)
            {
                // Utiliza los datos del objeto seleccionado en el ComboBox
                tipoIvaSeleccionado.Descripcion = txtOpcion1.Text;
                tipoIvaSeleccionado.Porcentaje = Convert.ToDouble(txtOpcion2.Text);
                tipoIvaSeleccionado.Habilitado = chkHabilitado.Checked ? 1 : 0;

                return tipoIvaSeleccionado;
            }

            return null;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblOpcion1.Visible = true;
            lblOpcion2.Visible = true;            
            lblOpcion1.Text = "Descripcion";
            lblOpcion2.Text = "Porcentaje";
            txtOpcion1.Visible = true;
            txtOpcion2.Visible = true;
            btn_Agregar.Visible = false;
            btn_Eliminar.Visible = false;
            btn_Modificar.Visible = true;
            chkHabilitado.Visible = true;
            
            CargarTiposIvaEnComboBox();
            ConfigurarColumnasTipoIvaDataGridView();
            CargarDatosTipoIvaDataGridView();
        }

        private void CargarDatosTipoIvaSeleccionado()
        {
            // Verifico si hay un elemento seleccionado en el ComboBox
            if (cboOpcion.SelectedItem != null && cboOpcion.SelectedItem is TipoIva tipoIvaSeleccionado) 
            {
                // Verifico si no es el elemento inicial ("Seleccionar")
                if (tipoIvaSeleccionado.IdTipoIva != 0)
                {
                    // Cargo los datos del tipoIvaSeleccionado 
                    txtOpcion1.Text = tipoIvaSeleccionado.Descripcion;
                    txtOpcion2.Text = tipoIvaSeleccionado.Porcentaje.ToString();
                    chkHabilitado.Checked = tipoIvaSeleccionado.Habilitado == 1;
                }
                else
                {
                    // Si es el elemento Seleccionar dejo los txtBox vacios
                    txtOpcion1.Text = "";
                    txtOpcion2.Text = "";
                    chkHabilitado.Checked = false;
                }
            }
        }

        private void cboOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosTipoIvaSeleccionado();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            // Obtén el IdTipoIva del elemento seleccionado en el ComboBox o DataGridView
            if (cboOpcion.SelectedItem != null && cboOpcion.SelectedItem is TipoIva tipoIvaSeleccionado)
            {
                int idTipoIva = tipoIvaSeleccionado.IdTipoIva;

                // Llama al método de la capa de lógica para eliminar el tipo de IVA
                bool resultado = tipoIvaLogica.EliminarTipoIva(idTipoIva);

                // Puedes manejar el resultado de acuerdo a tus necesidades (mostrar mensajes, actualizar UI, etc.)
                if (resultado)
                {
                    MessageBox.Show("Tipo de IVA eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualiza el ComboBox y/o DataGridView después de la eliminación
                    CargarTiposIvaEnComboBox();
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el tipo de IVA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblOpcion1.Visible = true;
            lblOpcion2.Visible = true;
            txtOpcion1.Text = "";
            txtOpcion2.Text = "";
            lblOpcion1.Text = "Descripcion";
            lblOpcion2.Text = "Porcentaje";
            txtOpcion1.Visible = true;
            txtOpcion2.Visible = true;
            btn_Agregar.Visible = false;
            btn_Modificar.Visible = false;
            btn_Eliminar.Visible = true;
            chkHabilitado.Visible = true;
            CargarTiposIvaEnComboBox();
            ConfigurarColumnasTipoIvaDataGridView();
            CargarDatosTipoIvaDataGridView();
        }
    }
}
