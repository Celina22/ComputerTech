using ComputerTech.BusinessLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerTech.Reportes
{
    public partial class frmEstadisticaGraficoCliente : Form
    {
        private ClienteService oClienteService = new ClienteService();
        private FacturaService oFacturaService = new FacturaService();

        public frmEstadisticaGraficoCliente()
        {
            InitializeComponent();
        }

        private void frmEstadisticaGraficoCliente_Load(object sender, EventArgs e)
        {

            this.rvwGraficosClientes.RefreshReport();
            this.BackColor = Color.FromArgb(137, 2, 62);
            lblFechaDesde.ForeColor = Color.White;
            lblFechaHasta.ForeColor = Color.White;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            DataTable tabla2 = new DataTable();
            tabla = oClienteService.recuperarClientes(dtpFechaDesde.Value, dtpFechaHasta.Value);
            tabla2 = oClienteService.recuperar5ClientesMasFacturados(dtpFechaDesde.Value, dtpFechaHasta.Value);

            ReportDataSource ds = new ReportDataSource("GraficoClientes", tabla);
            ReportDataSource ds2 = new ReportDataSource("GraficoFacturasClientes", tabla2);

            rvwGraficosClientes.LocalReport.DataSources.Clear();
            rvwGraficosClientes.LocalReport.DataSources.Add(ds);
            rvwGraficosClientes.LocalReport.DataSources.Add(ds2);
            rvwGraficosClientes.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("prmFechaDesde", dtpFechaDesde.Value.ToShortDateString()),
                                                                            new ReportParameter("prmFechaHasta", dtpFechaHasta.Value.ToShortDateString())});
            rvwGraficosClientes.RefreshReport();

        }

        private void frmEstadisticaGraficoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
