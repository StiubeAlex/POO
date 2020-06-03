using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Personala
{
    public class Agenda
    {
        public List<Activity> Activities;
        private Person detinator;

        public Person Detinator
        {
            get { return this.detinator; }
            set { this.detinator = value; }
        }
    }
}