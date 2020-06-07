using System;
namespace Form_2D
{
	class Program
	{
		static void Main(string[] args)
		{
			Cerc cerc = new Cerc(4);
			Patrat patrat = new Patrat(7);
			Print(cerc);
			Print(patrat);
			Console.ReadKey();
		}
		public static void Print(Form form)
		{
			Console.WriteLine("Forma: " + form.Forma);
			Console.WriteLine("Arie: " + form.Arie());
			Console.WriteLine("Perimetru: " + form.Perimetru());
			Console.WriteLine();
		}
	}
}