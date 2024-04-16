using gestionEscuela.Alumno;
using gestionEscuela.Director;
using gestionEscuela.Profesor;
using Spectre.Console;

namespace gestionEscuela
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var usuariosRegistrados = CrearUsuariosRegistrados();

            var usuarioActual = AutenticarUsuario(usuariosRegistrados);
            if (usuarioActual != null)
            {
                switch (usuarioActual.Tipo)
                {
                    case TipoUsuario.Director:
                        MenuDirector((DirectorC)usuarioActual);
                        break;
                    case TipoUsuario.Profesor:
                        MenuProfesor((ProfesorC)usuarioActual);
                        break;
                    case TipoUsuario.Alumno:
                        MenuAlumno((AlumnoC)usuarioActual);
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
        static List<Usuarios> CrearUsuariosRegistrados()
        {
            var usuarios = new List<Usuarios>
            {
                new DirectorC("directorJuan@gmail.com", "Juan321"),


                new ProfesorC("profesorLuka@gmail.com", "Luka321"),
                new ProfesorC("profesorZoe@gmail.com", "Zoe321"),
                new ProfesorC("profesorAlex@gmail.com", "Alex321"),
                new ProfesorC("profesorSandoval@gmail.com", "Sandoval321"),
                new ProfesorC("profesorLopez@gmail.com", "Lopez321"),

                new AlumnoC("juanperez@gmail.com", "perez321"),
                new AlumnoC("mariarodriguez@gmail.com", "maria321"),
                new AlumnoC("pedromartinez@gmail.com", "pedro123"),
                new AlumnoC("lauragonzalez@gmail.com", "laura456"),
                new AlumnoC("carloslopez@gmail.com", "carlos789"),
                new AlumnoC("anatorres@gmail.com", "ana012"),
                new AlumnoC("danielmartin@gmail.com", "daniel345"),
                new AlumnoC("luciafernandez@gmail.com", "lucia678"),
                new AlumnoC("andresrodriguez@gmail.com", "andres901"),
                new AlumnoC("sofiagomez@gmail.com", "sofia234"),
                new AlumnoC("pablohernandez@gmail.com", "pablo567"),
                new AlumnoC("martinasanchez@gmail.com", "martina890"),
                new AlumnoC("diegoalonso@gmail.com", "diego123"),
                new AlumnoC("valeriaaguilar@gmail.com", "valeria456"),
                new AlumnoC("javiergutierrez@gmail.com", "javier789"),
                new AlumnoC("nataliadelgado@gmail.com", "natalia012"),
                new AlumnoC("emiliamoreno@gmail.com", "emilia345"),
                new AlumnoC("alejandrogonzalez@gmail.com", "alejandro678"),
                new AlumnoC("camilaperez@gmail.com", "camila901"),
                new AlumnoC("juanfernandez@gmail.com", "juan234")
            };
            return usuarios;
        }

        static Usuarios AutenticarUsuario(List<Usuarios> usuarios)
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

        static void MenuDirector(DirectorC director)
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

        static void MenuProfesor(ProfesorC profesor)
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

        static void MenuAlumno(AlumnoC alumno)
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
