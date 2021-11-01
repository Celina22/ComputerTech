using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerTech.GUILayer
{
    public partial class frmABMContactos : Form
    {
        ContactoService oContactoService = new ContactoService();
        bool nuevo = false;
        public frmABMContactos()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmABMContactos_Load(object sender, EventArgs e)
        {
            cargarGrilla(dgvContactos, oContactoService.recuperarTodos());
            habilitarCampos(false);
            txtId.Enabled = false;
            dgvContactos.ForeColor = Color.Black;
            dgvContactos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182); ;
            dgvContactos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvContactos.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(165, 177, 182);
            dgvContactos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182);
        }

        private void habilitarCampos(bool x)
        {
            txtNombre.Enabled = x;
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;
            txtApellido.Enabled = x;
            txtEmail.Enabled = x;
            txtTelefono.Enabled = x;
            btnEliminar.Enabled = !x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnSalir.Enabled = !x;
            dgvContactos.Enabled = !x;
            if (dgvContactos.Rows.Count == 0)
                btnEditar.Enabled = btnEliminar.Enabled = false;
        }
        private void cargarGrilla(DataGridView grilla, IList<Contacto> lista)
        {
            grilla.Rows.Clear();
            //for(int i = 0; i<lista.Count; i++)
            foreach (var contacto in lista)
            {
                grilla.Rows.Add(contacto.Id_contacto.ToString(),
                                contacto.Nombre.ToString(),
                                contacto.Apellido.ToString(),
                                contacto.Email.ToString(),
                                contacto.Telefono.ToString());
            }
        }
        private void limpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }
        private void actualizarCampos(string idContacto)
        {
            Contacto contactoSeleccionado = oContactoService.recuperarContacto(idContacto);
            if (contactoSeleccionado != null)
            {
                txtId.Text = contactoSeleccionado.Id_contacto.ToString();
                txtNombre.Text = contactoSeleccionado.Nombre;
                txtApellido.Text = contactoSeleccionado.Apellido;
                txtEmail.Text = contactoSeleccionado.Email;
                txtTelefono.Text = contactoSeleccionado.Telefono.ToString();
            }
            else
                limpiarCampos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            this.habilitarCampos(true);
            limpiarCampos();
            dgvContactos.Enabled = false;
            txtNombre.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarCampos(false);
            nuevo = false;
            if (dgvContactos.Rows.Count != 0)
                this.actualizarCampos(dgvContactos.CurrentRow.Cells[0].Value.ToString());
            else limpiarCampos();
            cargarGrilla(dgvContactos, oContactoService.recuperarTodos());
            btnBuscar.Visible = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
            dgvContactos.Enabled = false;
            txtNombre.Focus();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que quiere eliminar al contacto " + txtNombre.Text + " " + txtApellido.Text + "?", "Borrar contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Contacto oContacto = new Contacto();
                oContacto.Id_contacto = Convert.ToInt32(txtId.Text);
                oContactoService.eliminarContacto(oContacto);
                cargarGrilla(dgvContactos, oContactoService.recuperarTodos());
            }
            habilitarCampos(false);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Contacto oContacto = new Contacto();
                oContacto.Nombre = txtNombre.Text;
                oContacto.Apellido = txtApellido.Text;
                oContacto.Email = txtEmail.Text;
                oContacto.Telefono = Convert.ToInt64(txtTelefono.Text);
                if (nuevo)
                {
                    oContactoService.crearContacto(oContacto);
                    MessageBox.Show("¡Contacto registrado con éxito!", "Crear contacto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oContacto.Id_contacto = Convert.ToInt32(txtId.Text);
                    oContactoService.actualizarContacto(oContacto);
                    MessageBox.Show("¡Contacto actualizado con éxito!", "Actualizar contacto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cargarGrilla(dgvContactos, oContactoService.recuperarTodos());
                habilitarCampos(false);
                this.nuevo = false;
            }
        }

        public bool validarCampos()
        {

            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un nombre de contacto.", "Datos de contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (txtApellido.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un apellido de contacto.", "Datos de contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un email de contacto.", "Datos de contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Datos ingresados no válidos. Debe seleccionar un teléfono de contacto.", "Datos de contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            else if (!Int64.TryParse(txtTelefono.Text, out long numero))
            {
                MessageBox.Show("Datos ingresados no válidos. El teléfono de contacto debe contener solamente números.", "Datos de contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.actualizarCampos(dgvContactos.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvContactos_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(dgvContactos.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnHabilitarBusqueda_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgvContactos, oContactoService.recuperarTodos());
            btnBuscar.Visible = true;
            habilitarCampos(true);
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            btnGuardar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgvContactos, oContactoService.recuperarContactoConsulta(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text));
        }

        private void frmABMContactos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
