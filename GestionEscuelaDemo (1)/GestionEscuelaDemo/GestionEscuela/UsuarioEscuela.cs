using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscuela.Entidades
{
    public enum TipoUsuario
    {
        Director,
        Profesor,
        Alumno
    }

    public abstract class UsuarioEscuela
    {
        public string Email { get; }
        public string Contraseña { get; }
        public TipoUsuario Tipo { get; }

        public UsuarioEscuela(string email, string contraseña, TipoUsuario tipo)
        {
            Email = email;
            Contraseña = contraseña;
            Tipo = tipo;
        }
    }
}

