using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Personala
{
    public class Person
    {
        private string numeFam;
        private string prenume;
        public DateTime dataNasterii;
        public string adresaEmail;
        public Agenda notebook;
        public string Nume
        {
            get { return numeFam; }
            set { numeFam = value; }
        }
        public string Prenume
        {
            get { return prenume; }
            set { prenume = value; }
        }
        public DateTime DataNasterii
        {
            get { return dataNasterii; }
            set { dataNasterii = value; }
        }
        public string CreeazaNume() { return $"{this.numeFam} {this.prenume}"; }
        public string CreeazaDate() { return $"{CreeazaNume()}, {this.DataNasterii.ToShortDateString()}, {adresaEmail}"; }
    }
}