using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Personala
{
    public class Activity
    {
        public string Name;
        public string Description;
        public DateTime StartDate;
        public DateTime EndDate;
        public List<Person> PeopleInvolved;
        public string CreeazaDate()
        {
            return $"{Name}, {Description}, {StartDate.ToString()}, {EndDate.ToString()}";
        }
    }
}