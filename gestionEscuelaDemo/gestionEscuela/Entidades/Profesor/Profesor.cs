using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionEscuela.Entidades.Profesor
{
    public class Profesor : IUsuario
    {
        public string Nombre { get; init; }
        public string CorreoElectronico { get; init; }
        public string Contraseña { get; init; }
        public TipoUsuario Tipo => TipoUsuario.Profesor;
        public string[] Materias { get; init; }

        public Profesor(string nombre, string correoElectronico, string contraseña, string[] materias)
        {
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Contraseña = contraseña;
            Materias = materias;
        }
    }
}
