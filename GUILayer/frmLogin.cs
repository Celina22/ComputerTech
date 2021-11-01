using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using System;
using System.Media;
using System.Windows.Forms;

namespace ComputerTech.GUILayer
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioService usuarioService;
        private bool logeado = false;
        public Usuario UsuarioLogueado { get; internal set; }
        public frmLogin()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un usuari@.", "Ingreso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUsuario.Focus();
                return;
            }
            //if (this.txtClave.Text == "")
            if (string.IsNullOrEmpty(this.txtClave.Text))
            {
                MessageBox.Show("Debe ingresar una clave.", "Ingreso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Focus();
                return;
            }

            UsuarioLogueado = usuarioService.ValidarUsuario(txtUsuario.Text, txtClave.Text);
            //Controlamos que las creadenciales sean las correctas. 
            string msj = "";
            if (UsuarioLogueado != null)
            {
                msj = "Login OK. Bienvenid@, " + UsuarioLogueado + ".";
                MessageBox.Show(msj, "Ingreso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SoundPlayer splayer = new SoundPlayer(@"C:\Users\Celina\ab.wav");
                splayer.Play();
                logeado = true;
                this.Close();
            }

            else
            {
                msj = "Usuari@ y/o clave incorrectos.";
                MessageBox.Show(msj, "Ingreso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtUsuario.Text = string.Empty;
                this.txtClave.Text = string.Empty;
                this.txtUsuario.Focus();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar_Click(this, new EventArgs());
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar_Click(this, new EventArgs());
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!logeado)
                if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
                else
                    Environment.Exit(0);
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToShortDateString();

        }
    }
}
