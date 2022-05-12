using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Automatas_Finitos_6404
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solicitar la cadena
            Console.Write("Ingresar cadena W: ");
            string w = Console.ReadLine();

            //Contamos cuantos elementos tiene la cadena
            int ele = w.Length;

            //Revisar que la cadena no sea vacÃ­a y tenga al menos 1 elemento
            if (w != "" && ele > 0)
            {
                //cadena: 0100
                string q = "0"; //estado inicial
                char f = '2'; //estado de aceptacion
                string s_ext = ""; //funcion extendida
                for (int i = 0; i < ele; i++) //recorrdio de cada elemento
                {
                    char caracter = w[i]; //elementos

                    //Cada elemento debe pasar por los estados
                    for (int x = 0; x < q.Length; x++) //estados
                    {
                        string AUX = ""; //estado auxiliar 

                        if (q[x].Equals('0')) //estado 0
                        {
                            if (caracter.Equals('0'))
                            {
                                if (i == 0) { AUX = "01"; }
                                else { AUX= AUX + "01"; }

                            }
                            else if (caracter.Equals('1'))
                            {
                                if (i == 0) { AUX = "0"; }
                                else { AUX = AUX + "0"; }
                            }
                        }
                        else if (q[x].Equals('1'))  //estado 1
                        {
                            if (caracter.Equals('0'))
                            {
                                AUX = AUX + "23";
                            }
                            else if (caracter.Equals('1'))
                            {
                                AUX = AUX + "3";
                            }
                        }
                        else if (q[x].Equals('2'))  //estado 2
                        {
                            // con 0 || 1 el estado se queda en 2
                            AUX = AUX + "2";
                        }
                        else if (q[x].Equals('3'))  //estado 3
                        {
                            // con 0 || 1 el estado pasa a 4
                            AUX = AUX + "4";
                        }
                        else if (q[x].Equals('4'))  //estado 4
                        {
                            // con 0 || 1 el estado pasa a 5
                            AUX = AUX + "5";
                        }
                        else if (q[x].Equals('5')) //estado 5
                        {
                            // con 0 ||1 el estado pasa a 6
                            AUX = AUX + "6";
                        }
                        else if (q[x].Equals('6'))  //estado 6
                        {
                            if (caracter.Equals('0'))
                            {
                                AUX= AUX+ "2";
                            }
                            else if (caracter.Equals('1'))
                            {
                                AUX= AUX+ "3";
                            }
                        }

                        q = AUX;

                    }

                }

                //Cuando ya termina de recorre toda la cadena
                s_ext = q;
                Console.WriteLine("valores finales " + s_ext);

                //Comprobar si la intersecciÃ³n de f y s_ext es diferente a vacÃ­o
                string mensaje = "La cadena no ha sido aceptada por el automata";
                for (int y = 0; y < s_ext.Length; y++)
                {
                    if (s_ext[y] == f) { mensaje = "La cadena ha sido aceptada por el automata"; }
                }


                Console.WriteLine(mensaje);

            }
            else
            {
                Console.WriteLine("Debe ingresar una candena");
            }
            Console.ReadKey();

        }
    }
}
