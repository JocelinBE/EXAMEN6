using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //librería necesaria para el manejo de archivos

namespace programa39_prácticaArchivodeTextoFlujosdeCaracter
{
    class Program
    {
        // Clase 
        public class Amazon
        {
            // Campos 
            public string NombreProducto, Descripción;
            public float Precio;
            public int Cantidad;

            StreamWriter sw = null; //declaración flujo de escritura
            StreamReader sr = null; //declaración flujo de lectura


            public void CrearAchivo()
            {
                //Variable local del método
                char resp;

                try
                {
                    // Crea flujo de escritura hacia el archivo Productos.txt
                    sw = new StreamWriter("Productos.txt");


                    do
                    {
                        // Captura de datos
                        Console.Clear();
                        Console.Write("\nEscriba el nombre del producto: ");
                        NombreProducto = Console.ReadLine();
                        Console.Write("Escriba la descripción del producto: ");
                        Descripción = Console.ReadLine();
                        Console.Write("Escriba el precio del producto: ");
                        Precio = float.Parse(Console.ReadLine());
                        Console.Write("Cantidad a comprar: ");
                        Cantidad = int.Parse(Console.ReadLine());

                        //Escribe los datos al archivo
                        sw.WriteLine("Producto: " + NombreProducto);
                        sw.WriteLine("Descripción: " + Descripción);
                        sw.WriteLine("Precio: {0:C}", Precio);
                        sw.WriteLine("Cantidad: " + Cantidad);

                        Console.Write("\n¿Desea agregar otro producto? (s/n): ");
                        resp = Char.Parse(Console.ReadLine());
                    }
                    while ((resp == 's') || (resp == 'S'));
                    {

                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("\nError : " + e.Message);
                    Console.WriteLine("\nRuta : " + e.StackTrace);
                }
                finally
                {
                    // Cierra el flujo de escritura
                    if (sw != null) sw.Close();

                    Console.Write("\nPresione ENETER para regresar al Menú.");
                    Console.ReadKey();
                }
            }
            public void LeerArchivo()
            {

                try
                {
                    sr = new StreamReader("Productos.txt");

                    // Despliegue de datos 
                    Console.Clear();


                    // Lectura de registros
                    NombreProducto = sr.ReadLine();
                    Descripción = sr.ReadLine();
                    Precio = sr.Read();
                    Cantidad = sr.Read();

                    //Muestra los datos en pantalla
                    Console.WriteLine("Producto: " + NombreProducto);
                    Console.WriteLine("Descripción: " + Descripción);
                    Console.WriteLine("Precio: {0:C}", Precio);
                    Console.WriteLine("Cantidad: " + Cantidad);
                    Console.WriteLine("\n");

                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine("\n\nFin del Inventario");
                    Console.Write("\nPresione ENTER para continuar");
                }
                finally
                {
                    // Cierra el flujo de lectura
                    if (sr != null) sr.Close();
                    Console.Write("\nPresione ENTER para terminar la lectura de datos y regresar al menú");
                    Console.ReadKey();
                }
            }


            static void Main(string[] args)
            {
                // Variable
                int Opción;

                // Objeto
                Amazon inventario = new Amazon();
                // Menú de opciones
                do
                {
                    Console.Clear();
                    Console.WriteLine("Inventario Amazon");
                    Console.WriteLine("1) Llenar inventario.");
                    Console.WriteLine("2) Ver inventario.");
                    Console.WriteLine("3) Salir del programa.");
                    Console.Write("\nTeclee una opción del menú: ");
                    Opción = Int16.Parse(Console.ReadLine());

                    switch (Opción)
                    {
                        case 1:

                            try
                            {
                                // Llamada al metodo
                                inventario.CrearAchivo();
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("\nError: " + e.Message);
                                Console.WriteLine("\nRuta: " + e.StackTrace);
                            }
                            break;

                        case 2:
                            // Bloque de lectura 
                            try
                            {
                                // Llamada al metodo
                                inventario.LeerArchivo();
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("\nError: " + e.Message);
                                Console.WriteLine("\nRuta: " + e.StackTrace);
                            }
                            break;
                        case 3:
                            // bloque de salida:
                            Console.WriteLine("\n¡Gracias por su preferencia, vuelva pronto.");
                            Console.Write("Presione ENTER para salir del programa...");
                            Console.ReadKey();
                            break;
                        default:
                            Console.Write("\nPor favor, ingrese una opción válida del menú. \nPesione <ENTER> para continuar.");
                            Console.ReadKey();
                            break;
                    }


                }
                while (Opción != 3);
                {

                }
            }
        }

    }
}
