using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionEscuela.Entidades.Director
{
    public class Director : IUsuario
    {
        public string Nombre { get; init; }
        public string CorreoElectronico { get; init; }
        public string Contraseña { get; init; }
        public TipoUsuario Tipo => TipoUsuario.Director;

        public Director(string nombre, string correoElectronico, string contraseña)
        {
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Contraseña = contraseña;
        }
    }
}
