using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryMatricula.entidad
{
    public class Matricula
    {
        int nro;
        string nombres;
        string apellidos;
        double pago;
        string fechaRegistro;
        int codigoCurso;

        public static int contador = 100000;

        public int Nro { get => nro; set => nro = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public double Pago { get => pago; set => pago = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public int CodigoCurso { get => codigoCurso; set => codigoCurso = value; }
    }
}
