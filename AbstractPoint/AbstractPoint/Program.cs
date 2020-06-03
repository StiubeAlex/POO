using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(PointRepresentation.Rectangular, 2, 2);
            Point p2 = new Point(PointRepresentation.Polar, 5, 2);
            p1.Move(5,5);
            p1.Rotate(2);
            p2.Move(0, -5);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.ReadKey();
        }
    }
}
