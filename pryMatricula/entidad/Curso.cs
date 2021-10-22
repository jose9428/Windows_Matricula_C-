using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryMatricula.control
{
    public class Curso
    {
        int codigo;
        string nombre;
        string especialidad;
        int vacantes;
        double costo;
        int horas;

        static int contador = 1;

        public Curso()
        {
            this.codigo = contador++;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public int Vacantes { get => vacantes; set => vacantes = value; }
        public double Costo { get => costo; set => costo = value; }
        public int Horas { get => horas; set => horas = value; }
    }
}
