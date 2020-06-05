using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp70
{
    class Program
    {
        static void Main(string[] args)
        {
            Name name = new Name(10);
            Console.WriteLine(name[2]);
            Console.WriteLine(name[-3]);
            Console.WriteLine(name[12]);
            name[2] = "X";
            Console.WriteLine(name[2]);
            Console.WriteLine(name["X"]);
            Console.WriteLine(name["Un X"]);
            Console.WriteLine(name["Numele nou"]);
            Console.ReadKey();
        }
    }
    public class Name
    {
        private readonly List<string> names;
        public string this[int index] { get => name_index(index);  set => SetNameByIndex(index, value);}
        public string this[string name] { get => name_name(name); }
        public Name(int count)
        {
            names = new List<string>();
            for (int i = 0; i < count; i++) { names.Add("Random " + i); }
        }
        private string name_index(int index)
        {
            try { string name = names[index]; return name; }
            catch (ArgumentOutOfRangeException) { Console.WriteLine("Index in afara campului"); return null; }
            catch (Exception) { Console.WriteLine("Numele nu a functionat"); return null; }
        }
        private void SetNameByIndex(int index, string value)
        {
            try { names[index] = value; }
            catch (ArgumentOutOfRangeException) { Console.WriteLine("Index in afara campului"); }
            catch (Exception) { Console.WriteLine("Numele nu a functionat"); }
        }
        private string name_name(string find)
        {
            try { string name = names.First(n => n == find); return name; }
            catch (Exception) { Console.WriteLine("Numele " + find + " nu a fost gasit"); return null; }
        }
        private void SetNameByName(string name, string value)
        {
            try { names[name.IndexOf(name)] = value; }
            catch (Exception) { Console.WriteLine("Numele " + value + " nu a fost gasit"); }
        }
    }
}