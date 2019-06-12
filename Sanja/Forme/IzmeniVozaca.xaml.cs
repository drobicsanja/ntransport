using Sanja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sanja.Forme
{
    /// <summary>
    /// Interaction logic for IzmeniVozaca.xaml
    /// </summary>
    public partial class IzmeniVozaca : Window
    {
        private MainWindow mw;
        private Vozac vozac;
        private ListaVozaca parent;

        public IzmeniVozaca(MainWindow w, ListaVozaca d, Vozac v)
        {
            parent = d;
            mw = w;
            vozac = v;

            InitializeComponent();
            this.DataContext = this;

            tbIdVozaca.Text = vozac.Id.ToString();
            tbImeVozaca.Text = vozac.Ime;
            tbPrezimeVozaca.Text = vozac.Prezime;
            tbAdresaVozaca.Text = vozac.Adresa;
            tbJMBGVozaca.Text = vozac.JMBG;
            tbKontaktVozaca.Text = vozac.Kontakt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            foreach (Vozac v in mw.Pod.Vozaci)
            {
                if(v.Id == vozac.Id)
                {
                    if (provera())
                    {
                        v.Ime = tbImeVozaca.Text;
                        v.Prezime = tbPrezimeVozaca.Text;
                        v.Adresa = tbAdresaVozaca.Text;
                        v.Kontakt = tbKontaktVozaca.Text;
                        parent.dataVozaci.Items.Refresh();
                        this.Close();
                    }
                }
            }

        }

        private bool provera()
        {
            string message = "";
            int flag = -1;

            if (String.IsNullOrEmpty(tbIdVozaca.Text))
            {
                message += "ID vozaca ne sme biti prazno!\n";
                tbIdVozaca.Focus();
                flag = 1;
            }
            if (!String.IsNullOrEmpty(tbIdVozaca.Text) && !Int32.TryParse(tbIdVozaca.Text, out int id))
            {
                message += "ID vozaca mora biti broj!\n";
                tbIdVozaca.Focus();
                flag = 1;
            }
            if (!String.IsNullOrEmpty(tbIdVozaca.Text) && (tbIdVozaca.Text[0] == '-' || tbIdVozaca.Text[0] == '+'))
            {
                message += "ID vozaca mora biti pozitivan ceo broj!\n";
                tbIdVozaca.Focus();
                flag = 1;
            }
            if (tbIdVozaca.Text.Length > 1 && tbIdVozaca.Text[0] == '0')
            {
                message += "ID vozaca ne moze da pocnje sa 0!\n";
                tbIdVozaca.Focus();
                flag = 1;
            }
            if (String.IsNullOrEmpty(tbImeVozaca.Text))
            {
                message += "Ime klijenta ne sme biti prazno!\n";
                tbImeVozaca.Focus();
                flag = 1;
            }

            if (String.IsNullOrEmpty(tbJMBGVozaca.Text))
            {
                message += "JMBG ne sme biti prazan!";
                tbJMBGVozaca.Focus();
                flag = 1;
            }

            if (!Regex.Match(tbJMBGVozaca.Text, "^[0-9]*$").Success)
            {
                message += "Neispravan JMBG!\n";
                tbJMBGVozaca.Focus();
                flag = 1;
            }

            if (!String.IsNullOrEmpty(tbJMBGVozaca.Text) && tbJMBGVozaca.Text.Length != 13)
            {
                message += "Neispravan JMBG!\n";
                tbJMBGVozaca.Focus();
                flag = 1;
            }

            if (flag == 1)
            {
                MessageBox.Show(message);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
