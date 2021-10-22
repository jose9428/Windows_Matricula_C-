using pryMatricula.control;
using pryMatricula.entidad;
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
    public partial class FormMatricula : Form
    {
        ControlCurso objCurso;
        ControlMatricula objMatricula;
        Curso objC = null;
        public FormMatricula(Curso obj)
        {
            InitializeComponent();
            objCurso = new ControlCurso();
            objMatricula = new ControlMatricula();

            objC = obj;

            if (objC!=null)
            {
                txtPago.Text = objC.Costo.ToString();
                textBox1.Text = objC.Nombre.ToString();

                ValidarVacantes();
            }

            GeneraNro();
            ListarMatriculas();
        }

        public void ValidarVacantes()
        {
            if (objC.Vacantes <= 0)
            {
                Habilitar(false);
            }
            else
            {
                Habilitar(true);
            }
        }

        public void Habilitar(bool estado)
        {
            btnRegistrar.Enabled = estado;
        }

        public void GeneraNro()
        {
            txtNro.Text = Matricula.contador.ToString();
        }

        public void Limpiar()
        {
            txtApellidos.Clear();
            txtNombres.Clear();
        }

        public void ListarMatriculas()
        {
            int codigo = objC.Codigo;
     
            GridTable.Rows.Clear();
            for (int i = 0; i < objMatricula.getNum(); i++)
            {
                Matricula e = objMatricula.Obtener(i);

                if (codigo == e.CodigoCurso)
                {
                    GridTable.Rows.Add(e.Nro, e.Nombres, e.Apellidos, e.Pago, e.FechaRegistro);
                }
            }
        }

        private void FormMatricula_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Visible = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Matricula m = new Matricula();
                m.Nro = Convert.ToInt32(txtNro.Text);
                m.Nombres = txtNombres.Text;
                m.Apellidos = txtApellidos.Text;
                m.Pago = Convert.ToDouble(txtPago.Text);
                m.FechaRegistro = txtFecha.Value.ToString("yyyy-MM-dd");
                m.CodigoCurso = objC.Codigo;

                bool inserto = objMatricula.Agregar(m);

                if (inserto)
                {
                    objMatricula.GrabarArchivo();
                    Matricula.contador++;
                    GeneraNro();
                    Limpiar();
                    ListarMatriculas();

                    // Disminuir las Vacantes
                    objCurso.ActualizarVancantes(objC);
                    objCurso.GrabarArchivo();
                    ValidarVacantes();
                    MessageBox.Show("Alumno registrado correctamente");
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, datos incorrectos");
            }
        }
    }
}
