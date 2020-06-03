using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaLR
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        { 
            List<int> elemente = new List<int>();
            Console.WriteLine("n");
            int n = int.Parse(Console.ReadLine());
            if (n < 3) { Console.WriteLine("Prea mic"); }
            if (n > 1000000) { Console.WriteLine("Prea mare"); }
            int[] v = new int[n];
            int max = v[0];
            for (int i = 0; i < n; i++)
            {
                v[i] = r.Next(1000000);
                Console.Write(v[i] + " ");
            }
            Console.WriteLine();

            for (int i = 1; i < n - 1; i++)
            {
                if (max <= v[i])
                {
                    bool exista = true;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (v[j] < v[i])
                        {
                            exista = false;
                            break;
                        }
                    }
                    if (exista)
                        elemente.Add(i);
                }
                if (v[i] > max)
                    max = v[i];
            }
            if (elemente.Count() == 0) 
            {
                Console.WriteLine("Nu sunt elemente LR");
            }
            else
            {
                Console.WriteLine("LR:");
                foreach (int index in elemente) 
                {
                    Console.WriteLine("n = " + v[index] + "pe : " + index + 1); 
                }  
            }
            Console.ReadKey();
        }
    }
}