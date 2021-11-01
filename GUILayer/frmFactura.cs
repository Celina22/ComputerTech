using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerTech.GUILayer
{
    public partial class frmFactura : Form
    {
        ClienteService oClienteService = new ClienteService();
        ProductoService oProductoService = new ProductoService();
        ProyectoService oProyectoService = new ProyectoService();
        FacturaService oFacturaService = new FacturaService();
        DetalleFacturaService oDetalleFacturaService = new DetalleFacturaService();

        bool flagProducto = false;
        Usuario usuarioActual;
        public frmFactura(Usuario usuarioActual)
        {
            this.usuarioActual = usuarioActual;
            InitializeComponent();
            cargarCombo(cboCliente, oClienteService.recuperarTodos(), "razon_social", "id_cliente");
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            rdbProyecto.Checked = true;
            cboCliente.Focus();
            cboCliente.DropDownHeight = 100;
            dgvDetalles.DefaultCellStyle.SelectionBackColor = Color.Thistle;
            dgvDetalles.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDetalles.RowHeadersDefaultCellStyle.BackColor = Color.Thistle;
            dgvDetalles.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Thistle;
            dgvDetalles.ForeColor = Color.Black;
        }

        private void cargarCombo(ComboBox combo, Object source, string display, string value)
        {
            combo.DataSource = source;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void rdbProducto_CheckedChanged(object sender, EventArgs e)
        {
            limpiarCampos();
            flagProducto = true;
            lblDetalle.Text = "Producto:";
            lblValor.Text = "Precio:";
            lblProporcion.Text = "Cantidad:";
            cargarCombo(cboDetalle, oProductoService.recuperarTodos(), "nombre", "id_producto");

        }

        private void rdbProyecto_CheckedChanged(object sender, EventArgs e)
        {
            limpiarCampos();
            flagProducto = false;
            lblDetalle.Text = "Proyecto:";
            lblValor.Text = "Costo/Hora:";
            lblProporcion.Text = "Horas:";
            cargarCombo(cboDetalle, oProyectoService.recuperarTodos(), "descripcion", "id_proyecto");
        }

        private void limpiarCampos()
        {
            txtValor.Text = txtProporcion.Text = txtSubtotal.Text = string.Empty;
            cboDetalle.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                dgvDetalles.Rows.Add(cboDetalle.SelectedValue.ToString(),
                                     cboDetalle.Text.ToString(),
                                     txtProporcion.Text.ToString(),
                                     txtValor.Text.ToString(),
                                     txtSubtotal.Text.ToString(),
                                     flagProducto ? true : false);

                limpiarCampos();
                rdbProducto.Focus();
                calcularTotal();

            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validarCampos()
        {

            if (cboDetalle.SelectedIndex == -1)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe seleccionar un producto o proyecto.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDetalle.Focus();
                return false;
            }
            if (txtValor.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un valor del producto o proyecto.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValor.Focus();
                return false;
            }

            if (!Double.TryParse(txtValor.Text, out double valor))
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un valor correcto del producto o proyecto.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValor.Focus();
                return false;
            }

            if (Convert.ToDouble(txtValor.Text) <= 0)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un valor positivo del producto o proyecto.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValor.Focus();
                return false;
            }

            if (txtProporcion.Text == string.Empty)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar una cantidad a facturar.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProporcion.Focus();
                return false;
            }

            if (!Double.TryParse(txtProporcion.Text, out double proporcion))
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar una cantidad correcta a facturar.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValor.Focus();
                return false;
            }

            if (Convert.ToDouble(txtProporcion.Text) <= 0)
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar una cantidad positiva a facturar.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProporcion.Focus();
                return false;
            }

            return true;
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            calcularSubtotal();
        }

        private void calcularSubtotal()
        {
            if (txtProporcion.Text != string.Empty && txtValor.Text != string.Empty)
            {
                int numero;
                if (Int32.TryParse(txtValor.Text, out numero) && Int32.TryParse(txtProporcion.Text, out numero))
                {
                    double valor = Convert.ToDouble(txtValor.Text);
                    double proporcion = Convert.ToDouble(txtProporcion.Text);
                    double subtotal = valor * proporcion;
                    txtSubtotal.Text = subtotal.ToString();
                }
            }
        }

        private void txtProporcion_Leave(object sender, EventArgs e)
        {
            calcularSubtotal();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCliente())
            {
                Factura factura = new Factura();
                DetalleFactura detalle;
                for (int i = 0; i < dgvDetalles.Rows.Count; i++)
                {
                    detalle = new DetalleFactura();
                    detalle.Numero_orden = i + 1;
                    if ((bool)dgvDetalles.Rows[i].Cells["esProducto"].Value)
                        detalle.Producto = oProductoService.recuperarProducto(dgvDetalles.Rows[i].Cells["id"].Value.ToString());
                    else
                        detalle.Proyecto = oProyectoService.recuperarProyecto(dgvDetalles.Rows[i].Cells["id"].Value.ToString());
                    detalle.Precio = Convert.ToDouble(dgvDetalles.Rows[i].Cells["precio"].Value);
                    detalle.Cantidad = Convert.ToInt32(dgvDetalles.Rows[i].Cells["cantidad"].Value);
                    factura.Detalles.Add(detalle);
                }

                factura.Cliente = oClienteService.recuperarCliente(cboCliente.SelectedValue.ToString());
                factura.Fecha = dtpFechaFactura.Value;
                factura.Usuario_creador = usuarioActual;
                factura.Total = Convert.ToSingle(txtTotal.Text);
                string resultado = oFacturaService.CrearFactura(factura);
                if (resultado.Length > 0)
                {
                    MessageBox.Show("La factura se ha registrado con éxito. Número de factura:" + resultado, "Registrar factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDetalles.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("La factura no se ha podido registrar correctamente.", "Registrar factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTotal.Clear();

        }

        private bool validarCliente()
        {
            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Datos de factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus();
                return false;
            }
            return true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (this.dgvDetalles.SelectedCells.Count > 0)
            {
                dgvDetalles.Rows.RemoveAt(this.dgvDetalles.SelectedRows[0].Index);
                calcularTotal();
            }
        }

        private void calcularTotal()
        {
            double ac = 0;
            for (int i = 0; i < dgvDetalles.Rows.Count; i++)
            {
                ac += Convert.ToDouble(dgvDetalles.Rows[i].Cells["subtotal"].Value);
            }
            txtTotal.Text = ac.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtPuntoDeVenta.Text = "001";
            txtNumeroFactura.Enabled = true;
            btnBuscar.Visible = true;
            habilitarCampos(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDetalles.Rows.Clear();
            Factura oFactura = new Factura();
            string numeroFactura;
            IList<DetalleFactura> listaDetalles;
            numeroFactura = txtPuntoDeVenta.Text + "-" + txtNumeroFactura.Text;
            oFactura = oFacturaService.GetFactura(numeroFactura);
            if (oFactura == null)
            {
                MessageBox.Show("No se encontró la factura ingresada.", "Factura no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroFactura.Clear();
                txtPuntoDeVenta.Clear();
                return;
            }
            listaDetalles = oDetalleFacturaService.recuperarTodos(oFactura.Id_factura.ToString());

            cboCliente.Text = oFactura.Cliente.Razon_social;

            foreach (DetalleFactura detalle in listaDetalles)
            {
                dgvDetalles.Rows.Add((detalle.Producto != null) ? detalle.Producto.Id_producto : detalle.Proyecto.Id_proyecto,
                                     (detalle.Producto != null) ? detalle.Producto.Nombre : detalle.Proyecto.Descripcion,
                                     detalle.Cantidad,
                                     detalle.Precio,
                                     (detalle.Cantidad * detalle.Precio),
                                     (detalle.Producto != null) ? true : false);
            }
            txtTotal.Text = oFactura.Total.ToString();
            habilitarCampos(true);
        }

        private void txtNumeroFactura_Leave(object sender, EventArgs e)
        {
            txtNumeroFactura.Text = txtNumeroFactura.Text.PadLeft(6, '0');
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere crear una nueva factura?", "Registrar factura",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                limpiarCampos();
                dgvDetalles.Rows.Clear();
                txtNumeroFactura.Clear();
                txtPuntoDeVenta.Clear();
                txtNumeroFactura.Enabled = false;
                btnBuscar.Visible = false;
                habilitarCampos(true);
            }
        }

        private void habilitarCampos(bool valor)
        {
            cboCliente.Enabled = valor;
            rdbProducto.Enabled = rdbProyecto.Enabled = valor;
            cboDetalle.Enabled = valor;
            txtProporcion.Enabled = txtValor.Enabled = valor;
            dgvDetalles.Enabled = valor;
            btnAgregar.Enabled = btnQuitar.Enabled = valor;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void txtPuntoDeVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPuntoDeVenta_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
