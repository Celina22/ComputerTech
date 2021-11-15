namespace ComputerTech.GUILayer
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.soporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeProyectosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoDeFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gráficoDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gráficosDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gráficosDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.menuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soporteToolStripMenuItem,
            this.facturaToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1827, 28);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            this.menuPrincipal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuPrincipal_ItemClicked);
            // 
            // soporteToolStripMenuItem
            // 
            this.soporteToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.soporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.barriosToolStripMenuItem,
            this.contactosToolStripMenuItem,
            this.proyectosToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.soporteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.soporteToolStripMenuItem.Name = "soporteToolStripMenuItem";
            this.soporteToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.soporteToolStripMenuItem.Text = "Soporte";
            this.soporteToolStripMenuItem.Click += new System.EventHandler(this.soporteToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // barriosToolStripMenuItem
            // 
            this.barriosToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.barriosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.barriosToolStripMenuItem.Name = "barriosToolStripMenuItem";
            this.barriosToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.barriosToolStripMenuItem.Text = "Barrios";
            this.barriosToolStripMenuItem.Click += new System.EventHandler(this.barriosToolStripMenuItem_Click);
            // 
            // contactosToolStripMenuItem
            // 
            this.contactosToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.contactosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.contactosToolStripMenuItem.Name = "contactosToolStripMenuItem";
            this.contactosToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.contactosToolStripMenuItem.Text = "Contactos";
            this.contactosToolStripMenuItem.Click += new System.EventHandler(this.contactosToolStripMenuItem_Click);
            // 
            // proyectosToolStripMenuItem
            // 
            this.proyectosToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.proyectosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.proyectosToolStripMenuItem.Name = "proyectosToolStripMenuItem";
            this.proyectosToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.proyectosToolStripMenuItem.Text = "Proyectos";
            this.proyectosToolStripMenuItem.Click += new System.EventHandler(this.proyectosToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.productosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.usuarioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // facturaToolStripMenuItem
            // 
            this.facturaToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.facturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaFacturaToolStripMenuItem});
            this.facturaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            this.facturaToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.facturaToolStripMenuItem.Text = "Facturacion";
            // 
            // nuevaFacturaToolStripMenuItem
            // 
            this.nuevaFacturaToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.nuevaFacturaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.nuevaFacturaToolStripMenuItem.Name = "nuevaFacturaToolStripMenuItem";
            this.nuevaFacturaToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.nuevaFacturaToolStripMenuItem.Text = "Nueva Factura";
            this.nuevaFacturaToolStripMenuItem.Click += new System.EventHandler(this.nuevaFacturaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeClientesToolStripMenuItem,
            this.listadoDeProductosToolStripMenuItem,
            this.listadoDeProyectosToolStripMenuItem,
            this.listadoDeFacturasToolStripMenuItem});
            this.reportesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // listadoDeClientesToolStripMenuItem
            // 
            this.listadoDeClientesToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.listadoDeClientesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listadoDeClientesToolStripMenuItem.Name = "listadoDeClientesToolStripMenuItem";
            this.listadoDeClientesToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.listadoDeClientesToolStripMenuItem.Text = "Listado de Clientes";
            this.listadoDeClientesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeClientesToolStripMenuItem_Click);
            // 
            // listadoDeProductosToolStripMenuItem
            // 
            this.listadoDeProductosToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.listadoDeProductosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listadoDeProductosToolStripMenuItem.Name = "listadoDeProductosToolStripMenuItem";
            this.listadoDeProductosToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.listadoDeProductosToolStripMenuItem.Text = "Listado de Productos";
            this.listadoDeProductosToolStripMenuItem.Click += new System.EventHandler(this.listadoDeProductosToolStripMenuItem_Click);
            // 
            // listadoDeProyectosToolStripMenuItem
            // 
            this.listadoDeProyectosToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.listadoDeProyectosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listadoDeProyectosToolStripMenuItem.Name = "listadoDeProyectosToolStripMenuItem";
            this.listadoDeProyectosToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.listadoDeProyectosToolStripMenuItem.Text = "Listado de Proyectos";
            this.listadoDeProyectosToolStripMenuItem.Click += new System.EventHandler(this.listadoDeProyectosToolStripMenuItem_Click);
            // 
            // listadoDeFacturasToolStripMenuItem
            // 
            this.listadoDeFacturasToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.listadoDeFacturasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listadoDeFacturasToolStripMenuItem.Name = "listadoDeFacturasToolStripMenuItem";
            this.listadoDeFacturasToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.listadoDeFacturasToolStripMenuItem.Text = "Listado de Facturas";
            this.listadoDeFacturasToolStripMenuItem.Click += new System.EventHandler(this.listadoDeFacturasToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graficoDeFacturasToolStripMenuItem,
            this.gráficoDeClientesToolStripMenuItem,
            this.gráficosDeToolStripMenuItem,
            this.gráficosDeProductosToolStripMenuItem,
            this.toolStripMenuItem1});
            this.estadisticasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // graficoDeFacturasToolStripMenuItem
            // 
            this.graficoDeFacturasToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.graficoDeFacturasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.graficoDeFacturasToolStripMenuItem.Name = "graficoDeFacturasToolStripMenuItem";
            this.graficoDeFacturasToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.graficoDeFacturasToolStripMenuItem.Text = "Gráficos de Facturas";
            this.graficoDeFacturasToolStripMenuItem.Click += new System.EventHandler(this.graficoDeFacturasToolStripMenuItem_Click);
            // 
            // gráficoDeClientesToolStripMenuItem
            // 
            this.gráficoDeClientesToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.gráficoDeClientesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gráficoDeClientesToolStripMenuItem.Name = "gráficoDeClientesToolStripMenuItem";
            this.gráficoDeClientesToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.gráficoDeClientesToolStripMenuItem.Text = "Gráficos de Clientes";
            this.gráficoDeClientesToolStripMenuItem.Click += new System.EventHandler(this.gráficoDeClientesToolStripMenuItem_Click);
            // 
            // gráficosDeToolStripMenuItem
            // 
            this.gráficosDeToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.gráficosDeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gráficosDeToolStripMenuItem.Name = "gráficosDeToolStripMenuItem";
            this.gráficosDeToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.gráficosDeToolStripMenuItem.Text = "Gráficos de Proyectos";
            this.gráficosDeToolStripMenuItem.Click += new System.EventHandler(this.gráficosDeToolStripMenuItem_Click);
            // 
            // gráficosDeProductosToolStripMenuItem
            // 
            this.gráficosDeProductosToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.gráficosDeProductosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gráficosDeProductosToolStripMenuItem.Name = "gráficosDeProductosToolStripMenuItem";
            this.gráficosDeProductosToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.gráficosDeProductosToolStripMenuItem.Text = "Gráficos de Productos";
            this.gráficosDeProductosToolStripMenuItem.Click += new System.EventHandler(this.gráficosDeProductosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(237, 26);
            this.toolStripMenuItem1.Text = "Factura por numero";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(935, 57);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(599, 388);
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(131)))), ((int)(((byte)(156)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1827, 922);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.menuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.Text = "Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem soporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyectosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeProyectosToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficoDeFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gráficoDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gráficosDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gráficosDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}