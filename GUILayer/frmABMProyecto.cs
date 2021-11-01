using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerTech.GUILayer
{
    public partial class frmABMProyecto : Form
    {
        ProyectoService oProyectoService = new ProyectoService();
        UsuarioService oUsuarioService = new UsuarioService();
        ProductoService oProductoService = new ProductoService();
        bool nuevo = false;

        public frmABMProyecto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmABMProyecto_Load(object sender, EventArgs e)
        {
            cargarCombo(cboProducto, oProductoService.recuperarTodos(), "Nombre", "Id_producto");
            cargarCombo(cboResponsable, oUsuarioService.recuperarTodos(), "NombreUsuario", "IdUsuario");
            cargarGrilla(dgvProyecto, oProyectoService.recuperarTodos());
            habilitarCampos(false);
            dgvProyecto.ForeColor = Color.Black;
            dgvProyecto.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProyecto.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(165, 177, 182);
            dgvProyecto.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182);
            dgvProyecto.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182); ;
        }

        private void habilitarCampos(bool x)
        {
            cboProducto.Enabled = x;
            cboResponsable.Enabled = x;
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;
            txtDescripcion.Enabled = x;
            txtAlcance.Enabled = x;
            txtVersion.Enabled = x;
            btnEliminar.Enabled = !x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnSalir.Enabled = !x;
            dgvProyecto.Enabled = !x;
            if (dgvProyecto.Rows.Count == 0)
                btnEditar.Enabled = btnEliminar.Enabled = false;
        }

        private void cargarCombo(ComboBox combo, Object source, string display, string value)
        {
            combo.DataSource = source;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void cargarGrilla(DataGridView grilla, IList<Proyecto> lista)
        {
            grilla.Rows.Clear();
            //for(int i = 0; i<lista.Count; i++)
            foreach (var proyecto in lista)
            {
                grilla.Rows.Add(proyecto.Id_proyecto.ToString(),
                                proyecto.Producto.ToString(),
                                proyecto.Descripcion.ToString(),
                                proyecto.Version.ToString(),
                                proyecto.Responsable.ToString());
            }
        }
        private void limpiarCampos()
        {
            txtId.Clear();
            txtDescripcion.Clear();
            txtAlcance.Clear();
            txtVersion.Clear();
            cboProducto.SelectedIndex = -1;
            cboResponsable.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            this.habilitarCampos(true);
            limpiarCampos();
            dgvProyecto.Enabled = false;
            cboProducto.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarCampos(false);
            nuevo = false;
            if (dgvProyecto.Rows.Count != 0)
                this.actualizarCampos(dgvProyecto.CurrentRow.Cells[0].Value.ToString());
            else limpiarCampos();
            cargarGrilla(dgvProyecto, oProyectoService.recuperarTodos());
            btnBuscar.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
            dgvProyecto.Enabled = false;
            cboProducto.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que quiere eliminar el proyecto " + txtDescripcion.Text + " ?", "Borrar proyecto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Proyecto oProyecto = new Proyecto();
                oProyecto.Id_proyecto = Convert.ToInt32(txtId.Text);
                oProyectoService.eliminarProyecto(oProyecto);
                cargarGrilla(dgvProyecto, oProyectoService.recuperarTodos());

            }
            habilitarCampos(false);
        }

        private void actualizarCampos(string idProyecto)
        {
            Proyecto proyectoSeleccionado = oProyectoService.recuperarProyecto(idProyecto);
            if (proyectoSeleccionado != null)
            {
                txtId.Text = proyectoSeleccionado.Id_proyecto.ToString();
                cboProducto.SelectedValue = proyectoSeleccionado.Producto.Id_producto;
                txtDescripcion.Text = proyectoSeleccionado.Descripcion;
                txtVersion.Text = proyectoSeleccionado.Version;
                txtAlcance.Text = proyectoSeleccionado.Alcance;
                cboResponsable.SelectedValue = proyectoSeleccionado.Responsable.NombreUsuario;
            }
            else
                limpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Proyecto oProyecto = new Proyecto();
                //oProyecto.Id_proyecto = Convert.ToInt32(txtId.Text);
                oProyecto.Producto = oProductoService.recuperarProducto(cboProducto.SelectedValue.ToString());
                oProyecto.Descripcion = txtDescripcion.Text;
                oProyecto.Alcance = txtAlcance.Text;
                oProyecto.Version = txtVersion.Text;
                oProyecto.Responsable = oUsuarioService.recuperarUsuarioID(cboResponsable.SelectedValue.ToString());
                if (nuevo)
                {
                    oProyectoService.crearProyecto(oProyecto);
                    MessageBox.Show("¡Proyecto creado con éxito!", "Crear proyecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oProyecto.Id_proyecto = Convert.ToInt32(txtId.Text);
                    oProyectoService.actualizarProyecto(oProyecto);
                    MessageBox.Show("¡Proyecto actualizado con éxito!", "Actualizar proyecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cargarGrilla(dgvProyecto, oProyectoService.recuperarTodos());
                habilitarCampos(false);
                this.nuevo = false;
            }
        }

        public bool validarCampos()
        {

            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe seleccionar un producto.", "Datos de proyecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProducto.Focus();
                return false;
            }
            if (txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar una descripción de proyecto.", "Datos de proyecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }
            if (txtVersion.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar una versión del proyecto.", "Datos de proyecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVersion.Focus();
                return false;
            }
            if (txtAlcance.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un alcance.", "Datos de proyecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlcance.Focus();
                return false;
            }

            if (cboResponsable.SelectedIndex == -1)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe seleccionar un usuari@ responsable.", "Datos de proyecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboResponsable.Focus();
                return false;
            }

            return true;
        }

        private void dgvProyecto_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(dgvProyecto.CurrentRow.Cells[0].Value.ToString());
        }
        private void dgvProyecto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.actualizarCampos(dgvProyecto.CurrentRow.Cells[0].Value.ToString());
        }


        private void frmABMProyecto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnHabilitarBusqueda_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgvProyecto, oProyectoService.recuperarTodos());
            btnBuscar.Visible = true;
            habilitarCampos(true);
            txtDescripcion.Text = "";
            txtAlcance.Text = "";
            txtVersion.Text = "";
            cboProducto.SelectedIndex = -1;
            cboResponsable.SelectedIndex = -1;

            btnGuardar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string producto, responsable;

            if (cboProducto.SelectedIndex == -1)
                producto = "-1";
            else
                producto = cboProducto.SelectedValue.ToString();
            if (cboResponsable.SelectedIndex == -1)
                responsable = "-1";
            else
                responsable = cboResponsable.SelectedValue.ToString();

            cargarGrilla(dgvProyecto, oProyectoService.recuperarProyectosFiltro(producto, txtDescripcion.Text, txtVersion.Text,
                txtAlcance.Text, responsable));

            dgvProyecto.Enabled = true;
            btnEditar.Enabled = true;

        }
    }
}
