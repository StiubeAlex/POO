using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("x:"); Complex c1 = new Complex(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("y:"); Complex c2 = new Complex(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.Write("x^n, n = "); int pow = int.Parse(Console.ReadLine()); Console.WriteLine();
            Complex sum = c1 + c2; Console.Write("x+y= "); Console.WriteLine(sum);
            Complex dif = c1 - c2; Console.Write("x-y= "); Console.WriteLine(dif);
            Complex mul = c1 * c2; Console.Write("x*y= "); Console.WriteLine(mul);
            Complex powC = c1 ^ pow; Console.Write("x^n= "); Console.WriteLine(powC);
            Console.ReadKey();
        }
    }

    //x = a + bi y = c + di
    //x +- y = (a +- b) + (c +- d)i 
    //x * y = (a * c - b * d) + (a * d + b * c)i
    //x ^ n = x * ... * x

    public class Complex
    {
        private float real;
        private float img;
        public Complex() { }
        public Complex(float Real, float Img)
        {
            this.real = Real;
            this.img = Img;
        }
        static public Complex operator +(Complex left, Complex right)
        {
            Complex a = new Complex();
            a.real = left.real + right.real;
            a.img = left.img + right.img;
            a.img = left.img + right.img;
            return a;
        }
        static public Complex operator -(Complex left, Complex right)
        {
            Complex b = new Complex();
            b.real = left.real - right.real;
            b.img = left.img - right.img;
            return b;
        }
        static public Complex operator *(Complex left, Complex right)
        {
            Complex c = new Complex();
            c.real = left.real * right.real - left.img * right.img;
            c.img = left.real * right.img + left.img * right.real;
            return c;
        }
        static public Complex operator ^(Complex x, int pow)
        {
            Complex d = x;
            for (int i = 0; i < pow - 1; i++) { d = d * x; }
            return d;
        }
        public override string ToString()
        {
            return real + " + " + img + "i";
        }
    }
}