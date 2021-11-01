namespace ComputerTech.Reportes
{
    partial class frmEstadisticaGraficoFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadisticaGraficoFactura));
            this.bugsExtendidoDataSetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bugsExtendidoDataSet = new ComputerTech.BugsExtendidoDataSet();
            this.bugsExtendidoDataSetBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bugsExtendidoDataSetBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.bugsExtendidoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvGraficoFacturas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bugsExtendidoDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bugsExtendidoDataSetBindingSource2
            // 
            this.bugsExtendidoDataSetBindingSource2.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource2.Position = 0;
            // 
            // bugsExtendidoDataSet
            // 
            this.bugsExtendidoDataSet.DataSetName = "BugsExtendidoDataSet";
            this.bugsExtendidoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bugsExtendidoDataSetBindingSource3
            // 
            this.bugsExtendidoDataSetBindingSource3.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource3.Position = 0;
            // 
            // bugsExtendidoDataSetBindingSource4
            // 
            this.bugsExtendidoDataSetBindingSource4.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource4.Position = 0;
            // 
            // bugsExtendidoDataSetBindingSource
            // 
            this.bugsExtendidoDataSetBindingSource.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource.Position = 0;
            // 
            // rpvGraficoFacturas
            // 
            reportDataSource1.Name = "GraficoFacturas";
            reportDataSource1.Value = this.bugsExtendidoDataSetBindingSource2;
            reportDataSource2.Name = "GraficoFacturasPorMes";
            reportDataSource2.Value = this.bugsExtendidoDataSetBindingSource3;
            reportDataSource3.Name = "GraficoFacturasTotal";
            reportDataSource3.Value = this.bugsExtendidoDataSetBindingSource4;
            this.rpvGraficoFacturas.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvGraficoFacturas.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvGraficoFacturas.LocalReport.DataSources.Add(reportDataSource3);
            this.rpvGraficoFacturas.LocalReport.ReportEmbeddedResource = "ComputerTech.Reportes.ReporteGraficoFactura.rdlc";
            this.rpvGraficoFacturas.Location = new System.Drawing.Point(0, 57);
            this.rpvGraficoFacturas.Name = "rpvGraficoFacturas";
            this.rpvGraficoFacturas.ServerReport.BearerToken = null;
            this.rpvGraficoFacturas.Size = new System.Drawing.Size(1096, 692);
            this.rpvGraficoFacturas.TabIndex = 0;
            // 
            // bugsExtendidoDataSetBindingSource1
            // 
            this.bugsExtendidoDataSetBindingSource1.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource1.Position = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::ComputerTech.Properties.Resources.Search;
            this.btnBuscar.Location = new System.Drawing.Point(791, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 36);
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(625, 15);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(124, 31);
            this.dtpFechaHasta.TabIndex = 49;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaHasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.White;
            this.lblFechaHasta.Location = new System.Drawing.Point(497, 20);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(110, 23);
            this.lblFechaHasta.TabIndex = 48;
            this.lblFechaHasta.Text = "Fecha Hasta:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(356, 15);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(124, 31);
            this.dtpFechaDesde.TabIndex = 47;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaDesde.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.White;
            this.lblFechaDesde.Location = new System.Drawing.Point(230, 20);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(113, 23);
            this.lblFechaDesde.TabIndex = 46;
            this.lblFechaDesde.Text = "Fecha desde:";
            // 
            // frmEstadisticaGraficoFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1096, 749);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.rpvGraficoFacturas);
            this.MaximumSize = new System.Drawing.Size(1112, 788);
            this.MinimumSize = new System.Drawing.Size(1112, 726);
            this.Name = "frmEstadisticaGraficoFactura";
            this.Text = "Estadísticas de Facturas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEstadisticaGraficoFactura_FormClosing);
            this.Load += new System.EventHandler(this.frmEstadisticaGraficoFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvGraficoFacturas;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource;
        private BugsExtendidoDataSet bugsExtendidoDataSet;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource2;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource1;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource3;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
    }
}