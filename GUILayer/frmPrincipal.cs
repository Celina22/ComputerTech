using ComputerTech.Entities;
using ComputerTech.Reportes;
using ComputerTech.Sources;
using System;
using System.Windows.Forms;

namespace ComputerTech.GUILayer
{
    public partial class frmPrincipal : Form
    {

        Usuario usuarioActual;

        public Usuario UsuarioActual { get => usuarioActual; set => usuarioActual = value; }

        public frmPrincipal()
        {
            InitializeComponent();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            frmLogin fl = new frmLogin();
            fl.ShowDialog();
            int ancho = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int alto = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            Size = new System.Drawing.Size(ancho, alto);

            pbLogo.Location = new System.Drawing.Point((ancho - pbLogo.Size.Width) / 2, (alto - pbLogo.Size.Height) / 2);

            this.menuPrincipal.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
            UsuarioActual = fl.UsuarioLogueado;
            if (UsuarioActual != null)
            {
                this.Text = "Menú Principal - Usuario actual: " + UsuarioActual.NombreUsuario;
            }
            fl.Dispose();
            this.Visible = true;
        }
        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMProyecto abmProyecto = new frmABMProyecto();
            abmProyecto.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMProducto abmProducto = new frmABMProducto();
            abmProducto.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMUsuario aBMUsuario = new frmABMUsuario();
            aBMUsuario.ShowDialog();
        }

        private void barriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMBarrios abmBarrios = new frmABMBarrios();
            abmBarrios.ShowDialog();
        }

        private void contactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMContactos abmContactos = new frmABMContactos();
            abmContactos.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMClientes abmClientes = new frmABMClientes();
            abmClientes.ShowDialog();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura nuevaFactura = new frmFactura(usuarioActual);
            nuevaFactura.ShowDialog();
        }

        private void listadoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteListadoCliente nuevoReporteCliente = new frmReporteListadoCliente();
            nuevoReporteCliente.ShowDialog();
        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteListadoProducto nuevoReporteProducto = new frmReporteListadoProducto();
            nuevoReporteProducto.ShowDialog();
        }

        private void listadoDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteListadoFactura nuevoReporteFactura = new frmReporteListadoFactura();
            nuevoReporteFactura.ShowDialog();
        }

        private void listadoDeProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteListadoProyectos nuevoReporteProyecto = new frmReporteListadoProyectos();
            nuevoReporteProyecto.ShowDialog();
        }

        private void graficoDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaGraficoFactura nuevoReporteFactura = new frmEstadisticaGraficoFactura();
            nuevoReporteFactura.ShowDialog();
        }

        private void estToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaGraficoProyecto frmep = new frmEstadisticaGraficoProyecto();
            frmep.ShowDialog();
        }

        private void gráficoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaGraficoCliente nuevoReporteClientes = new frmEstadisticaGraficoCliente();
            nuevoReporteClientes.ShowDialog();

        }

        private void gráficosDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaGraficoProyecto nuevoReporteProyectos = new frmEstadisticaGraficoProyecto();
            nuevoReporteProyectos.ShowDialog();
        }

        private void gráficosDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaGraficoProducto frmEstadisticaGraficoProducto = new frmEstadisticaGraficoProducto();
            frmEstadisticaGraficoProducto.ShowDialog();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void soporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
