using System;
using System.Collections.Generic;
using GestionEscuela.Entidades.Alumno;
using GestionEscuela.Entidades.Director;
using GestionEscuela.Entidades.Profesor;
using Spectre.Console;
using GestionEscuela.Entidades;

namespace GestionEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var usuariosRegistrados = CrearUsuariosRegistrados();

            var usuarioActual = AutenticarUsuario(usuariosRegistrados);
            if (usuarioActual != null)
            {
                switch (usuarioActual.Tipo)
                {
                    case TipoUsuario.Director:
                        MenuDirector((Director)usuarioActual);
                        break;
                    case TipoUsuario.Profesor:
                        MenuProfesor((Profesor)usuarioActual);
                        break;
                    case TipoUsuario.Alumno:
                        MenuAlumno((Alumno)usuarioActual);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                AnsiConsole.WriteLine("Usuario no encontrado. Cierre del programa.");
            }
        }
        static List<UsuarioEscuela> CrearUsuariosRegistrados()
        {
            var usuarios = new List<UsuarioEscuela>
            {
                new Director("directorJuan@gmail.com", "Juan321"),

               
                new Profesor("profesorLuka@gmail.com", "Luka321"),
                new Profesor("profesorZoe@gmail.com", "Zoe321"),
                new Profesor("profesorAlex@gmail.com", "Alex321"),
                new Profesor("profesorSandoval@gmail.com", "Sandoval321"),
                new Profesor("profesorLopez@gmail.com", "Lopez321"),

               new Alumno("juanperez@gmail.com", "perez321"),
               new Alumno("mariarodriguez@gmail.com", "maria321"),
               new Alumno("pedromartinez@gmail.com", "sofia321")


            };
            return usuarios;
        }

        static UsuarioEscuela AutenticarUsuario(List<UsuarioEscuela> usuarios)
        {
            AnsiConsole.WriteLine("Bienvenido al sistema de gestión de la escuela.");
            string email = AnsiConsole.Prompt(new TextPrompt<string>("Email: "));
            string contraseña = AnsiConsole.Prompt(new TextPrompt<string>("Contraseña: ").Secret());

            foreach (var usuario in usuarios)
            {
                if (usuario.Email == email && usuario.Contraseña == contraseña)
                {
                    return usuario;
                }
            }

            return null;
        }

        static void MenuDirector(Director director)
        {
            AnsiConsole.WriteLine("\n¡Bienvenido, Director!");

            while (true)
            {
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción")
                        .PageSize(4)
                        .AddChoices(new[] { "Ver alumnos", "Ver profesores", "Gestionar pagos", "Gestionar permisos", "Cerrar sesión" }));

                switch (opcion)
                {
                    case "Ver alumnos":
                        director.VerAlumnos();
                        break;
                    case "Ver profesores":
                        director.VerProfesores();
                        break;
                    case "Gestionar pagos":
                        director.GestionarPagos();
                        break;
                    case "Gestionar permisos":
                        director.GestionarPermisos();
                        break;
                    case "Cerrar sesión":
                        AnsiConsole.WriteLine("\nSesión cerrada. ¡Hasta luego!");
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Opción no válida. Inténtalo de nuevo.[/]");
                        break;
                }
            }
        }

        static void MenuProfesor(Profesor profesor)
        {
            AnsiConsole.WriteLine("\n¡Bienvenido, Profesor!");

            while (true)
            {
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción")
                        .PageSize(4)
                        .AddChoices(new[] { "Ver grados asignados", "Ver alumnos", "Cerrar sesión" }));

                switch (opcion)
                {
                    case "Ver grados asignados":
                        profesor.VerGradosAsignados();
                        break;
                    case "Ver alumnos":
                        profesor.VerAlumnos();
                        break;
                    case "Cerrar sesión":
                        AnsiConsole.WriteLine("\nSesión cerrada. ¡Hasta luego!");
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Opción no válida. Inténtalo de nuevo.[/]");
                        break;
                }
            }
        }

        static void MenuAlumno(Alumno alumno)
        {
            AnsiConsole.WriteLine("\n¡Bienvenido, Alumno!");

            while (true)
            {
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción")
                        .PageSize(4)
                        .AddChoices(new[] { "Ver materias", "Cerrar sesión" }));

                switch (opcion)
                {
                    case "Ver materias":
                        alumno.VerMaterias();
                        break;
                    case "Cerrar sesión":
                        AnsiConsole.WriteLine("\nSesión cerrada. ¡Hasta luego!");
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Opción no válida. Inténtalo de nuevo.[/]");
                        break;
                }
            }
        }
    }
}
