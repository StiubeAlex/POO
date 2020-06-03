using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clasa_Elevi
{
    public class Yes : IComparer<Lista>
    {
        public int Compare(Lista a, Lista b)
        {
            int compareAverage = a.Average.CompareTo(b.Average);
            if (compareAverage == 0)
            {
                int compareLastName = a.lastN.CompareTo(b.lastN);
                if (compareLastName == 0) { return a.firstN.CompareTo(b.firstN); }
                return compareLastName;
            }
            return compareAverage;
        }
    }
    class Program
    {
        static List<Lista> medie = new List<Lista>();
        static void Main(string[] args)
        {
            List<Lista> elevi = DataLoad(@"..\..\in.txt");
            medie = Average(elevi);
            IComparer<Lista> comparer = new Yes();
            medie.Sort(comparer);
            foreach (Lista student in medie) { Console.WriteLine(student.Name + " are media: " + student.Average); }
            DataOutput(@"..\..\out.txt");
            Console.ReadKey();
        }
        private static void DataOutput(string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            foreach (var student in medie)
            {
                sw.WriteLine(student);
            }
            sw.Close();
        }
        private static List<Lista> Average(List<Lista> students)
        {
            int average = 0;
            foreach (var student in students)
            {
                average = student.Medie(student.Grades);
                Lista elev = new Lista(student.lastN, student.firstN, average);
                medie.Add(elev);
            }
            return medie;
        }
        public static List<Lista> DataLoad(string filepath)
        {
            List<Lista> students = new List<Lista>();
            StreamReader sr = sr = new StreamReader(filepath);
            Lista elev = new Lista();
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] datas = line.Split(',');
                string[] grades = datas[3].Split(' ');
                elev = new Lista(datas[0], datas[1], datas[2], grades);
                students.Add(elev);
                line = sr.ReadLine();
            }
            return students;
        }
    }
    public class Lista
    {
        public string firstN;
        public string lastN;
        private int gradesN;
        private string[] grades;
        private double average;
        public string Name => lastN + firstN;
        public string[] Grades => grades;
        public double Average => average;
        public Lista() { }
        public Lista(string lastN, string firstN, string numberOfGrades, string[] grades)
        {
            this.firstN = firstN;
            this.lastN = lastN;
            this.gradesN = int.Parse(numberOfGrades);
            this.grades = grades;
        }
        public Lista(string lastN, string firstN, int average)
        {
            this.lastN = lastN;
            this.firstN = firstN;
            this.average = average;
        }
        public int Medie(string[] grades)
        {
            int average = 0;
            foreach (var grade in grades)
            {
                average += int.Parse(grade);
            }
            average /= grades.Length;
            return average;
        }
        public override string ToString() { return $"{this.Name} media: {this.average}"; }
    }
}