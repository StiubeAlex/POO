using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp68
{
	class Program
	{
		static void Main(string[] args)
		{
            string path = args.Length > 0 ? args[0] : @"C:\Users\alex_\Desktop\Test.txt";
            string[] lines;
            lines = File.ReadAllLines(path);
            int caractere = 0;
            int linii = 0;
            int vocale = 0;
            int consoane = 0;
            foreach (string line in lines)
            {
                linii++;
                foreach (char v in line)
                {
                    caractere++;
                    if (v == 'a' || v == 'e' || v == 'i' || v == 'o' || v == 'u' || v == 'A' || v == 'E' || v == 'I' || v == 'O' || v == 'U') { vocale++; }
                    else { consoane++; }
                }
            }
            Console.WriteLine("Linii " + linii);
            Console.WriteLine("Caractere " + caractere);
            Console.WriteLine("Vocale " + vocale);
            Console.WriteLine("Consoane " + consoane);
            Console.ReadKey();
        }
	}
}
