using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using Microsoft.Reporting.WinForms;


namespace ComputerTech.Reportes
{
    public partial class facturaNumero : Form
    {
        private Factura _factura;
        public Factura factura { get => _factura; set => _factura = value; }


        private FacturaService oFacturaServicen = new FacturaService();
        string resultado;
        public Usuario UsuarioActual { get; }
        

        ClienteService oClienteService = new ClienteService();
        ProductoService oProductoService = new ProductoService();
        ProyectoService oProyectoService = new ProyectoService();
        FacturaService oFacturaService = new FacturaService();
        DetalleFacturaService oDetalleFacturaService = new DetalleFacturaService();

        bool flagProducto = false;
        Usuario usuarioActual;
        public facturaNumero(Usuario usuarioActual)
        {
            this.usuarioActual = usuarioActual;
            InitializeComponent();
            // cargarCombo(cboCliente, oClienteService.recuperarTodos(), "razon_social", "id_cliente");
        }


        public facturaNumero()
        {
            InitializeComponent();
        }

        public facturaNumero(Factura factura )
        {
            this.factura = factura;
            InitializeComponent();
        }

        private void frmfacturaNumero_Load(object sender1, EventArgs e1)
        {

            // string res = oFacturaServicen.CrearFactura(resultado);
            // oFacturaServicen.
            //  txtnumero = 
            //this.rvwFacturas.RefreshReport();
        }
        private void cargarCombo(ComboBox combo, Object source, string display, string value)
        {
            combo.DataSource = source;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }


        // load activo
        private void facturaNumero_Load(object sender, EventArgs e)
        {

            this.txtnumero.Text = factura.Numero_factura;
            this.txtTotal.Text = factura.Total.ToString();

            //cargar la grilla con el detalle que esta dentro de la factura
            cargargrilla();

        }



        private void cargargrilla() {

            dgvFactura.DataSource = null;
            dgvFactura.Rows.Clear();

            int fila = 0;
            foreach (var item in factura.Detalles)
            {
                dgvFactura.Rows.Add();
                dgvFactura.Rows[fila].Cells["Orden"].Value = item.Numero_orden.ToString();
                dgvFactura.Rows[fila].Cells["Nombre"].Value = item.Producto.Nombre.ToString();
                //dgvFactura.Rows[fila].Cells["Nombre"].Value = item.Proyecto.Descripcion.ToString();
                dgvFactura.Rows[fila].Cells["Precio"].Value = item.Precio.ToString();
                
                fila++;
            }

        }




        private void frmReporteListadoFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvFactura.Rows.Clear();
            Factura oFactura = new Factura();
            string numeroFactura;
            IList<DetalleFactura> listaDetalles;
            //numeroFactura = txtPuntoDeVenta.Text + "-" + txtNumeroFactura.Text;
            //oFactura = oFacturaServicen.GetFactura(numeroFactura);
            if (oFactura == null)
            {
                MessageBox.Show("No se encontró la factura ingresada.", "Factura no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnumero.Clear();

                return;
                // listaDetalles = oDetalleFacturaServicen.recuperarTodos(oFactura.Id_factura.ToString());

                // cboCliente.Text = oFactura.Cliente.Razon_social;

                // foreach (DetalleFactura detalle in listaDetalles)
                // {
                //    dgvFactura.Rows.Add((detalle.Producto != null) ? detalle.Producto.Id_producto : detalle.Proyecto.Id_proyecto,
                //                         (detalle.Producto != null) ? detalle.Producto.Nombre : detalle.Proyecto.Descripcion,
                //                          detalle.Cantidad,
                //                          detalle.Precio,
                //                         (detalle.Cantidad * detalle.Precio),
                //                         (detalle.Producto != null) ? true : false);
                //  }
                // txtTotal.Text = oFactura.Total.ToString();
                // habilitarCampos(true);
                //  }

                // private void txtNumeroFactura_Leave(object sender, EventArgs e)
                // {
                //  txtNumeroFactura.Text = txtNumeroFactura.Text.PadLeft(6, '0');
                //  }

            }
        }
    }

}