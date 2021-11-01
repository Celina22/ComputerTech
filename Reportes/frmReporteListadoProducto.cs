using ComputerTech.BusinessLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ComputerTech.Reportes
{
    public partial class frmReporteListadoProducto : Form
    {
        private ProductoService oProductoService = new ProductoService();
        public frmReporteListadoProducto()
        {
            InitializeComponent();
        }

        private void frmReporteListadoProducto_Load(object sender, EventArgs e)
        {

            this.rvwProductos.RefreshReport();
        }

        private void cargarCombo(ComboBox combo, Object source, string display, string value)
        {
            combo.DataSource = source;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string nombre;
            if (txtNombre.Text == string.Empty)
                nombre = "-1";
            else
                nombre = txtNombre.Text;
            DataTable tabla = new DataTable();
            tabla = oProductoService.recuperarProductos(dtpFechaDesde.Value, dtpFechaHasta.Value, nombre);

            ReportDataSource ds = new ReportDataSource("ListadoProductos", tabla);

            rvwProductos.LocalReport.DataSources.Clear();
            rvwProductos.LocalReport.DataSources.Add(ds);
            rvwProductos.LocalReport.Refresh();
            rvwProductos.RefreshReport();
        }

        private void frmReporteListadoProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
