using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanja.Model
{
    public class Kamion
    {
        private string registracija;
        private string tip;
        private string regDate;
        private double kilometraza;
        private bool raspolozivo;

        public Kamion(string registracija, string tip, string regDate, double kilometraza, bool raspolozivo)
        {
            this.registracija = registracija;
            this.tip = tip;
            this.regDate = regDate;
            this.kilometraza = kilometraza;
            this.raspolozivo = raspolozivo;
        }

        public string Registracija { get => registracija; set => registracija = value; }
        public string Tip { get => tip; set => tip = value; }
        public string RegDate { get => regDate; set => regDate = value; }
        public double Kilometraza { get => kilometraza; set => kilometraza = value; }
        public bool Raspolozivo { get => raspolozivo; set => raspolozivo = value; }
    }
}
