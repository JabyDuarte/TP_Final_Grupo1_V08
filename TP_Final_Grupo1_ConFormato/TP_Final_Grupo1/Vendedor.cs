using Datos;
using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_Final_Grupo1
{
    public partial class Vendedor : Form
    {
        private ClienteConsulta clienteConsulta;
        private ClienteLogica clienteLogica;
        private ProductoConsulta productoConsulta;
        private ProductoLogica productoLogica;
        private List<Producto> productos; // Lista para almacenar productos

        public Vendedor()
        {
            InitializeComponent();
            clienteConsulta = new ClienteConsulta();
            clienteLogica = new ClienteLogica();
            productoConsulta = new ProductoConsulta();
            productoLogica = new ProductoLogica();
            productos = new List<Producto>(); // Inicializa la lista de productos
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblOpcion.Visible = true;
            txtOpcion.Visible = true;
            btn_Aceptar.Visible = true;
            btnOcultar.Visible = true;
            lblOpcion.Text = "Cliente";
            lblLinea.Visible = true;
            txtOpcion.Focus();
            ConfigurarColumnasDataGridView("Cliente"); // Configuro columnas para Cliente
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblOpcion.Visible = true;
            txtOpcion.Visible = true;
            btn_Aceptar.Visible = true;
            btnOcultar.Visible = true;
            lblOpcion.Text = "Producto";
            ConfigurarColumnasDataGridView("Producto"); // Configuro columnas para Producto
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            string opcion = lblOpcion.Text;
            string descripcion = txtOpcion.Text;

            LimpiarDataGridView();
            ConfigurarColumnasDataGridView(opcion);

            switch (opcion)
            {
                case "Cliente":
                    BuscarYMostrarCliente(descripcion);
                    break;

                case "Producto":
                    BuscarYMostrarProducto(descripcion);
                    break;

                default:
                    
                    break;
            }
        }

        private void ConfigurarColumnasDataGridView(string opcion)
        {
            dataGridView.Columns.Clear(); // Limpiar las columnas existentes

            switch (opcion)
            {
                case "Cliente":
                    // Configuro las columnas para Cliente
                    dataGridView.Columns.Add("RazonSocial", "Razón Social");
                    dataGridView.Columns.Add("FechaAlta", "Fecha Alta");
                    dataGridView.Columns.Add("FechaBaja", "Fecha Baja");
                    dataGridView.Columns.Add("LimiteCredito", "Límite de Crédito");
                    dataGridView.Columns.Add("TipoIva", "Tipo IVA");
                    break;

                case "Producto":
                    // Configuro las columnas para Producto
                    dataGridView.Columns.Add("Descripcion", "Descripción");
                    dataGridView.Columns.Add("IdUnidadDeMedida", "ID Unidad de Medida");
                    dataGridView.Columns.Add("ValorUnitario", "Valor Unitario");
                    dataGridView.Columns.Add("Habilitado", "Habilitado");
                    break;

                default:                    
                    break;
            }
        }

        private void LimpiarDataGridView()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
        }

        private void BuscarYMostrarCliente(string razonSocial)
        {
            List<Cliente> resultados = clienteLogica.BuscarClientePorRazonSocial(razonSocial);

            // Limpio las filas existentes en el DataGridView
            dataGridView.Rows.Clear();

            // Verifico si se encontraron resultados
            if (resultados.Count > 0)
            {
                // Itero sobre la lista de clientes y agrega una fila por cada uno al DataGridView
                foreach (Cliente resultado in resultados)
                {
                    dataGridView.Rows.Add(resultado.RazonSocial, resultado.FechaAlta, resultado.FechaBaja, resultado.LimiteCredito, resultado.TipoIva);
                }

                dataGridView.Visible = true;
                txtOpcion.Text = ""; // Limpia el cuadro de texto
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuscarYMostrarProducto(string descripcion)
        {
            productos = productoLogica.BuscarProductosPorDescripcion(descripcion);

            foreach (var producto in productos)
            {
                string habilitado = producto.Habilitado ? "Si" : "No";
                dataGridView.Rows.Add(producto.Descripcion, producto.IdUnidadDeMedida, producto.ValorUnitario, habilitado);
            }

            if (productos.Count > 0)
            {
                dataGridView.Visible = true;
                txtOpcion.Text = ""; // Limpia el cuadro de texto
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            lblOpcion.Visible = false;
            txtOpcion.Visible = false;
            btn_Aceptar.Visible = false;
            lblOpcion.Visible = false;
            dataGridView.Visible = false;
            btnOcultar.Visible = false;
        }
    }
}
