using ComputerTech.BusinessLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ComputerTech.Reportes
{
    public partial class frmEstadisticaGraficoFactura : Form
    {
        private FacturaService oFacturaService = new FacturaService();
        public frmEstadisticaGraficoFactura()
        {
            InitializeComponent();
        }

        private void frmEstadisticaGraficoFactura_Load(object sender, EventArgs e)
        {
            this.rpvGraficoFacturas.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            DataTable tabla = new DataTable();
            tabla = oFacturaService.recuperarTodas(dtpFechaDesde.Value, dtpFechaHasta.Value);

            DataTable tabla1 = new DataTable();
            tabla1 = oFacturaService.recuperarTodasPorMes(dtpFechaDesde.Value, dtpFechaHasta.Value);

            DataTable tabla2 = new DataTable();
            tabla2 = oFacturaService.recuperarTodasTotal(dtpFechaDesde.Value, dtpFechaHasta.Value);

            ReportDataSource ds = new ReportDataSource("GraficoFacturas", tabla);
            ReportDataSource ds1 = new ReportDataSource("GraficoFacturasPorMes", tabla1);
            ReportDataSource ds2 = new ReportDataSource("GraficoFacturasTotal", tabla2);


            rpvGraficoFacturas.LocalReport.DataSources.Clear();
            rpvGraficoFacturas.LocalReport.DataSources.Add(ds);
            rpvGraficoFacturas.LocalReport.DataSources.Add(ds1);
            rpvGraficoFacturas.LocalReport.DataSources.Add(ds2);
            rpvGraficoFacturas.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("prmFechaDesde", dtpFechaDesde.Value.ToShortDateString()),
                                                                            new ReportParameter("prmFechaHasta", dtpFechaHasta.Value.ToShortDateString())});
            rpvGraficoFacturas.RefreshReport();

        }

        private void frmEstadisticaGraficoFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
