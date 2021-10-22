using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryMatricula.control
{
    public class ControlCurso
    {

        public Curso[] arreglo;
        public int indice;

        public ControlCurso()
        {
            arreglo = new Curso[100];
            indice = 0;

            CargarArchivo();
        }

        public void Agregar(Curso obj)
        {
            if (indice < arreglo.Length)
            {
                arreglo[indice] = obj;
                indice++;
            }
        }

        public void GrabarArchivo()
        {
            try
            {
                string linea;
                StreamWriter sw = new StreamWriter("Curso.txt");

                for (int i = 0; i < indice; i++)
                {
                    Curso obj = arreglo[i];

                    linea = obj.Codigo + ";" +
                            obj.Especialidad + ";" +
                            obj.Nombre + ";" +
                            obj.Vacantes + ";" +
                            obj.Costo + ";" +
                            obj.Horas;

                    sw.WriteLine(linea);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al grabar: " + e.Message);
            }
        }

        public void CargarArchivo()
        {
            char[] separador = new char[] { ';' };
            string linea;
            string[] s;

            try
            {
                StreamReader sr = new StreamReader("Curso.txt");

                while ((linea = sr.ReadLine()) != null)
                {
                    s = linea.Split(separador);

                    Curso obj = new Curso();
                    obj.Codigo = Convert.ToInt32(s[0].Trim());
                    obj.Especialidad = s[1].Trim();
                    obj.Nombre = s[2].Trim();
                    obj.Vacantes = Convert.ToInt32(s[3].Trim());
                    obj.Costo = Convert.ToDouble(s[4].Trim());
                    obj.Horas = Convert.ToInt32(s[5].Trim());
                    Agregar(obj);
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cargar: " + e.Message);
            }
        }

        public int getNum()
        {
            return indice;
        }

        public Curso Obtener(int i)
        {
            return arreglo[i];
        }

        public Curso BuscarPorId(int id)
        {
            for (int i = 0;i<indice;i++)
            {
                if (arreglo[i].Codigo == id)
                {
                    return arreglo[i];
                }
            }
            return null;
        }

        public void ActualizarVancantes(Curso c)
        {
            for (int i = 0; i < indice; i++)
            {
                if (arreglo[i].Codigo == c.Codigo)
                {
                    c.Vacantes = c.Vacantes - 1;
                    arreglo[i] = c;
                    break;
                }
            }
        }
    }
}
