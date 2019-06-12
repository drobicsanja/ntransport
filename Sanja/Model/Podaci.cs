using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanja.Model
{
    public class Podaci
    {
        private ObservableCollection<Vozac> vozaci;
        private ObservableCollection<Kamion> kamioni;
        private ObservableCollection<Cisterna> cisterne;

        public ObservableCollection<Vozac> Vozaci
        {
            get { return this.vozaci; }
            set { this.vozaci = value; }
        }

        public ObservableCollection<Kamion> Kamioni
        {
            get { return this.kamioni; }
            set { this.kamioni = value; }
        }

        public ObservableCollection<Cisterna> Cisterne
        {
            get { return this.cisterne; }
            set { this.cisterne = value; }
        }

    }
}
