using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp71
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Engine> people = new List<Engine>();
            char[] div = { ' ', ',', '.' };
            string[] lines = File.ReadAllLines("../../input.txt");
            foreach (string line in lines)
            {
                Engine a = new Engine();
                string name = "";
                bool ok = false;
                for (int i = 0; i < line.Length; i++)
                {
                    char b = line[i];
                    if (ok)
                    {
                        if (Ok(b, div) || i == line.Length - 1)
                        {
                            if (i == line.Length - 1) { name += b; }
                            if (a.last == null) { a.last = name; }
                            else if (a.first == null) { a.first = name; }
                            name = "";
                            ok = false;
                        }
                        else
                        {
                            name += b;
                        }
                    }
                    else
                    {
                        if (!Ok(b, div))
                        {
                            ok = true;
                            name += b;
                        }
                    }
                }
                a.format();
                people.Add(a);
            }
            people = people.OrderBy(p => p.last).ThenBy(p => p.first).ToList();
            string output = "";
            foreach (Engine person in people)
            {
                output += person.last + " " + person.first + "\n";
            }
            File.WriteAllText("../../output.txt", output);
        }
        public static bool Ok(char c, char[] divs)
        {
            foreach (char div in divs)
            {
                if (c == div)
                {
                    return true;
                }
            }
            return false;
        }
    }
}