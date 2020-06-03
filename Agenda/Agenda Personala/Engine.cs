using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Personala
{
    static class Engine
    {
        public static List<Person> People = new List<Person>();
        public static List<Agenda> Agendas = new List<Agenda>();
        public static List<Activity> Activities = new List<Activity>();
        public static Person CreatePerson(string lname, string fname, DateTime bdate, string email)
        {
            Person person = new Person() { Nume = lname, Prenume = fname, DataNasterii = bdate, adresaEmail = email };
            People.Add(person);
            Console.WriteLine("Persoana: " + person.CreeazaDate() + " a fost creata");
            return person;
        }
        public static Agenda CreateAgenda(this Person person)
        {
            Agenda agenda = new Agenda() { Activities = new List<Activity>(), Detinator = person };
            person.notebook = agenda;
            Agendas.Add(agenda);
            Console.WriteLine("Agenda a fost creata de catre:" + person.CreeazaNume());
            return agenda;
        }
        public static Activity CreateActivity(this Person person, string name, string description, DateTime sdate, DateTime edate)
        {
            Activity activity = new Activity() { Name = name, Description = description, StartDate = sdate, EndDate = edate };
            activity.PeopleInvolved = new List<Person>() { person };
            if (person.notebook == null) person.CreateAgenda();
            { person.notebook.Activities.Add(activity); }
            Activities.Add(activity);
            Console.WriteLine($"Activitatea: " + activity.CreeazaDate() + " a fost creata in agenda persoanei: " + person.CreeazaNume());
            return activity;
        }
        public static Activity CreateActivity(string name, string description, DateTime sdate, DateTime edate)
        {
            Activity activity = new Activity() { Name = name, Description = description, StartDate = sdate, EndDate = edate };
            activity.PeopleInvolved = new List<Person>();
            Activities.Add(activity);
            Console.WriteLine("Activitatea: " + activity.CreeazaDate() + " a fost creata");
            return activity;
        }
        public static Activity AddActivity(this Person person, Activity activity)
        {
            activity.PeopleInvolved.Add(person);
            if (person.notebook == null) person.CreateAgenda();
            { person.notebook.Activities.Add(activity); }
            Console.WriteLine("Activitatea: " + activity.CreeazaDate() + " a fost adaugata in agenda persoanei: " + person.CreeazaNume());
            return activity;
        }
        public static Activity RemoveActivity(this Person person, Activity activity)
        {
            if (person.notebook == null) return activity;
            { person.notebook.Activities.Remove(activity); }
            Console.WriteLine("Activitatea: " + activity.CreeazaDate() + " a fost stearsa din agenda persoanei: " + person.CreeazaNume());
            return activity;
        }
        public static Activity DeleteActivity(Activity activity)
        {
            foreach (Person person in activity.PeopleInvolved) { person.RemoveActivity(activity); }
            activity.PeopleInvolved.Clear();
            Activities.Remove(activity);
            Console.WriteLine($"Activitatea: {activity.CreeazaDate()} a fost stearsa din agenda");
            return activity;
        }
        public static List<Activity> FindActivitiesByNameGlobal(string name)
        {
            name.ToLower().Trim();
            List<Activity> result = Activities.Where(a => a.Name.ToLower().Contains(name)).ToList();
            return result;
        }
        public static List<Activity> FindActivitiesByName(this Person person, string name)
        {
            name.ToLower().Trim();
            if (person.notebook == null) { return new List<Activity>(); }
            List<Activity> result = person.notebook.Activities.Where(a => a.Name.ToLower().Contains(name)).ToList();
            return result;
        }
        public static List<Activity> FindActivitiesByInterval(this Person person, DateTime sdate, DateTime edate)
        {
            if (person.notebook == null) { return new List<Activity>(); }
            List<Activity> result = person.notebook.Activities.Where(a => a.StartDate >= sdate && a.EndDate <= edate).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("Nicio activitate nu a fost gasita");
                return result;
            }
            foreach (Activity activity in result) { Console.WriteLine("Activitatea: " + activity.CreeazaDate() + " este programata in intervalul indicat"); }
            return result;
        }
        public static Activity FindMeetingWithGroup(int maxHours, params Person[] people)
        {
            Activity meeting = new Activity() { Name = "Group Meeting", Description = "Talking" };
            meeting.PeopleInvolved = people.ToList();
            DateTime maxtime = new DateTime();
            foreach (Person person in people)
            {
                if (person.notebook != null)
                {
                    foreach (Activity activity in person.notebook.Activities)
                    {
                        if (activity.EndDate > maxtime) { maxtime = activity.EndDate; }
                    }
                }
            }
            meeting.StartDate = maxtime;
            meeting.EndDate = maxtime.AddHours(maxHours);
            Console.WriteLine("Meeting was found: " + meeting.CreeazaDate());
            foreach (Person person in people) { person.AddActivity(meeting); }
            return meeting;
        }
    }
}