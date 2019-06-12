using Sanja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for IzmeniKamion.xaml
    /// </summary>
    public partial class IzmeniKamion : Window
    {
        private MainWindow mw;
        private Kamion kamion;
        private ListaKamiona parent;

        public ObservableCollection<string> Tip
        {
            get;
            set;
        }

        public IzmeniKamion(MainWindow w, ListaKamiona d, Kamion k)
        {
            Tip = new ObservableCollection<string>();
            Tip.Add("Mercedez");
            Tip.Add("Iveco");
            Tip.Add("Renault");
            Tip.Add("Volvo");
            Tip.Add("Daf");
            Tip.Add("Man");

            parent = d;
            mw = w;
            kamion = k;

            InitializeComponent();
            this.DataContext = this;

            tbRegBroj.Text = kamion.Registracija;
            tbKilometraza.Text = kamion.Kilometraza.ToString();
            chbRaspoloziv.IsChecked = kamion.Raspolozivo;
            cbTip.SelectedItem = kamion.Tip;

            tbRegBroj.Text = kamion.Registracija;
            if (String.IsNullOrEmpty(kamion.RegDate))
            {

                datumVazenjeReg.SelectedDate = null;
            }
            else
            {
                datumVazenjeReg.SelectedDate = Convert.ToDateTime(kamion.RegDate);
            }
        }

        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            double km;
            Double.TryParse(tbKilometraza.Text, out km);

            string tip = (String)cbTip.SelectedItem;

            string dateString;

            if (datumVazenjeReg.SelectedDate == null)
            {
                dateString = "";
            }
            else
            {
                DateTime datum = (DateTime)datumVazenjeReg.SelectedDate;
                dateString = datum.ToShortDateString();
            }

            bool raspoloziv;
            if (chbRaspoloziv.IsChecked == true)
            {
                raspoloziv = true;
            }
            else
            {
                raspoloziv = false;
            }

            foreach (Kamion kam in mw.Pod.Kamioni)
            {
                if(kam.Registracija == kamion.Registracija)
                {
                    if (provera())
                    {
                        kam.Kilometraza = km;
                        kam.Tip = tip;
                        kam.RegDate = dateString;
                        kam.Raspolozivo = raspoloziv;
                        parent.dataKamioni.Items.Refresh();
                        this.Close();
                    }
                }
            }
        }

        private bool provera()
        {
            string message = "";
            int flag = -1;

            if (String.IsNullOrEmpty(tbRegBroj.Text))
            {
                message += "Polje za registracioni broj ne sme biti prazno!\n";
                tbRegBroj.Focus();
                flag = 1;
            }

            if (!Regex.Match(tbKilometraza.Text, "^[+]?[0-9.]*$").Success)
            {
                message += "Kilometraza mora biti nenegativan broj (koristite tacku umesto zareza!)\n";
                tbKilometraza.Focus();
                flag = 1;
            }

            if (!String.IsNullOrEmpty(tbKilometraza.Text) && !Double.TryParse(tbKilometraza.Text, out double id))
            {
                message += "Kilometraza mora biti broj!\n";
                tbKilometraza.Focus();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
