using System;
using System.Linq;
using System.Collections.Generic;
using Rec_Sena.Modelo;


 
namespace Rec_Sena
{
    class Program
    {


        
        static Validaciones Validar = new Validaciones();
        static void Main(string[] args)
        {
            int opc = 0;
            string temporal;
            bool EntradaValida = false;
            do
            {
                
                Console.Clear();
                Console.SetCursorPosition(25, 9); Console.WriteLine("-- Menu Principal ---");
                Console.SetCursorPosition(25, 11); Console.WriteLine("1. Crear un Empleado");
                Console.SetCursorPosition(25, 13); Console.WriteLine("2. Listar Empleado");
                Console.SetCursorPosition(25, 15); Console.WriteLine("3. Buscar un Empleado");
                Console.SetCursorPosition(25, 21); Console.WriteLine("-------------------");
                Console.SetCursorPosition(25, 23); Console.WriteLine("0. SALIR DEL SISTEMA");

                

                do
                {
                    Console.SetCursorPosition(25, 26); Console.WriteLine("Digite una opcion : ");
                    opc = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(50, 26); temporal = Console.ReadLine();
                    if (!Validar.Vacio(temporal))
                        if (Validar.TipoNumero(temporal))
                            EntradaValida = true;

                } while (!EntradaValida);


                switch (opc)
                {
                    case 1:
                        crearEmpleado();
                        break;
                    case 2:
                        listarEmpleado();
                        break;
                    case 3:
                        buscarEmpleado();
                        break;                  
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;


                }

            } while (opc > 0);



            //--------------Metodos 


            static void crearEmpleado()
            {

                
                bool DiasVacacionesValido = false;            
                bool NombreValido = false;
                bool SalarioValido = false;


                var db = new recsenaContext();

                Console.Clear();
                Console.SetCursorPosition(25, 9); Console.WriteLine("-----Crear Empleados-----");
                Console.SetCursorPosition(25, 11); Console.WriteLine("---------------------------");

                 int ced = int.Parse(Console.ReadLine());

                // validar codigo 

                var Existe = db.Empleados.Find(ced);


                if (Existe == null)
                {
                    do
                    {
                        Console.SetCursorPosition(25, 16); Console.Write("Digite El Nombre del Empleado :");
                        Console.SetCursorPosition(60, 16); string nom = Console.ReadLine();
                        if (!Validar.Vacio(nom))
                            if (Validar.TipoTexto(nom))
                                NombreValido = true;
                    } while (!NombreValido);




                    do
                    {
                        Console.SetCursorPosition(25, 18); Console.Write("Digite El Salario del empleado :");
                        Console.SetCursorPosition(60, 18); string sal = Console.ReadLine();
                        if (!Validar.Vacio(sal))
                            if (Validar.TipoNumero(sal))
                                SalarioValido = true;
                    } while (!SalarioValido);


                    do
                    {
                        Console.SetCursorPosition(25, 20); Console.Write(" Digite dias de vacaciones :");
                        Console.SetCursorPosition(60, 20); string DiasV = Console.ReadLine();
                        if (!Validar.Vacio(DiasV))
                            if (Validar.TipoNumero(DiasV))
                                DiasVacacionesValido = true;
                        if (Validar.TipoTexto(DiasV))
                            DiasVacacionesValido = true;
                    } while (!DiasVacacionesValido);



                    Empleados myEmpleado = new Empleados
                    {


                    };

                    db.Empleados.Add(myEmpleado);
                    db.SaveChanges();

                }
                else


                {
                    Console.SetCursorPosition(30, 30); Console.Write("---El no de cedula ya existe---");
                    Console.ReadKey();
                }

               

            }





            static void listarEmpleado()
            {


                Console.WriteLine("... Litar Empleados ...");

                var db = new recsenaContext();
                var empleados = db.Empleados.ToList();
                int y = 4;

                Console.SetCursorPosition(5, y); Console.Write("Cedula");
                Console.SetCursorPosition(15, y); Console.Write("Nombre");
                Console.SetCursorPosition(35, y); Console.Write("Salario");
                Console.SetCursorPosition(45, y); Console.Write("Dias");
                Console.SetCursorPosition(55, y); Console.Write("Vacaciones a pagar ");


                y++;
                foreach (var myEmpleados in empleados)
                {

                    Console.SetCursorPosition(5, y); Console.Write(myEmpleados.Cedula);
                    Console.SetCursorPosition(15, y); Console.Write(myEmpleados.Nombre);
                    Console.SetCursorPosition(35, y); Console.Write(myEmpleados.Salario);
                    Console.SetCursorPosition(45, y); Console.Write(myEmpleados.Dias);
                    Console.SetCursorPosition(55, y); Console.Write(myEmpleados.Vacacionespagar);

                    y++;






                }
            }



            static void buscarEmpleado()
            {
                var db = new recsenaContext();

                string ced;
                bool CedulaValido = false;

                Console.Clear();
                Console.SetCursorPosition(25, 20); Console.WriteLine("-----Buscar Empleados-----");

                Console.SetCursorPosition(25, 24); Console.Write("Digite el no. de cedula  del empleado que desea buscar: ");
                Console.SetCursorPosition(25, 2); int Ced = int.Parse(Console.ReadLine());

                var Existe = db.Empleados.Find(Ced);

                do
                {

                    ced = Console.ReadLine();
                    if (!Validar.Vacio(ced))
                        if (Validar.TipoNumero(ced))
                            CedulaValido = true;
                } while (!CedulaValido);


                if (Existe != null)
                {

                    int y=5;
                    var myEmpleado = db.Empleados.FirstOrDefault(e => e.Cedula == Ced);


                    Console.SetCursorPosition(5, y); Console.Write(myEmpleado.Cedula);
                    Console.SetCursorPosition(15, y); Console.Write(myEmpleado.Nombre);
                    Console.SetCursorPosition(35, y); Console.Write(myEmpleado.Salario);
                    Console.SetCursorPosition(55, y); Console.Write(myEmpleado.Dias);
                    Console.SetCursorPosition(65, y); Console.Write(myEmpleado.Vacacionespagar);

                    y++;

                }
                else
                    Console.SetCursorPosition(25, 20); Console.WriteLine("---el no. de cedula no existe---");

                Console.ReadLine();


            }


        }

        

    }

}



