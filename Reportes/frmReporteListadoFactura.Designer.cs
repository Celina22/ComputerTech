namespace ComputerTech.Reportes
{
    partial class frmReporteListadoFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteListadoFactura));
            this.bugsExtendidoDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bugsExtendidoDataSet = new ComputerTech.BugsExtendidoDataSet();
            this.rvwFacturas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMontoMayor = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.bugsExtendidoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bugsExtendidoDataSetBindingSource1
            // 
            this.bugsExtendidoDataSetBindingSource1.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource1.Position = 0;
            // 
            // bugsExtendidoDataSet
            // 
            this.bugsExtendidoDataSet.DataSetName = "BugsExtendidoDataSet";
            this.bugsExtendidoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvwFacturas
            // 
            reportDataSource1.Name = "ListadoFactura";
            reportDataSource1.Value = this.bugsExtendidoDataSetBindingSource1;
            this.rvwFacturas.LocalReport.DataSources.Add(reportDataSource1);
            this.rvwFacturas.LocalReport.ReportEmbeddedResource = "ComputerTech.Reportes.ReporteListadoFactura.rdlc";
            this.rvwFacturas.Location = new System.Drawing.Point(2, 55);
            this.rvwFacturas.Name = "rvwFacturas";
            this.rvwFacturas.ServerReport.BearerToken = null;
            this.rvwFacturas.Size = new System.Drawing.Size(1185, 390);
            this.rvwFacturas.TabIndex = 0;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(393, 13);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(124, 31);
            this.dtpFechaHasta.TabIndex = 37;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaHasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.White;
            this.lblFechaHasta.Location = new System.Drawing.Point(265, 18);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(110, 23);
            this.lblFechaHasta.TabIndex = 36;
            this.lblFechaHasta.Text = "Fecha Hasta:";
            // 
            // cboCliente
            // 
            this.cboCliente.BackColor = System.Drawing.Color.White;
            this.cboCliente.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(626, 13);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(191, 31);
            this.cboCliente.TabIndex = 35;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCliente.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCliente.ForeColor = System.Drawing.Color.DimGray;
            this.lblCliente.Location = new System.Drawing.Point(548, 18);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(72, 23);
            this.lblCliente.TabIndex = 34;
            this.lblCliente.Text = "Cliente:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(235)))), ((int)(((byte)(237)))));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(124, 13);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(124, 31);
            this.dtpFechaDesde.TabIndex = 33;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaDesde.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.White;
            this.lblFechaDesde.Location = new System.Drawing.Point(-2, 18);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(113, 23);
            this.lblFechaDesde.TabIndex = 32;
            this.lblFechaDesde.Text = "Fecha desde:";
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtMonto.Location = new System.Drawing.Point(990, 13);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 31);
            this.txtMonto.TabIndex = 39;
            // 
            // lblMontoMayor
            // 
            this.lblMontoMayor.AutoSize = true;
            this.lblMontoMayor.BackColor = System.Drawing.Color.Transparent;
            this.lblMontoMayor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblMontoMayor.ForeColor = System.Drawing.Color.White;
            this.lblMontoMayor.Location = new System.Drawing.Point(838, 16);
            this.lblMontoMayor.Name = "lblMontoMayor";
            this.lblMontoMayor.Size = new System.Drawing.Size(136, 23);
            this.lblMontoMayor.TabIndex = 38;
            this.lblMontoMayor.Text = "Monto mayor a:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::ComputerTech.Properties.Resources.Search;
            this.btnBuscar.Location = new System.Drawing.Point(1112, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 46);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // bugsExtendidoDataSetBindingSource
            // 
            this.bugsExtendidoDataSetBindingSource.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource.Position = 0;
            // 
            // frmReporteListadoFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1189, 450);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMontoMayor);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.rvwFacturas);
            this.Name = "frmReporteListadoFactura";
            this.Text = "Listado de Facturas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteListadoFactura_FormClosing);
            this.Load += new System.EventHandler(this.frmReporteListadoFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvwFacturas;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblMontoMayor;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource;
        private BugsExtendidoDataSet bugsExtendidoDataSet;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource1;
    }
}