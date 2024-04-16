using System;
using System.Collections.Generic;
using Spectre.Console;

namespace EscuelaApp
{
    // Enum para roles de usuario
    public enum RolUsuario
    {
        Director,
        Profesor,
        Alumno
    }

    // Interface para usuarios
    public interface IUsuario
    {
        string Email { get; }
        string Contraseña { get; }
        RolUsuario Rol { get; }
    }

    // Clase para representar un usuario
    public class Usuario : IUsuario
    {
        public string Email { get; }
        public string Contraseña { get; }
        public RolUsuario Rol { get; }

        public Usuario(string email, string contraseña, RolUsuario rol)
        {
            Email = email;
            Contraseña = contraseña;
            Rol = rol;
        }
    }

    // Excepción personalizada para autenticación
    public class AutenticacionException : Exception
    {
        public AutenticacionException(string message) : base(message)
        {
        }
    }

    // Gestor de usuarios
    public class GestorUsuarios
    {
        private List<IUsuario> _usuarios;

        public GestorUsuarios()
        {
            // Inicializar usuarios
            _usuarios = new List<IUsuario>
            {
                new Usuario("director@escuela.com", "123456", RolUsuario.Director),
                // Agregar profesores y estudiantes aquí
            };
        }

        // Método para iniciar sesión
        public IUsuario IniciarSesion(string email, string contraseña)
        {
            // Buscar usuario por email y contraseña
            IUsuario usuario = _usuarios.Find(u => u.Email == email && u.Contraseña == contraseña);
            if (usuario == null)
            {
                throw new AutenticacionException("Credenciales incorrectas.");
            }
            return usuario;
        }
        // Método para obtener todos los usuarios
        public List<IUsuario> ObtenerUsuarios()
        {
            return _usuarios;
        }
    }

    // Clase para el menú del director
    public class MenuDirector
    {
        private readonly GestorUsuarios _gestorUsuarios;

        public MenuDirector(GestorUsuarios gestorUsuarios)
        {
            _gestorUsuarios = gestorUsuarios;
        }
        // Método para mostrar el menú del director
        public void Mostrar()
        {
            while (true)
            {
                AnsiConsole.Clear();

                // Mostrar título del menú
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("===================================");
                AnsiConsole.WriteLine("   MENÚ DEL DIRECTOR DE LA ESCUELA");
                AnsiConsole.WriteLine("===================================");
                AnsiConsole.WriteLine();

                // Mostrar opciones del menú
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(5)
                        .AddChoices("Ver todos los alumnos", "Ver todos los profesores", "Gestionar pagos de profesores", "Gestionar permisos de profesores", "Salir")
                        .Title("[bold]Seleccione una opción:[/] ")
                );

                switch (opcion)
                {
                    case "Ver todos los alumnos":
                        MostrarTodosLosAlumnos();
                        break;
                    case "Ver todos los profesores":
                        MostrarTodosLosProfesores();
                        break;
                    case "Gestionar pagos de profesores":
                        GestionarPagosProfesores();
                        break;
                    case "Gestionar permisos de profesores":
                        GestionarPermisosProfesores();
                        break;
                    case "Salir":
                        AnsiConsole.MarkupLine("[bold red]Saliendo del programa...[/]");
                        Environment.Exit(0);
                        break;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                        break;
                }
            }
        }

        // Métodos para las opciones del menú
        private void MostrarTodosLosAlumnos()
        {
            // Lógica para mostrar todos los alumnos
            AnsiConsole.MarkupLine("[bold green]Mostrando todos los alumnos...[/]");
        }

        private void MostrarTodosLosProfesores()
        {
            // Lógica para mostrar todos los profesores
            AnsiConsole.MarkupLine("[bold green]Mostrando todos los profesores...[/]");
        }

        private void GestionarPagosProfesores()
        {
            // Lógica para gestionar pagos de profesores
            AnsiConsole.MarkupLine("[bold green]Gestionando pagos de profesores...[/]");
        }

        private void GestionarPermisosProfesores()
        {
            // Lógica para gestionar permisos de profesores
            AnsiConsole.MarkupLine("[bold green]Gestionando permisos de profesores...[/]");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var gestorUsuarios = new GestorUsuarios();

            try
            {
                // Solicitar email y contraseña
                string email = AnsiConsole.Ask<string>("Email:");
                string contraseña = AnsiConsole.Prompt(new TextPrompt<string>("Contraseña:").Secret());

                // Iniciar sesión
                var usuario = gestorUsuarios.IniciarSesion(email, contraseña);

                if (usuario.Rol == RolUsuario.Director)
                {
                    // Mostrar menú del director
                    var menuDirector = new MenuDirector(gestorUsuarios);
                    menuDirector.Mostrar();
                }
                else
                {
                    throw new AutenticacionException("No tiene permisos para acceder a esta parte del sistema.");
                }
            }
            catch (AutenticacionException ex)
            {
                AnsiConsole.WriteException(ex);
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
            }
        }
    }
}