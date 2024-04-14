using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionEscuela.Entidades
{
    public interface IDirector
    {
        void VerAlumnos();
        void VerProfesores();
        void GestionarPagos();
        void GestionarPermisos();
    }
}



