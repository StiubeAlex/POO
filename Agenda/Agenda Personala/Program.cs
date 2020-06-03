using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Personala
{
    class Program
    {
        static void Main(string[] args)
        {
            Person tesla = Engine.CreatePerson("Nikola", "Tesla", new DateTime(1856, 7, 10), "tesla_nikola@yahoo.com");
            Person turing = Engine.CreatePerson("Alan", "Turing", new DateTime(1912, 6, 23), "turing.al@gmail.com");
            Console.WriteLine();
            Activity plimbari = tesla.CreateActivity("plimbari", "(prin parc)", DateTime.Now, DateTime.Now.AddHours(1));
            Activity hobby = Engine.CreateActivity("sport", "(alergare)", DateTime.Now, DateTime.Now.AddHours(3));
            Console.WriteLine();
            Console.WriteLine();
            turing.AddActivity(plimbari);
            turing.AddActivity(hobby);
            Console.WriteLine();
            List<Activity> allactivities = tesla.FindActivitiesByName("hobby");
            turing.FindActivitiesByInterval(new DateTime(2020, 4, 23), new DateTime(2020, 4, 24));
            Console.WriteLine();
            Engine.DeleteActivity(plimbari);
            Console.WriteLine();
            Engine.FindMeetingWithGroup(2, tesla, turing);
            Console.ReadLine();
        }
    }
}