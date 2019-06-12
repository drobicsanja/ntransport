using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanja.Model
{
    public class Cisterna
    {
        private string registracija;
        private string regDate;
        private bool oprana;
        private bool raspolozivo;

        public Cisterna(string registracija, string regDate, bool oprana, bool raspolozivo)
        {
            this.registracija = registracija;
            this.regDate = regDate;
            this.oprana = oprana;
            this.raspolozivo = raspolozivo;
        }

        public string Registracija { get => registracija; set => registracija = value; }
        public string RegDate { get => regDate; set => regDate = value; }
        public bool Oprana { get => oprana; set => oprana = value; }
        public bool Raspolozivo { get => raspolozivo; set => raspolozivo = value; }

    }
}
