using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanja.Model
{
    public class Vozac
    {
        private int id;
        private string ime;
        private string prezime;
        private string adresa;
        private string jmbg;
        private string kontakt;

        public Vozac(int id, string ime, string prezime, string adresa, string jmbg, string kontakt)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.jmbg = jmbg;
            this.kontakt = kontakt;
        }

        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string JMBG { get => jmbg; set => jmbg = value; }
        public string Kontakt { get => kontakt; set => kontakt = value; }
    }
}
