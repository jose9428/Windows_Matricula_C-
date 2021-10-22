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
    public partial class Form1 : Form
    {
        ControlEspecialidad objEsp;
        ControlCurso objCurso;
        int pos = -1;
        public Form1()
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
            string especialidad = cbEspecialidad.SelectedItem.ToString();
            GridTable.Rows.Clear();
            for (int i = 0; i < objCurso.getNum(); i++)
            {
                Curso e = objCurso.Obtener(i);
                if (e.Especialidad == especialidad)
                {
                    GridTable.Rows.Add(e.Codigo, e.Nombre,e.Costo, e.Vacantes);
                }
            }
        }


        private void BtnRegistrarCursos_Click(object sender, EventArgs e)
        {
            FormMantCursos frm = new FormMantCursos();
            frm.Show();
            this.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCurso();
        }

        private void GridTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = e.RowIndex;

            if (pos >=0)
            {
                int codigo = Convert.ToInt32(GridTable.Rows[pos].Cells[0].Value.ToString());
                Curso obj = objCurso.BuscarPorId(codigo);
                FormMatricula frm = new FormMatricula(obj);
                frm.Show();
                this.Visible = false;
            }
        }
    }
}
