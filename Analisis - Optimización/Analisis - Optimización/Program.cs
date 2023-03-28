using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analisis___Optimización
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgramaSinHash();
            ProgramaConHash();

            Console.ReadKey();
        }

        private static void ProgramaSinHash()
        {
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            int[] ArregloEntradas = new int[100000];

            for (int i = 0; i < ArregloEntradas.Length; i++)
            {
                ArregloEntradas[i] = i;
            }

            Console.WriteLine("Cantidad de datos almacenados en el arreglo: {0}", ArregloEntradas.Length);

            Console.WriteLine("Tiempo de Ejecución programa 1: " + stopwatch1.ElapsedMilliseconds.ToString() + " Milisegundos");
            stopwatch1.Stop();
        }

        private static void ProgramaConHash()
        {
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            int numEntradas = 100000;

            Hashtable tablaHash = new Hashtable();

            Parallel.For(0, numEntradas, i =>
            {
                tablaHash.Add($"clave{i}", $"valor{i}");
            });

            var listaParesClaveValor = tablaHash.AsParallel().Cast<DictionaryEntry>().Select((entrada, indice) => (entrada.Key, entrada.Value)).ToList();

            Console.WriteLine($"Número de entradas en la tabla hash: {tablaHash.Count}");
            Console.WriteLine($"Número de elementos en la lista de pares clave-valor: {listaParesClaveValor.Count}");

            Console.WriteLine("Tiempo de Ejecución programa 2: " + stopwatch2.ElapsedMilliseconds.ToString() + " Milisegundos");
            stopwatch2.Stop();
        }
    }
}
