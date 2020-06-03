using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numar_Mare
{
    internal class NumarMare
    {
        public string num;
        public int cifreA;
        public int cifreB { get { return cifreA; } }
        public NumarMare(string num = "0")
        {
            this.num = num;
            cifreA = num.Length;
        }
        public override string ToString() { return num; }
        public int this[int i] { get { return num[i] - '0'; } }
        public static NumarMare operator +(NumarMare x, NumarMare y)
        {
            int a, b;
            NumarMare c, d;
            if (x.cifreB < y.cifreB) { a = x.cifreB; b = y.cifreB; c = x; d = y; }
            else { a = y.cifreB; b = x.cifreB; c = y; d = x; }
            int i = b - 1, rest = 0, sumCifre; string sum = "";
            while (i > -1)
            {
                int j = a - (b - i);
                sumCifre = j > -1 ? d[i] + c[j] + rest : d[i] + rest;
                if (sumCifre >= 10)
                {
                    rest = 1;
                    sumCifre -= 10;
                }
                else { rest = 0; }
                i--;
                sum = sumCifre + sum;
            }
            if (rest == 1) { sum = "1" + sum; }
            return new NumarMare(sum);
        }
        public static NumarMare operator *(NumarMare w, NumarMare k)
        {
            int n = k.cifreB; string space = "";
            NumarMare sum, produs = new NumarMare("0");
            for (int i = n - 1; i >= 0; i--)
            {
                int m = k[i];
                sum = new NumarMare("0");
                for (int j = 0; j < m; j++) { sum += w; }
                produs += new NumarMare(Convert.ToString(sum) + space);
                space += "0";
            }
            return produs;
        }
        class Program
        {
            static NumarMare[] Fibonacci(int n)
            {
                NumarMare[] fibonacci = new NumarMare[n + 1];
                fibonacci[0] = new NumarMare("0");
                if (n >= 1) { fibonacci[1] = new NumarMare("1"); }
                if (n >= 2)
                {
                    NumarMare a1 = new NumarMare("0"), a2 = new NumarMare("1"), a;
                    for (int i = 2; i <= n; i++)
                    {
                        a = a1; a1 = a2; a2 += a; fibonacci[i] = a2;
                    }
                }
                return fibonacci;
            }
            static void Main(string[] args)
            {
                NumarMare[] fibonacci = Fibonacci(100);
                Console.WriteLine("Elementul 100 din sirul lui Fibonacci este: " + fibonacci[100]);
                Console.ReadKey();
            }
        }
    }
}