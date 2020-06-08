using System;
namespace ConsoleApp72
{
	public class SubscriberA
	{
		public void SendA(int data)
		{
			Console.WriteLine("Eventiment primit de A: " + data);
		}
	}
	public class SubscriberB
	{
		public void SendB(int data)
		{
			Console.WriteLine("Eventiment primit de B: " + data);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Publisher publisher = new Publisher();
			SubscriberA subA = new SubscriberA();
			SubscriberB subB = new SubscriberB();

			publisher.@event += ok;
			publisher.@event += subA.SendA;
			publisher.@event += subB.SendB;
			publisher.createEvent(1);
			Console.ReadKey();
		}
		static void ok(int time)
		{
			Console.WriteLine("Eveniment creat: " + time);
		}
	}
	public delegate void iteratie(int time);
	public class Publisher
	{
		public event iteratie @event;
		public void createEvent(int time)
		{
			for (int i = 0; i < 5; i++)
			{
				@event?.Invoke(time);
			}
		}
	}
}