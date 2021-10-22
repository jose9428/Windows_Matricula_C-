using pryMatricula.entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryMatricula.control
{
    public class ControlMatricula
    {

        public Matricula[] arreglo;
        public int indice;

        public ControlMatricula()
        {
            arreglo = new Matricula[100];
            indice = 0;

            CargarArchivo();
        }

        public bool Agregar(Matricula obj)
        {

            if (indice < arreglo.Length)
            {
                arreglo[indice] = obj;
                indice++;
                return true;
            }
            return false;
        }

        public void GrabarArchivo()
        {
            try
            {
                string linea;
                StreamWriter sw = new StreamWriter("Matricula.txt");

                for (int i = 0; i < indice; i++)
                {
                    Matricula obj = arreglo[i];

                    linea = obj.Nro + ";" +
                            obj.Nombres + ";" +
                            obj.Apellidos + ";" +
                            obj.Pago + ";" +
                            obj.FechaRegistro + ";" +
                            obj.CodigoCurso;

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
                StreamReader sr = new StreamReader("Matricula.txt");

                while ((linea = sr.ReadLine()) != null)
                {
                    s = linea.Split(separador);

                    Matricula obj = new Matricula();
                    obj.Nro = Convert.ToInt32(s[0].Trim());
                    obj.Nombres = s[1].Trim();
                    obj.Apellidos = s[2].Trim();
                    obj.Pago = Convert.ToDouble(s[3].Trim());
                    obj.FechaRegistro = s[4].Trim();
                    obj.CodigoCurso = Convert.ToInt32(s[5].Trim());
                    Agregar(obj);
                    Matricula.contador++;
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

        public Matricula Obtener(int i)
        {
            return arreglo[i];
        }
    }
}