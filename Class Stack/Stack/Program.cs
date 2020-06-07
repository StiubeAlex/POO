using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
	class Program
	{
		static void Main(string[] args)
		{
            Stack<int> ints = new Stack<int>(3);
            ints.inn(5);
            Console.WriteLine(ints.ok());
            ints.ok();
            ints.inn(2);
            ints.inn(1);
            Console.WriteLine();
            Stack<string> strings = new Stack<string>(2);
            strings.inn("Yes");
            strings.inn("Ok");
            strings.Clear();
            Console.ReadKey();
        }
	}
}
