using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerTech.GUILayer
{
    public partial class frmABMClientes : Form
    {
        BarrioService oBarrioService = new BarrioService();
        ContactoService oContactoService = new ContactoService();
        ClienteService oClienteService = new ClienteService();
        bool nuevo = false;
        public frmABMClientes()
        {
            InitializeComponent();
        }

        private void frmABMClientes_Load(object sender, EventArgs e)
        {
            cargarCombo(cboBarrio, oBarrioService.recuperarTodos(), "Nombre", "Id_barrio");
            cargarCombo(cboContacto, oContactoService.recuperarTodos(), "Nombre", "Id_contacto");
            cargarGrilla(dgvClientes, oClienteService.recuperarTodos());
            habilitarCampos(false);
            dgvClientes.ForeColor = Color.Black;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182); ;
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClientes.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(165, 177, 182);
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182); ;

        }
        private void habilitarCampos(bool x)
        {
            cboBarrio.Enabled = x;
            cboContacto.Enabled = x;
            txtId.Enabled = false;
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;
            txtCuit.Enabled = x;
            txtRazonSocial.Enabled = x;
            txtCalle.Enabled = x;
            txtNumero.Enabled = x;
            dtpFechaAlta.Enabled = x;

            btnEliminar.Enabled = !x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnSalir.Enabled = !x;
            dgvClientes.Enabled = !x;
            if (dgvClientes.Rows.Count == 0)
                btnEditar.Enabled = btnEliminar.Enabled = false;
        }
        private void limpiarCampos()
        {
            txtId.Clear();
            txtCuit.Clear();
            txtRazonSocial.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            dtpFechaAlta.Value = DateTime.Now;
            cboBarrio.SelectedIndex = -1;
            cboContacto.SelectedIndex = -1;
        }

        private void cargarCombo(ComboBox combo, Object source, string display, string value)
        {
            combo.DataSource = source;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }
        private void cargarGrilla(DataGridView grilla, IList<Cliente> lista)
        {
            grilla.Rows.Clear();
            //for(int i = 0; i<lista.Count; i++)
            foreach (var cliente in lista)
            {
                grilla.Rows.Add(cliente.Id_cliente.ToString(),
                                cliente.Cuit.ToString(),
                                cliente.Razon_social.ToString(),
                                cliente.Calle.ToString(),
                                cliente.Numero.ToString());
            }
        }

        //Con este evento se permite mostrar nombre y apellido en el combo de Contacto.
        private void cboContactoFormat(object sender, ListControlConvertEventArgs e)
        {
            string nombre = ((Contacto)e.ListItem).Nombre;
            string apellido = ((Contacto)e.ListItem).Apellido;
            e.Value = nombre + " " + apellido;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            this.habilitarCampos(true);
            limpiarCampos();
            dgvClientes.Enabled = false;
            txtCuit.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarCampos(false);
            nuevo = false;
            if (dgvClientes.Rows.Count != 0)
                this.actualizarCampos(dgvClientes.CurrentRow.Cells[0].Value.ToString());
            else limpiarCampos();
            cargarGrilla(dgvClientes, oClienteService.recuperarTodos());
            btnBuscar.Visible = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
            dgvClientes.Enabled = false;
            txtCuit.Focus();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que quiere eliminar al cliente " + txtRazonSocial.Text + "?", "Borrar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Cliente oCliente = new Cliente();

                oCliente.Id_cliente = Convert.ToInt32(txtId.Text);
                oClienteService.eliminarCliente(oCliente);
                cargarGrilla(dgvClientes, oClienteService.recuperarTodos());
            }
            habilitarCampos(false);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Cliente oCliente = new Cliente();

                oCliente.Cuit = Convert.ToInt64(txtCuit.Text);
                oCliente.Razon_social = txtRazonSocial.Text;
                oCliente.Calle = txtCalle.Text;
                oCliente.Numero = Convert.ToInt32(txtNumero.Text);
                oCliente.Barrio = oBarrioService.recuperarBarrio(cboBarrio.SelectedValue.ToString());
                oCliente.Contacto = oContactoService.recuperarContacto(cboContacto.SelectedValue.ToString());
                oCliente.Fecha_alta = dtpFechaAlta.Value;
                if (nuevo)
                {
                    oClienteService.crearCliente(oCliente);
                    MessageBox.Show("¡Cliente creado con éxito!", "Crear cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oCliente.Id_cliente = Convert.ToInt32(txtId.Text);
                    oClienteService.actualizarCliente(oCliente);
                    MessageBox.Show("¡Cliente actualizado con éxito!", "Actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cargarGrilla(dgvClientes, oClienteService.recuperarTodos());
                habilitarCampos(false);
                this.nuevo = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void actualizarCampos(string idCliente)
        {
            Cliente clienteSeleccionado = oClienteService.recuperarCliente(idCliente);
            if (clienteSeleccionado != null)
            {
                txtId.Text = clienteSeleccionado.Id_cliente.ToString();
                txtCuit.Text = clienteSeleccionado.Cuit.ToString();
                txtRazonSocial.Text = clienteSeleccionado.Razon_social;
                txtCalle.Text = clienteSeleccionado.Calle;
                txtNumero.Text = clienteSeleccionado.Numero.ToString();
                dtpFechaAlta.Value = clienteSeleccionado.Fecha_alta;
                cboBarrio.SelectedValue = clienteSeleccionado.Barrio.Id_barrio;
                cboContacto.SelectedValue = clienteSeleccionado.Contacto.Id_contacto;
            }
            else
                limpiarCampos();
        }
        public bool validarCampos()
        {
            if (txtCuit.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un CUIT.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuit.Focus();
                return false;
            }
            else if (!Int64.TryParse(txtCuit.Text, out long numero))
            {
                MessageBox.Show("Datos ingresados no válidos. El CUIT debe contener sólamente números.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuit.Focus();
                return false;
            }
            if (txtRazonSocial.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar una razón social.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRazonSocial.Focus();
                return false;
            }
            if (txtCalle.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar una calle.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCalle.Focus();
                return false;
            }
            if (txtNumero.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un número de calle.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return false;
            }
            else if (!Int32.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("Datos ingresados no válidos. El número de calle debe contener sólamente números.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return false;
            }
            if (cboBarrio.SelectedIndex == -1)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe seleccionar un barrio.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBarrio.Focus();
                return false;
            }
            if (cboContacto.SelectedIndex == -1)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe seleccionar un contacto.", "Datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboContacto.Focus();
                return false;
            }

            return true;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.actualizarCampos(dgvClientes.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(dgvClientes.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnHabilitarBusqueda_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgvClientes, oClienteService.recuperarTodos());
            btnBuscar.Visible = true;
            habilitarCampos(true);
            txtCuit.Text = "";
            txtRazonSocial.Text = "";
            cboContacto.SelectedIndex = -1;
            cboBarrio.SelectedIndex = -1;
            txtCalle.Text = "";
            txtNumero.Text = "";
            dtpFechaAlta.Value = DateTime.Today;
            btnGuardar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string contacto, barrio;

            if (cboBarrio.SelectedIndex == -1)
                barrio = "-1";
            else
                barrio = cboBarrio.SelectedValue.ToString();
            if (cboContacto.SelectedIndex == -1)
                contacto = "-1";
            else
                contacto = cboContacto.SelectedValue.ToString();

            cargarGrilla(dgvClientes, oClienteService.recuperarClientesFiltro(txtCuit.Text, txtRazonSocial.Text, contacto, barrio,
                txtCalle.Text, txtNumero.Text, dtpFechaAlta.Value));
            dgvClientes.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void frmABMClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void lblCalle_Click(object sender, EventArgs e)
        {

        }
    }
}
