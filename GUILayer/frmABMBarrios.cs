using ComputerTech.BusinessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerTech.GUILayer
{
    public partial class frmABMBarrios : Form
    {

        bool nuevo = false;
        BarrioService oBarrioService = new BarrioService();

        public frmABMBarrios()
        {
            InitializeComponent();
        }

        private void habilitarCampos(bool x)
        {
            txt_nombre.Enabled = x;
            dgv_barrio.Enabled = !x;
            btn_guardar.Enabled = x;
            btn_cancelar.Enabled = x;
            btn_eliminar.Enabled = !x;
            btn_nuevo.Enabled = !x;
            btn_editar.Enabled = !x;
            btn_salir.Enabled = !x;
            if (dgv_barrio.Rows.Count == 0)
                btn_editar.Enabled = btn_eliminar.Enabled = false;
        }

        private void cargarCombo(ComboBox combo, Object source, string display, string value)
        {
            combo.DataSource = source;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private void cargarGrilla(DataGridView grilla, IList<Barrio> lista)
        {
            grilla.Rows.Clear();
            //for(int i = 0; i<lista.Count; i++)
            foreach (var barrio in lista)
            {
                grilla.Rows.Add(barrio.Id_barrio.ToString(),
                               barrio.Nombre.ToString());
            }
        }

        private void limpiarCampos()
        {
            txt_id.Clear();
            txt_nombre.Clear();
        }

        private void actualizarCampos(string idBarrio)
        {
            Barrio barrioSeleccionado = oBarrioService.recuperarBarrio(idBarrio);
            if (barrioSeleccionado != null)
            {
                txt_id.Text = barrioSeleccionado.Id_barrio.ToString();
                txt_nombre.Text = barrioSeleccionado.Nombre;
            }
            else
                limpiarCampos();
        }

        public bool validarCampos()
        {

            if (txt_nombre.Text == "")
            {
                MessageBox.Show("Datos ingresados no válidos. Debe ingresar un barrio.", "Datos de barrio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nombre.Focus();
                return false;
            }

            return true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            this.habilitarCampos(true);
            limpiarCampos();
            dgv_barrio.Enabled = false;
            txt_nombre.Focus();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
            dgv_barrio.Enabled = false;
            txt_nombre.Focus();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que quiere eliminar el barrio " + txt_nombre.Text + " ?", "Borrar barrio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Barrio oBarrio = new Barrio();
                oBarrio.Id_barrio = Convert.ToInt32(txt_id.Text);
                oBarrioService.eliminarBarrio(oBarrio);
                cargarGrilla(dgv_barrio, oBarrioService.recuperarTodos());

            }
            habilitarCampos(false);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Barrio oBarrio = new Barrio();
                oBarrio.Nombre = txt_nombre.Text;
                if (nuevo)
                {
                    oBarrioService.crearBarrio(oBarrio);
                    MessageBox.Show("¡Barrio creado con éxito!", "Crear barrio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oBarrio.Id_barrio = Convert.ToInt32(txt_id.Text);
                    oBarrioService.actualizarBarrio(oBarrio);
                    MessageBox.Show("¡Barrio actualizado con éxito!", "Actualizar Barrio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cargarGrilla(dgv_barrio, oBarrioService.recuperarTodos());
                habilitarCampos(false);
                this.nuevo = false;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            habilitarCampos(false);
            nuevo = false;
            if (dgv_barrio.Rows.Count != 0)
                this.actualizarCampos(dgv_barrio.CurrentRow.Cells[0].Value.ToString());
            else limpiarCampos();
            cargarGrilla(dgv_barrio, oBarrioService.recuperarTodos());
            btnBuscar.Visible = false;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_barrio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.actualizarCampos(dgv_barrio.CurrentRow.Cells[0].Value.ToString());
        }

        private void frmABMBarrios_Load(object sender, EventArgs e)
        {
            cargarGrilla(dgv_barrio, oBarrioService.recuperarTodos());
            habilitarCampos(false);
            dgv_barrio.ForeColor = Color.Black;
            dgv_barrio.DefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182); ;
            dgv_barrio.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_barrio.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(165, 177, 182);
            dgv_barrio.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(165, 177, 182);
        }

        private void dgv_barrio_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos(dgv_barrio.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgv_barrio, oBarrioService.recuperarBarrioNombre(txt_nombre.Text));
            dgv_barrio.Enabled = true;
            btn_editar.Enabled = true;
        }

        private void btnHabilitarBusqueda_Click(object sender, EventArgs e)
        {
            cargarGrilla(dgv_barrio, oBarrioService.recuperarTodos());
            btnBuscar.Visible = true;
            habilitarCampos(true);
            txt_nombre.Text = "";
            btn_guardar.Enabled = false;
        }

        private void frmABMBarrios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
