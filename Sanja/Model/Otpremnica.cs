using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanja.Model
{
    public class Otpremnica
    {
        private int broj;
        private string registracijaVozila;
        private string imeVozaca;
        private string prezimeVozaca;
        private string mestoUtovara;
        private string mestoIstovara;
        private double cena;
        private int kolicina;
        private string vrstaRobe;

        public Otpremnica(int broj, string registracijaVozila, string imeVozaca, string prezimeVozaca, string mestoUtovara, string mestoIstovara, double cena, int kolicina, string vrstaRobe)
        {
            this.broj = broj;
            this.registracijaVozila = registracijaVozila;
            this.imeVozaca = imeVozaca;
            this.prezimeVozaca = prezimeVozaca;
            this.mestoUtovara = mestoUtovara;
            this.mestoIstovara = mestoIstovara;
            this.cena = cena;
            this.kolicina = kolicina;
            this.vrstaRobe = vrstaRobe;
        }

        public int Broj { get => broj; set => broj = value; }
        public string RegistracijaVozila { get => registracijaVozila; set => registracijaVozila = value; }
        public string ImeVozaca { get => imeVozaca; set => imeVozaca = value; }
        public string PrezimeVozaca { get => prezimeVozaca; set => prezimeVozaca = value; }
        public string MestoUtovara { get => mestoUtovara; set => mestoUtovara = value; }
        public string MestoIstovara { get => mestoIstovara; set => mestoIstovara = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public string VrstaRobe { get => vrstaRobe; set => vrstaRobe = value; }
    }
}
