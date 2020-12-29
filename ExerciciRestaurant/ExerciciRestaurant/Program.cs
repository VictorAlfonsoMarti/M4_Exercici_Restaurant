using System;
using System.Collections.Generic;

namespace ExerciciRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant();
        }


        public static void Restaurant()
        {
            int billete5;
            int billete10;
            int billete20;
            int billete50;
            int billete100;
            int billete200;
            int billete500;

            int precioTotal;

            //creamos el menu
            Dictionary<string, int> menu = CrearMenu();

            Console.WriteLine("Platos      Precio");
            //mostramos el menu
            foreach (KeyValuePair<string, int> x in menu) //recorremos el menu
            {
                Console.WriteLine("{0}         {1}", x.Key, x.Value);
            }

            // hacemos seleccion de menu
            List<string> menuSeleccionado = SeleccionMenu(menu);

            //mostramos el menu seleccionado
            Console.WriteLine("Platos Seleccionados:");
            menuSeleccionado.ForEach(Console.WriteLine);

            //mostramos el precio final
            int precioFinal = PrecioSeleccion(menu, menuSeleccionado);
            Console.WriteLine("Total a pagar: {0}", precioFinal);

        }



        public static Dictionary<string, int> CrearMenu()
        {
            int numPlatosMenu = 0;
            
            while (numPlatosMenu == 0)
            {
                try
                {
                    Console.WriteLine("Indica el número de platos que hay en la carta:");
                    numPlatosMenu = Convert.ToInt32(Console.ReadLine()); //numero de platos en la carta
                }
                catch (System.FormatException nPlatos)
                {
                    Console.WriteLine(nPlatos.Message);
                }
            }
            

            Dictionary<string, int> menu = new Dictionary<string, int>(); // creamos un diccionario vacio
            
            string plato; 
            int precio;


            for (int x = 0; x < numPlatosMenu; x++) //pedimos al usuario que rellene el menu
            {
                Console.WriteLine("Nombre del plato {0}:", x + 1);
                plato = Console.ReadLine(); //guardamos el plato;
                Console.WriteLine("Precio del plato {0}:", plato);
                precio = Convert.ToInt32(Console.ReadLine()); // guardamos el precio en int
                try
                {
                    if (plato == "")  // revisamos si se ha introducido otra cosa que no sea 1 o 2
                    {
                        throw new System.ArgumentException("ERROR: Plato Vacio"); //añadimos un nuevo error
                    }
                }
                catch (System.ArgumentException vacio) // printamos error
                {
                    Console.WriteLine(vacio.Message);
                }
                menu.Add(plato, precio); // añadimos al diccionario el plato y el precio
            }

            return menu;
        }

        public static List<string> SeleccionMenu(Dictionary<string, int> menu)
        {
            // creamos seleccion de platos
            List<string> menuSeleccionado = new List<string>(); // creamos lista para platos
            int lleno = 1;


            while (lleno == 1)
            {
                Console.WriteLine("¿Qué plato quieres?");
                menuSeleccionado.Add(Console.ReadLine()); //añadimos a la lista

                Console.WriteLine("¿Quieres seguir añadiendo platos? 1:Si || 2:No");
                string seguir = Console.ReadLine() ;
                if (seguir.Equals("2"))
                {
                    lleno = 2;
                    break;
                }
                try 
                {
                    if (seguir != "1")  // revisamos si se ha introducido otra cosa que no sea 1 o 2
                    {
                        throw new System.ArgumentException("ERROR: Debes introducir 1 para seguir o 2 para salir."); //añadimos un nuevo error
                    }
                }
                catch (System.ArgumentException ex) // printamos error
                {
                    Console.WriteLine(ex.Message);
                    lleno = 1; // nos aseguramos de seguir pidiendo platos
                }
            }
            return menuSeleccionado;
        }


        public static int PrecioSeleccion(Dictionary<string, int> menu, List<string> seleccion)
        {
            int precioFinal = 0;

            for (int x = 0; x < seleccion.Count; x++) //recorremos toda la lista
            {
                for (int y = 0; y < menu.Count; y++) //recorremos por cada posicion en lista todo el diccionario
                {
                    if (menu.ContainsKey(seleccion[x])) //si contiene dentro de menu
                    { 
                        precioFinal = precioFinal + menu.GetValueOrDefault(seleccion[x],0) ; // añadimos el precio al precio final.
                    }
                }
            }
            return precioFinal;
        }


    }
}
