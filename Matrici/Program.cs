using System;
using System.Text;

namespace Matrici
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = m; Console.WriteLine();
            
            Matrice A = new Matrice(m, n);
            Matrice B = new Matrice(m, n);

            A.Generare(m, n); Console.WriteLine(A);
            B.Generare(m, n); Console.WriteLine(B);

            Console.WriteLine("Suma");
            Matrice sum = A.Suma(B); Console.WriteLine(sum);
            Console.WriteLine("Diferenta");
            Matrice dif = A.Scadere(B); Console.WriteLine(dif);
            Console.WriteLine("Produsul");
            Matrice produs = A.Inmultire(B); Console.WriteLine(produs);
            Console.WriteLine("Prima matrice ridicata la a 2-a");
            Matrice putere = A.Putere(2);  Console.WriteLine(putere);
            Console.WriteLine("Transpusa primei matrici");
            Matrice transpusa = A.Transpusa(); Console.WriteLine(transpusa);

            Console.ReadKey();
        }
    }
    class Matrice
    {
        private static Random rnd = new Random();
        private int[,] matrix;
        private int a;
        private int c;
        public Matrice(int l, int c)
        {
            this.a = l;
            this.c = c;
            this.matrix = new int[this.a, this.c];
        }
        public Matrice(int elemente) : this(elemente, elemente) { }
        public void Generare()
        {
            int l = rnd.Next(10);
            int c = rnd.Next(10);
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = rnd.Next(10);
                }
            }
        }

        public void Generare(int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = rnd.Next(10);
                }
            }
        }

        public void Generare(int elemente)
        {
            for (int i = 0; i < elemente; i++)
            {
                for (int j = 0; j < elemente; j++)
                {
                    matrix[i, j] = rnd.Next(10);
                }
            }
        }

        public Matrice Suma(Matrice B)
        {
            int sum = 0;
            Matrice r = new Matrice(this.a, this.c);
                for (int i = 0; i < this.a; i++)
                {
                    for (int j = 0; j < this.c; j++)
                    {
                        sum = matrix[i, j] + B.GetElement(i, j);
                        r.SetElement(i, j, sum);
                    }
                }
            return r;
        }

        public Matrice Scadere(Matrice B)
        {
            int dif;
            Matrice r = new Matrice(this.a, this.c);
                for (int i = 0; i < this.a; i++)
                {
                    for (int j = 0; j < this.c; j++)
                    {
                        dif = matrix[i, j] - B.GetElement(i, j);
                        r.SetElement(i, j, dif);
                    }
                }
            return r;
        }

        public Matrice Inmultire(Matrice B)
        {
            int aux;
            Matrice r = new Matrice(this.a, B.c);
            for (int i = 0; i < this.a; i++)
            {
                for (int j = 0; j < B.c; j++)
                {
                    aux = 0;
                    for (int k = 0; k < this.c; k++)
                    {
                        aux += matrix[i, k] * B.GetElement(k, j);
                    }
                    r.SetElement(i, j, aux);
                }
            }
            return r;
        }

        public Matrice Putere(int pow)
        {
            Matrice r = this;
            if (pow == 1)
            {
                return this;
            }
            else
            {
                for (int i = 0; i < pow - 1; i++)
                {
                    r = r.Inmultire(this);
                }
                return r;
            }
        }

        public Matrice Transpusa()
        {
            Matrice r = new Matrice(this.a, this.c);
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    r.SetElement(i, j, matrix[j, i]);
                }
            }
            return r;
        }
        private void SetElement(int i, int j, int sum) { matrix[i, j] = sum; }
        private int GetElement(int i, int j) { return matrix[i, j]; }
        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    print.Append(matrix[i, j] + " ");
                }
                print.AppendLine();
            }
            return print.ToString();
        }
    }
}