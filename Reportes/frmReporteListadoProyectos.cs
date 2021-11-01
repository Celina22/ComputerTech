using ComputerTech.BusinessLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ComputerTech.Reportes
{
    public partial class frmReporteListadoProyectos : Form
    {
        ProyectoService oProyectoService = new ProyectoService();
        ProductoService oProductoService = new ProductoService();
        UsuarioService oUsuarioService = new UsuarioService();

        public frmReporteListadoProyectos()
        {
            InitializeComponent();
        }

        private void frmReporteListadoProyectos_Load(object sender, EventArgs e)
        {
            cargarCombo(cboProducto, oProductoService.recuperarTodos(), "Nombre", "Id_producto");
            cargarCombo(cboResponsable, oUsuarioService.recuperarTodos(), "NombreUsuario", "IdUsuario");
            this.rvwProyectos.RefreshReport();
        }

        private void rvwProyectos_Load(object sender, EventArgs e)
        {

        }

        private void cargarCombo(ComboBox combo, Object source, string display, string value)
        {
            combo.DataSource = source;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var descripcion = txtDescripcion.Text;
            string producto;
            if (cboProducto.SelectedIndex == -1)
                producto = "-1";
            else
                producto = cboProducto.SelectedValue.ToString();
            string responsable;
            if (cboResponsable.SelectedIndex == -1)
                responsable = "-1";
            else
                responsable = cboResponsable.SelectedValue.ToString();
            var alcance = txtAlcance.Text;
            var version = txtVersion.Text;

            DataTable tabla = new DataTable();
            tabla = oProyectoService.recuperarProyectos(descripcion, producto, responsable, alcance, version, dtpFechaDesde.Value, dtpFechaHasta.Value);


            ReportDataSource ds = new ReportDataSource("ListadoProyectos", tabla);

            rvwProyectos.LocalReport.DataSources.Clear();
            rvwProyectos.LocalReport.DataSources.Add(ds);
            rvwProyectos.LocalReport.Refresh();
            rvwProyectos.RefreshReport();
        }

        private void frmReporteListadoProyectos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
