using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryMatricula.control
{
    public class ControlEspecialidad
    {
        public Especialidad[] arreglo;
        public int indice;

        public ControlEspecialidad()
        {
            arreglo = new Especialidad[100];
            indice = 0;

            CargarArchivo();
        }

        public void Agregar(Especialidad obj)
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
                StreamWriter sw = new StreamWriter("Especialidad.txt");

                for (int i = 0; i < indice; i++)
                {
                    Especialidad obj = arreglo[i];

                    linea = obj.Codigo + ";" +
                            obj.Nombre + ";" +
                            obj.Nro_ciclos;

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
                StreamReader sr = new StreamReader("Especialidad.txt");

                while ((linea = sr.ReadLine()) != null)
                {
                    s = linea.Split(separador);

                    Especialidad obj = new Especialidad();
                    obj.Codigo = Convert.ToInt32(s[0].Trim());
                    obj.Nombre = s[1].Trim();
                    obj.Nro_ciclos = Convert.ToInt32(s[2].Trim());
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

        public Especialidad Obtener(int i)
        {
            return arreglo[i];
        }
    }
}
