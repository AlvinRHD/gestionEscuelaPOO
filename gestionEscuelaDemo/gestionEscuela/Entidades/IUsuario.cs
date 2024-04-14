using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionEscuela.Entidades
{
    public interface IUsuario
    {
        string Nombre { get; }
        string CorreoElectronico { get; }
        string Contraseña { get; }
    }

    public enum TipoUsuario
    {
        Director,
        Profesor,
        Alumno
    }
}
