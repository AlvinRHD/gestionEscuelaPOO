using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionEscuela.Entidades.Alumno
{
    public class Alumno : IUsuario
    {
        public string Nombre { get; init; }
        public string CorreoElectronico { get; init; }
        public string Contraseña { get; init; }
        public TipoUsuario Tipo => TipoUsuario.Alumno;
        public string[] Materias { get; init; }
        public int Grado { get; init; }

        public Alumno(string nombre, string correoElectronico, string contraseña, string[] materias, int grado)
        {
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Contraseña = contraseña;
            Materias = materias;
            Grado = grado;
        }
    }
}
