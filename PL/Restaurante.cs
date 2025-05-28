using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Restaurante
    {
        public static void Opcion()
        {
            int opcion = 0;

            while (opcion != 6)
            {
                Console.WriteLine("Ingresa el número de la acción que quieres realizar: ");
                Console.WriteLine("1 -> Mostrar todo");
                Console.WriteLine("2 -> Consultar por ID");
                Console.WriteLine("3 -> Insertar");
                Console.WriteLine("4 -> Actualizar");
                Console.WriteLine("5 -> Eliminar");
                Console.WriteLine("6 -> Salir");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingresa un número del 1 al 6.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        GetAll();
                        break;
                    case 2:
                        GetById();
                        break;
                    case 3:
                        Add();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intenta nuevamente.");
                        break;
                }
            }

        }

        public static void GetAll()
        {
            ML.Result result = BL.Restaurante.GetAll();

            if (result.Correct)
            {
                foreach (ML.Restaurante restaurante in result.Objects)
                {
                    Console.WriteLine("ID-> " + restaurante.IdRestaurante);
                    Console.WriteLine("Nombre-> " + restaurante.Nombre);
                    Console.WriteLine("Capacidad-> " + restaurante.Capacidad);
                    Console.WriteLine("Eslogan-> " + restaurante.Eslogan);
                    Console.WriteLine("Fecha de Inaguración-> " + restaurante.FechaInaguracion);
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingresa el ID del restaurante");
            int idUsuario = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Restaurante.GetById(idUsuario);

            if (result.Correct)
            {
                ML.Restaurante restaurante = (ML.Restaurante)result.Object;
                //Console.WriteLine("ID-> " + restaurante.IdRestaurante);
                Console.WriteLine("Nombre-> " + restaurante.Nombre);
                Console.WriteLine("Capacidad-> " + restaurante.Capacidad);
                Console.WriteLine("Eslogan-> " + restaurante.Eslogan);
                Console.WriteLine("Fecha de Inaguración-> " + restaurante.FechaInaguracion);
                Console.WriteLine("\n");

            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Add()
        {
            ML.Restaurante restaurante =new ML.Restaurante();

            Console.WriteLine("Ingresa el Nombre ");
            restaurante.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa la Capacidad ");
            restaurante.Capacidad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingresa el Eslogan ");
            restaurante.Eslogan = Console.ReadLine();

            Console.WriteLine("Ingresa la Fecha de Inaguración ");
            restaurante.FechaInaguracion = Console.ReadLine();

            ML.Result result = BL.Restaurante.Add(restaurante);

            if (result.Correct)
            {
                Console.WriteLine("Se inserto de manera correcta");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Update()
        {
            ML.Restaurante restaurante = new ML.Restaurante();

            Console.WriteLine("Ingresa el ID ");
            restaurante.IdRestaurante = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingresa el Nombre ");
            restaurante.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa la Capacidad ");
            restaurante.Capacidad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingresa el Eslogan ");
            restaurante.Eslogan = Console.ReadLine();

            Console.WriteLine("Ingresa la Fecha de Inaguración ");
            restaurante.FechaInaguracion = Console.ReadLine();

            ML.Result result = BL.Restaurante.Update(restaurante);

            if (result.Correct)
            {
                Console.WriteLine("Se actualizo de manera correcta");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            Console.WriteLine("Ingresa el ID ");
            int idRestaurante = Convert.ToInt32(Console.ReadLine());

            ML.Result result = BL.Restaurante.Delete(idRestaurante);

            if (result.Correct)
            {
                Console.WriteLine("Se elimino de manera correcta");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }
    }
}
