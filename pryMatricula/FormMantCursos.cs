using pryMatricula.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryMatricula
{
    public partial class FormMantCursos : Form
    {
        ControlEspecialidad objEsp;
        ControlCurso objCurso;
        public FormMantCursos()
        {
            InitializeComponent();
            objEsp = new ControlEspecialidad();
            objCurso = new ControlCurso();
            CargarEspecialidad();
            ListarCurso();
        }

        public void CargarEspecialidad()
        {
            cbEspecialidad.Items.Clear();

            for (int i = 0; i < objEsp.getNum(); i++)
            {
                Especialidad e = objEsp.Obtener(i);
                cbEspecialidad.Items.Add(e.Nombre);
            }

            cbEspecialidad.SelectedIndex = 0;
        }

        public void ListarCurso()
        {
            GridTable.Rows.Clear();
            for (int i = 0; i < objCurso.getNum(); i++)
            {
                Curso e = objCurso.Obtener(i);
                GridTable.Rows.Add(e.Codigo, e.Especialidad, e.Nombre, e.Vacantes, e.Horas, e.Costo);
            }
        }

        public void LimpiarCasillas()
        {
            txtCosto.Clear();
            txtHoras.Clear();
            txtNombre.Clear();
            txtVacantes.Clear();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Curso c = new Curso();
                c.Nombre = txtNombre.Text.Trim();
                c.Vacantes = Convert.ToInt32(txtVacantes.Text.Trim());
                c.Horas = Convert.ToInt32(txtHoras.Text.Trim());
                c.Especialidad = cbEspecialidad.SelectedItem.ToString();
                c.Costo = Convert.ToDouble(txtCosto.Text);

                objCurso.Agregar(c);
                objCurso.GrabarArchivo();
                LimpiarCasillas();
                ListarCurso();

                MessageBox.Show("Curso registrado!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido registrar curso");
            }
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Visible = false;
        }

        private void FormMantCursos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
