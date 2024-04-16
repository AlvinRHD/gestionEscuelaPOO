using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionEscuela
{
    public enum TipoUsuario
    {
        Director,
        Profesor,
        Alumno
    }
    public abstract class Usuarios
    {
        public string Email { get; }
        public string Contraseña { get; }
        public TipoUsuario Tipo { get; }

        public Usuarios(string email, string contraseña, TipoUsuario tipo)
        {
            Email = email;
            Contraseña = contraseña;
            Tipo = tipo;
        }
    }
}
