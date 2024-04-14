using System;
using System.Collections.Generic;
using GestionEscuela.Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionEscuela.Entidades.Alumno
{
    public class Alumno : UsuarioEscuela
    {
       
        private List<string> materias;
        private Dictionary<string, List<int>> calificaciones;

        public Alumno(string email, string contraseña) : base(email, contraseña, TipoUsuario.Alumno)
        {
            materias = new List<string>();
            calificaciones = new Dictionary<string, List<int>>();

            
            materias.Add("Matemáticas");
            materias.Add("Historia");
            materias.Add("Literatura");

            foreach (var materia in materias)
            {
                calificaciones.Add(materia, new List<int>());
            }
        }

        public void VerMaterias()
        {
            Console.WriteLine("Materias:");
            foreach (var materia in materias)
            {
                Console.WriteLine(materia);
            }
        }

        public void VerCalificaciones()
        {
            Console.WriteLine("Calificaciones:");
            foreach (var materia in calificaciones.Keys)
            {
                Console.Write($"{materia}: ");
                foreach (var calificacion in calificaciones[materia])
                {
                    Console.Write($"{calificacion} ");
                }
                Console.WriteLine();
            }
        }

        public void AgregarCalificacion(string materia, int calificacion)
        {
          
            if (calificaciones.ContainsKey(materia))
            {
             
                calificaciones[materia].Add(calificacion);
                Console.WriteLine($"Calificación {calificacion} agregada para la materia {materia}.");
            }
            else
            {
                Console.WriteLine($"La materia {materia} no está registrada.");
            }
        }
    }
}