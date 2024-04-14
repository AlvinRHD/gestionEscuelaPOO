using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEscuela.Entidades;
using Spectre.Console;

namespace GestionEscuela.Entidades.Profesor
{
    public class Profesor : UsuarioEscuela
    {

        private List<string> gradosAsignados;
        private List<string> alumnos;
       

        public Profesor(string email, string contraseña) : base(email, contraseña, TipoUsuario.Profesor)
        {
            gradosAsignados = new List<string>();
            alumnos = new List<string>();
        

            gradosAsignados.Add("Matemáticas - 10° Grado");
            gradosAsignados.Add("Historia - 11° Grado");
            gradosAsignados.Add("Literatura - 9° Grado");

            alumnos.Add("juanperez");
            alumnos.Add("maríarodriguez");
            alumnos.Add("Pedromartinez");

            
        }

        public void VerGradosAsignados()
        {
            Console.WriteLine("Grados Asignados: ");
            foreach (var grado in gradosAsignados)
            {
                Console.WriteLine(grado);
            }
        }

        public void VerAlumnos()
        {
            Console.WriteLine("Alumnos: ");
            foreach (var alumno in alumnos)
            {
                Console.WriteLine(alumno);
            }
        }
    }
}