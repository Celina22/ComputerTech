using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace ComputerTech.GUILayer
{
    public partial class frmABMProducto : Form
    {

        ProductoService oProductoService = new ProductoService();
        bool nuevo = false;

        public frmABMProducto()
        {
            InitializeComponent();
        }

        private void frmABMProducto_Load(object sender, EventArgs e)
        {
            cargarGrilla(dgvProducto, oProductoService.recuperarTodos());
            habilitarCampos(false);
            dgvProducto.ForeColor = Color.Black;
            dgvProducto.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182); ;
            dgvProducto.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProducto.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(165, 177, 182);
            dgvProducto.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void habilitarCampos(bool x)
        {
            txtNombre.Enabled = x;
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;
            btnEliminar.Enabled = !x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnSalir.Enabled = !x;
            dgvProducto.Enabled = !x;
            if (dgvProducto.Rows.Count == 0)
                btnEditar.Enabled = btnEliminar.Enabled = false;
        }

        private void cargarGrilla(DataGridView grilla, IList<Producto> lista)
        {
            grilla.Rows.Clear();
            //for(int i = 0; i<lista.Count; i++)
            foreach (var producto in lista)
            {
                grilla.Rows.Add(producto.Id_producto.ToString(),
                                producto.Nombre.ToString());
            }
        }

        private void actualizarCampos(string idProducto)
        {
            Producto productoSeleccionado = oProductoService.recuperarProducto(idProducto);
            if (productoSeleccionado != null)
            {
                txtId.Text = productoSeleccionado.Id_producto.ToString();
                txtNombre.Text = productoSeleccionado.Nombre;

            }
            else
                limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
        }

        private void dgvProducto_SelectionChanged(object sender, EventArgs e)
        {
            actualizarCampos(dgvProducto.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            actualizarCampos(dgvProducto.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            this.habilitarCampos(true);
            limpiarCampos();
            dgvProducto.Enabled = false;
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarCampos(false);
            nuevo = false;
            if (dgvProducto.Rows.Count != 0)
                this.actualizarCampos(dgvProducto.CurrentRow.Cells[0].Value.ToString());
            else limpiarCampos();
            cargarGrilla(dgvProducto, oProductoService.recuperarTodos());
            btnBuscar.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitarCampos(true);
            dgvProducto.Enabled = false;
            txtNombre.Focus();
        }

        public bool validarCampos()
        {

            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un nombre de Producto.", "Datos de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Producto oProducto = new Producto();
                //oProyecto.Id_proyecto = Convert.ToInt32(txtId.Text);
                oProducto.Nombre = txtNombre.Text;
                if (nuevo)
                {
                    oProductoService.crearProducto(oProducto);
                    MessageBox.Show("¡Producto creado con éxito!", "Crear producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oProducto.Id_producto = Convert.ToInt32(txtId.Text);
                    oProductoService.actualizarProducto(oProducto);
                    MessageBox.Show("¡Producto actualizado con éxito!", "Actualizar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cargarGrilla(dgvProducto, oProductoService.recuperarTodos());
                habilitarCampos(false);
                this.nuevo = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que quiere eliminar el producto " + txtNombre.Text + " ?", "Borrar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Producto oProducto = new Producto();
                oProducto.Id_producto = Convert.ToInt32(txtId.Text);
                oProductoService.eliminarProducto(oProducto);
                cargarGrilla(dgvProducto, oProductoService.recuperarTodos());

            }
            habilitarCampos(false);
        }

        private void btnHabilitarBusqueda_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgvProducto, oProductoService.recuperarTodos());
            btnBuscar.Visible = true;
            habilitarCampos(true);
            txtNombre.Text = "";
            btnGuardar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgvProducto, oProductoService.recuperarProductoNombre(txtNombre.Text));
        }

        private void frmABMProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }
    }
}
