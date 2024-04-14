using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEscuela.Entidades;
using Spectre.Console;


namespace GestionEscuela.Entidades.Director
{
    public class Director : UsuarioEscuela
    {
      
        private List<string> alumnos;
        private List<string> profesores;

        public Director(string email, string contraseña) : base(email, contraseña, TipoUsuario.Director)
        {

            alumnos = new List<string>();
            profesores = new List<string>();

            alumnos.Add("Juan ");
            alumnos.Add("María ");
            alumnos.Add("Pedro ");

            profesores.Add("Ana ");
            profesores.Add("Luis ");
        }

        public void VerAlumnos()
        {
            Console.WriteLine("Alumnos:");
            foreach (var alumno in alumnos)
            {
                Console.WriteLine(alumno);
            }
        }

        public void VerProfesores()
        {
            Console.WriteLine("Profesores:");
            foreach (var profesor in profesores)
            {
                Console.WriteLine(profesor);
            }
        }

        public void GestionarPagos()
        {
       
            Console.WriteLine("Acceso al sistema de gestión de pagos.");
            Console.WriteLine("Mostrando pagos pendientes...");
            Console.WriteLine("Pago 1: Pendiente");
            Console.WriteLine("Pago 2: Pendiente");
            Console.WriteLine("¿Desea marcar algún pago como pagado? (S/N)");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() == "s")
            {
                Console.WriteLine("Ingrese el número del pago a marcar como pagado:");
                int numeroPago = int.Parse(Console.ReadLine());
                Console.WriteLine($"El pago {numeroPago} ha sido marcado como pagado.");
            }
        }

        public void GestionarPermisos()
        {
            Console.WriteLine("Acceso al sistema de gestión de permisos.");
            Console.WriteLine("Seleccione la acción a realizar:");
            Console.WriteLine("1. Otorgar permisos");
            Console.WriteLine("2. Revocar permisos");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el nombre del usuario al que desea otorgar permisos:");
                    string usuarioOtorgar = Console.ReadLine();
                    Console.WriteLine($"Se han otorgado permisos al usuario {usuarioOtorgar}.");
                    break;
                case 2:
                    Console.WriteLine("Ingrese el nombre del usuario al que desea revocar permisos:");
                    string usuarioRevocar = Console.ReadLine();
                    Console.WriteLine($"Se han revocado permisos al usuario {usuarioRevocar}.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}