/*
Programa:       ex02_ColonizacionMarte
Contacto:       Juan Dario Rodas - jdrodas@hotmail.com
Propósito:
----------
- Ejercicio utilizando condicionales, ciclos de control, funciones, arreglos
Colonización de Marte – Envío de Recursos
El exitoso lanzamiento del Falcon Heavy como transporte confiable interplanetario, 
abrió las posibilidades a la colonización interplanetaria, con primer objetivo el 
establecer asentamientos humanos en Marte.
Para ello, se realizarán 15 lanzamientos de materiales necesarios para la colonización, 
que estarán ubicados en las planicies (A)cidalia, (E)lysium y (U)topia. Cada lanzamiento 
tiene un cargamento de hasta 10.000 kg, pero por posibles daños durante el transporte, 
puede llegar menos cantidad. También se puede dar el caso que no llegue ninguno de los 
15 lanzamientos a alguna de las planicies.
Se requiere hacer un programa que permita capturar para cada lanzamiento a cuál planicie 
corresponde y cuánto material llegó, teniendo en cuenta el rango de valores válidos para 
los lanzamientos. Si la planicie no es válida o el valor no está en el rango, debe 
repetirse el ingreso del dato. 
Posteriormente se generarán los siguientes resultados por cada planicie:
- Cuantos lanzamientos llegaron a cada planicie
- El total de material que llegó intacto a cada planicie
- El promedio de efectividad del transporte a cada planicie: total de material dividido 
  por la cantidad de lanzamientos.
El programa debe:
- Utilizar arreglos, tanto para identificar las planicies como para almacenar el total de 
  lanzamientos, el total de material y el promedio.
- Realizar función CalculaPromedioEfectividad que recibe los arreglos que contienen la 
  cantidad de lanzamientos y total Material para que retorne el arreglo con los promedios.
- Debe visualizar de manera tabulada los resultados para cada planicie, es decir, en una sola 
  línea por cada planicie, escribir total lanzamientos, total material y promedio de efectividad.
- Debe tener control de excepciones en caso de se presenten errores por formato inválido y 
  posibles divisiones por cero.
*/

using System;

namespace ColonizacionMarte
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Colonización a Marte - Envío de material a las planicies");
            Console.WriteLine("Se realizarán 15 lanzamientos de materiales necesarios para la colonización,");
            Console.WriteLine("que estarán ubicados en las planicies (A)cidalia, (E)lysium y (U)topia.");
            Console.WriteLine("Cada lanzamiento tiene un cargamento de hasta 10.000 kg.\n");

            Lanzamiento[] ArregloLanzamientos = new Lanzamiento[15];
            int i = 0;

            //inicializamos los arreglos que totalizan
            while(i < ArregloLanzamientos.Length)
            {
                ArregloLanzamientos[i] = new Lanzamiento();
                Console.WriteLine($"Ingrese en destino para el lanzamiento {i+1}: ");
                ArregloLanzamientos[i].planicie = Console.ReadLine().ToUpper();
                if (ArregloLanzamientos[i].planicie == "A" || ArregloLanzamientos[i].planicie == "E" || ArregloLanzamientos[i].planicie == "U")
                {
                    bool valido = false;
                    while(valido == false)
                    {

                        try
                        {
                            Console.WriteLine($"Ingrese la carga con la que llegó el lanzamiento {i+1}: ");
                            ArregloLanzamientos[i].carga = float.Parse(Console.ReadLine());

                            if (ArregloLanzamientos[i].carga <= 0 || ArregloLanzamientos[i].carga >= 10000)
                                Console.WriteLine("La carga del lanzamiento es un número no válido, intente nuevamente\n");                          
                            else
                            {
                                valido = true;
                                i++;
                            }

                        }
                        catch (FormatException error)
                        {
                            Console.WriteLine("Ingresaste un dato no numérico. Intenta nuevamente!");
                            Console.WriteLine("Error: {0} \n", error.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ingresaste un destino inválido. Intenta nuevamente! \n");
                }
            }

          
                float promedios = Promedios(ArregloLanzamientos);
                //float[] promedios = new float[1];
        

            //Aqui visualizamos resultados
            Console.WriteLine("\n\nResultados obtenidos de los lanzamientos:\n");
            Console.WriteLine("Las planicies son A(cidalia), E(lysium) y U(topia)\n");

            for(i = 0; i < ArregloLanzamientos.Length; i++)
            {
                Console.WriteLine($"Lanzamiento N°{i+1}: ");
                Console.WriteLine($"Carga: {ArregloLanzamientos[i].carga} kg");
                Console.WriteLine($"Destino: {ArregloLanzamientos[i].planicie}");
            }

            Console.WriteLine($"\nPromedio: {promedios}");


        }
        
        static float Promedios(Lanzamiento[] lanzamientos)
        {

            float promedios = 0;
            int i;

            for(i = 0; i < lanzamientos.Length; i++)
            {
                promedios += lanzamientos[i].carga;

            }
            promedios /= lanzamientos.Length;

            return promedios;
        }
        
        /// <summary>
        /// Función que calcula el promedio de carga recibido en cada planicie segun el número de lanzamientos
        /// </summary>
        /// <param name="arregloLanzamientos">Total de lanzamientos por planicie</param>
        /// <param name="arregloCargas">Total Carga recibida por planicie</param>
        /// <returns>los promedios de carga recibidos por planicie</returns>
        /*static float[] CalculaPromedioEfectividad(int[] arregloLanzamientos, float[] arregloCargas)
        {
            float[] promedios = new float[3];

            //aqui calculamos el promedio, evitando la división por cero
            for (int i = 0; i < promedios.Length; i++)
            {
                //Si no hay lanzamientos, el promedio es cero
                if (arregloLanzamientos[i] == 0)
                    promedios[i] = 0;
                else
                    promedios[i] = arregloCargas[i] / arregloLanzamientos[i];
            }
            return promedios;
        }*/
    }
}