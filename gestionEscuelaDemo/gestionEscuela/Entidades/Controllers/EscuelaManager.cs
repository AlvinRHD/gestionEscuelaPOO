using gestionEscuela.Entidades.Director;
using gestionEscuela.Entidades.Profesor;
using gestionEscuela.Entidades.Alumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gestionEscuela.Entidades.Controllers
{
    public class EscuelaManager
    {
        private List<IUsuario> usuarios;

        public EscuelaManager()
        {
            usuarios = new List<IUsuario>
            {
                new Director("NombreDirector", "director@escuela.com", "contraseña"),

                new Profesor("NombreProfesor", "profesor@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }),
                new Profesor("NombreProfesor", "profesor@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }),
                new Profesor("NombreProfesor", "profesor@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }),
                new Profesor("NombreProfesor", "profesor@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }),
                new Profesor("NombreProfesor", "profesor@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }),
                new Profesor("NombreProfesor", "profesor@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }),

                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10),
                new Alumno("NombreEstudiante", "estudiante@escuela.com", "contraseña", new string[] { "Matemáticas", "Ciencias" }, 10)
            };
        }

        public void Iniciar()
        {
            Console.WriteLine("¡Bienvenido a la Escuela!");
            Console.WriteLine("Por favor, inicie sesión...");

            while (true)
            {
                try
                {
                    Console.Write("Correo electrónico: ");
                    string correo = Console.ReadLine();

                    Console.Write("Contraseña: ");
                    string contraseña = Console.ReadLine();

                    IUsuario usuario = AutenticarUsuario(correo, contraseña);
                    if (usuario != null)
                    {
                        MostrarMenu(usuario);
                    }
                    else
                    {
                        Console.WriteLine("Correo electrónico o contraseña incorrectos. Inténtelo de nuevo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private IUsuario AutenticarUsuario(string correo, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.CorreoElectronico == correo && usuario.Contraseña == contraseña)
                {
                    return usuario;
                }
            }
            return null;
        }

        private void MostrarMenu(IUsuario usuario)
        {
            Console.WriteLine("¡Menú del usuario!");
        }
    }
}
