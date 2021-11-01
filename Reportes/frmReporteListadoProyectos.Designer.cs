namespace ComputerTech.Reportes
{
    partial class frmReporteListadoProyectos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteListadoProyectos));
            this.bugsExtendidoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bugsExtendidoDataSet = new ComputerTech.BugsExtendidoDataSet();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cboResponsable = new System.Windows.Forms.ComboBox();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.txtAlcance = new System.Windows.Forms.TextBox();
            this.lblAlcance = new System.Windows.Forms.Label();
            this.rvwProyectos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.tltReporteProyectos = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSet)).BeginInit();
            this.grbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // bugsExtendidoDataSetBindingSource
            // 
            this.bugsExtendidoDataSetBindingSource.DataSource = this.bugsExtendidoDataSet;
            this.bugsExtendidoDataSetBindingSource.Position = 0;
            // 
            // bugsExtendidoDataSet
            // 
            this.bugsExtendidoDataSet.DataSetName = "BugsExtendidoDataSet";
            this.bugsExtendidoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::ComputerTech.Properties.Resources.Search;
            this.btnBuscar.Location = new System.Drawing.Point(855, 76);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 34);
            this.btnBuscar.TabIndex = 36;
            this.tltReporteProyectos.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtVersion.Location = new System.Drawing.Point(822, 23);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(105, 31);
            this.txtVersion.TabIndex = 38;
            this.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tltReporteProyectos.SetToolTip(this.txtVersion, "Ingrese la versión o parte de la versión a utilizar como filtro.");
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Gainsboro;
            this.lblVersion.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(741, 26);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(75, 23);
            this.lblVersion.TabIndex = 37;
            this.lblVersion.Text = "Versión:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtDescripcion.Location = new System.Drawing.Point(143, 23);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(232, 31);
            this.txtDescripcion.TabIndex = 40;
            this.tltReporteProyectos.SetToolTip(this.txtDescripcion, "Ingrese la descripción o parte de la descripción a utilizar de filtro.");
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDescripcion.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(29, 26);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(108, 23);
            this.lblDescripcion.TabIndex = 39;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // cboProducto
            // 
            this.cboProducto.BackColor = System.Drawing.Color.White;
            this.cboProducto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(143, 60);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(232, 31);
            this.cboProducto.TabIndex = 42;
            this.tltReporteProyectos.SetToolTip(this.cboProducto, "Seleccione un producto a utilizar de filtro.");
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.Gainsboro;
            this.lblProducto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.White;
            this.lblProducto.Location = new System.Drawing.Point(50, 63);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(87, 23);
            this.lblProducto.TabIndex = 41;
            this.lblProducto.Text = "Producto:";
            // 
            // cboResponsable
            // 
            this.cboResponsable.BackColor = System.Drawing.Color.White;
            this.cboResponsable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboResponsable.FormattingEnabled = true;
            this.cboResponsable.Location = new System.Drawing.Point(503, 23);
            this.cboResponsable.Name = "cboResponsable";
            this.cboResponsable.Size = new System.Drawing.Size(232, 31);
            this.cboResponsable.TabIndex = 44;
            this.tltReporteProyectos.SetToolTip(this.cboResponsable, "Seleccione un usuario responsable a utilizar como filtro.");
            // 
            // lblResponsable
            // 
            this.lblResponsable.AutoSize = true;
            this.lblResponsable.BackColor = System.Drawing.Color.Gainsboro;
            this.lblResponsable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblResponsable.ForeColor = System.Drawing.Color.White;
            this.lblResponsable.Location = new System.Drawing.Point(381, 26);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(116, 23);
            this.lblResponsable.TabIndex = 43;
            this.lblResponsable.Text = "Responsable:";
            // 
            // txtAlcance
            // 
            this.txtAlcance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtAlcance.Location = new System.Drawing.Point(503, 60);
            this.txtAlcance.Name = "txtAlcance";
            this.txtAlcance.Size = new System.Drawing.Size(232, 31);
            this.txtAlcance.TabIndex = 46;
            this.txtAlcance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tltReporteProyectos.SetToolTip(this.txtAlcance, "Ingrese el alcance o parte del alcance a utilizar de filtro.");
            // 
            // lblAlcance
            // 
            this.lblAlcance.AutoSize = true;
            this.lblAlcance.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAlcance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAlcance.ForeColor = System.Drawing.Color.White;
            this.lblAlcance.Location = new System.Drawing.Point(420, 63);
            this.lblAlcance.Name = "lblAlcance";
            this.lblAlcance.Size = new System.Drawing.Size(77, 23);
            this.lblAlcance.TabIndex = 45;
            this.lblAlcance.Text = "Alcance:";
            // 
            // rvwProyectos
            // 
            this.rvwProyectos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            reportDataSource1.Name = "ListadoProyectos";
            reportDataSource1.Value = this.bugsExtendidoDataSetBindingSource;
            this.rvwProyectos.LocalReport.DataSources.Add(reportDataSource1);
            this.rvwProyectos.LocalReport.ReportEmbeddedResource = "ComputerTech.Reportes.ReporteListadoProyectos.rdlc";
            this.rvwProyectos.Location = new System.Drawing.Point(11, 160);
            this.rvwProyectos.Margin = new System.Windows.Forms.Padding(2);
            this.rvwProyectos.Name = "rvwProyectos";
            this.rvwProyectos.ServerReport.BearerToken = null;
            this.rvwProyectos.Size = new System.Drawing.Size(1030, 478);
            this.rvwProyectos.TabIndex = 47;
            this.rvwProyectos.Load += new System.EventHandler(this.rvwProyectos_Load);
            // 
            // grbFiltros
            // 
            this.grbFiltros.BackColor = System.Drawing.Color.DarkMagenta;
            this.grbFiltros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbFiltros.BackgroundImage")));
            this.grbFiltros.Controls.Add(this.dtpFechaHasta);
            this.grbFiltros.Controls.Add(this.dtpFechaDesde);
            this.grbFiltros.Controls.Add(this.lblFechaHasta);
            this.grbFiltros.Controls.Add(this.lblFechaDesde);
            this.grbFiltros.Controls.Add(this.cboResponsable);
            this.grbFiltros.Controls.Add(this.lblVersion);
            this.grbFiltros.Controls.Add(this.btnBuscar);
            this.grbFiltros.Controls.Add(this.txtAlcance);
            this.grbFiltros.Controls.Add(this.txtVersion);
            this.grbFiltros.Controls.Add(this.lblAlcance);
            this.grbFiltros.Controls.Add(this.lblDescripcion);
            this.grbFiltros.Controls.Add(this.txtDescripcion);
            this.grbFiltros.Controls.Add(this.lblResponsable);
            this.grbFiltros.Controls.Add(this.lblProducto);
            this.grbFiltros.Controls.Add(this.cboProducto);
            this.grbFiltros.ForeColor = System.Drawing.Color.White;
            this.grbFiltros.Location = new System.Drawing.Point(11, 12);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(1029, 143);
            this.grbFiltros.TabIndex = 48;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Filtros de Listado";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(503, 99);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(232, 31);
            this.dtpFechaHasta.TabIndex = 50;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(143, 99);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(232, 31);
            this.dtpFechaDesde.TabIndex = 49;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.BackColor = System.Drawing.Color.Gainsboro;
            this.lblFechaHasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.White;
            this.lblFechaHasta.Location = new System.Drawing.Point(391, 103);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(106, 23);
            this.lblFechaHasta.TabIndex = 48;
            this.lblFechaHasta.Text = "FechaHasta:";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.BackColor = System.Drawing.Color.Gainsboro;
            this.lblFechaDesde.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.White;
            this.lblFechaDesde.Location = new System.Drawing.Point(22, 103);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(115, 23);
            this.lblFechaDesde.TabIndex = 47;
            this.lblFechaDesde.Text = "FechaDesde: ";
            // 
            // tltReporteProyectos
            // 
            this.tltReporteProyectos.AutoPopDelay = 2000;
            this.tltReporteProyectos.InitialDelay = 250;
            this.tltReporteProyectos.IsBalloon = true;
            this.tltReporteProyectos.ReshowDelay = 100;
            // 
            // frmReporteListadoProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1052, 649);
            this.Controls.Add(this.grbFiltros);
            this.Controls.Add(this.rvwProyectos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteListadoProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de Proyectos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteListadoProyectos_FormClosing);
            this.Load += new System.EventHandler(this.frmReporteListadoProyectos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugsExtendidoDataSet)).EndInit();
            this.grbFiltros.ResumeLayout(false);
            this.grbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cboResponsable;
        private System.Windows.Forms.Label lblResponsable;
        private System.Windows.Forms.TextBox txtAlcance;
        private System.Windows.Forms.Label lblAlcance;
        private Microsoft.Reporting.WinForms.ReportViewer rvwProyectos;
        private System.Windows.Forms.BindingSource bugsExtendidoDataSetBindingSource;
        private BugsExtendidoDataSet bugsExtendidoDataSet;
        private System.Windows.Forms.GroupBox grbFiltros;
        private System.Windows.Forms.ToolTip tltReporteProyectos;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblFechaDesde;
    }
}