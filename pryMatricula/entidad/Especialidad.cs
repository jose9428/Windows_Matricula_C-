using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryMatricula.control
{
    public class Especialidad
    {
        int codigo;
        string nombre;
        int nro_ciclos;

        static int contador = 1;

        public Especialidad()
        {
            this.codigo = contador++;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Nro_ciclos { get => nro_ciclos; set => nro_ciclos = value; }
    }
}
