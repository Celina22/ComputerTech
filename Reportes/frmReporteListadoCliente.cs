using ComputerTech.BusinessLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ComputerTech.Reportes
{
    public partial class frmReporteListadoCliente : Form
    {
        ClienteService oCLienteService = new ClienteService();
        BarrioService oBarrioService = new BarrioService();
        public frmReporteListadoCliente()
        {
            InitializeComponent();
        }

        private void frmReporteListadoCliente_Load(object sender, EventArgs e)
        {
            cargarCombo(cboBarrio, oBarrioService.recuperarTodos(), "Nombre", "Id_barrio");
            this.rpvCliente.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

            /*DataTable tabla = new DataTable();
            tabla = oCLienteService.recuperarClientes();

            ReportDataSource ds = new ReportDataSource("ListadoClientes", tabla);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds);t
            reportViewer1.LocalReport.Refresh();*/


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
            string barrio;
            if (cboBarrio.SelectedIndex == -1)
                barrio = "-1";
            else
                barrio = cboBarrio.SelectedValue.ToString();
            DataTable tabla = new DataTable();
            tabla = oCLienteService.recuperarClientes(dtpFechaDesde.Value, dtpFechaHasta.Value, barrio);

            ReportDataSource ds = new ReportDataSource("ListadoClientes", tabla);

            rpvCliente.LocalReport.DataSources.Clear();
            rpvCliente.LocalReport.DataSources.Add(ds);
            rpvCliente.RefreshReport();
        }

        private void frmReporteListadoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
