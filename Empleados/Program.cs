using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados
{
    class Program
    {
        static List<Empleado> ListaE = new List<Empleado>();
        static void Main(string[] args)
        {
            var r = 0;
            do
            {
                Console.WriteLine("****Menu****");
                Console.WriteLine("1.- Alta empleado");
                Console.WriteLine("2.- Listado empleados");
                Console.WriteLine("3.- Salir");

                r=Convert.ToInt32(Console.ReadLine());

                switch (r)
                {
                    case 1:
                        AltaEmpleado();
                        break;
                    case 2:
                        ListaEmpleado();
                        break;
                }

            } while (r != 3);
        
        }

        private static void AltaEmpleado()
        {
            try
            {
                var e = new Empleado();
                Console.WriteLine("Nombre: ");
                e.Nombre = Console.ReadLine();

                Console.WriteLine("Edad: ");
                e.Edad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Estudios: ");

                /*- Recogemos el enumeroado en una variable
                  - Hacemos una comprobación con TryParse para saber si es un Enumerado o un Numero
                  - Si devuelve True es que es un numero,
                    entonces si ese numero esta definido como TypeOf del enumeroado,
                    convertimos el numero a un elemento de la enumeración*/

                var es = Console.ReadLine();
                var esN = 0;

                if(int.TryParse(es, out esN))
                {
                    if (Enum.IsDefined(typeof(Estudios), esN))
                        e.Estudios = (Estudios)esN;
                }
                else
                {
                    Estudios est;
                    Estudios.TryParse(es, out est);
                    e.Estudios = est;
                }
  

                Console.WriteLine("Puesto: ");

                
                var pu = Console.ReadLine();
                var pueN = 0;

                if (int.TryParse(pu, out pueN))
                {
                    if (Enum.IsDefined(typeof(Puesto), pueN))
                        e.Puesto = (Puesto)pueN;
                }
                else
                {
                    Puesto pue;
                    Puesto.TryParse(pu, out pue);
                    e.Puesto = pue;
                }

                ListaE.Add(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }                    
        }

        private static void ListaEmpleado()
        {
            foreach (var empleado in ListaE)
            {
                Console.WriteLine("{0} Edad {1} Estudios {2} Puesto {3}", 
                    empleado.Nombre, empleado.Edad, empleado.Estudios, empleado.Puesto);
            }
        }
    }
}
