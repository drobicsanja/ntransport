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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sanja.Forme
{
    /// <summary>
    /// Interaction logic for DodajCisternu.xaml
    /// </summary>
    public partial class DodajKamion : UserControl
    {
        private Window parentWindow;
        private MainWindow mw;

        public ObservableCollection<string> Tip
        {
            get;
            set;
        }

        public DodajKamion()
        {
            Tip = new ObservableCollection<string>();
            Tip.Add("Mercedez");
            Tip.Add("Iveco");
            Tip.Add("Renault");
            Tip.Add("Volvo");
            Tip.Add("Daf");
            Tip.Add("Man");

            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainView_Loaded);
            this.DataContext = this;
        }

        void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = Window.GetWindow(this);
            mw = parentWindow as MainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double km;
            Double.TryParse(tbKilometraza.Text, out km);

            string tip = (String)cbTip.SelectedItem;

            string dateString;

            if(datumVazenjeReg.SelectedDate == null)
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

            Kamion k = new Kamion(tbRegBroj.Text, tip, dateString, km, raspoloziv);

            if (provera())
            {
                if(mw.Pod.Kamioni == null)
                {
                    if (mw.Pod.Cisterne != null)
                    {
                        foreach (Cisterna ci in mw.Pod.Cisterne)
                        {
                            if (ci.Registracija == tbRegBroj.Text)
                            {
                                MessageBox.Show("Registracija nije dostupna!");
                                tbRegBroj.Focus();
                                return;
                            }
                        }
                    }

                    mw.Pod.Kamioni = new ObservableCollection<Kamion>();
                    mw.Pod.Kamioni.Add(k);
                    mw.ListaKamiona.dataKamioni.ItemsSource = mw.Pod.Kamioni;
                    mw.ListaKamiona.dataKamioni.Items.Refresh();
                    refreshField();
                }
                else
                {
                    foreach (Kamion kam in mw.Pod.Kamioni)
                    {
                        if (kam.Registracija == tbRegBroj.Text)
                        {
                            MessageBox.Show("Registracija nije dostupna!");
                            tbRegBroj.Focus();
                            return;
                        }
                    }

                    if (mw.Pod.Cisterne != null)
                    {
                        foreach (Cisterna ci in mw.Pod.Cisterne)
                        {
                            if (ci.Registracija == tbRegBroj.Text)
                            {
                                MessageBox.Show("Registracija nije dostupna!");
                                tbRegBroj.Focus();
                                return;
                            }
                        }
                    }
                   

                    mw.Pod.Kamioni.Add(k);
                    mw.ListaKamiona.dataKamioni.ItemsSource = mw.Pod.Kamioni;
                    mw.ListaKamiona.dataKamioni.Items.Refresh();
                    refreshField();
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
                message += "Kilometraza mora biti broj\n";
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

        private void refreshField()
        {
            tbRegBroj.Text = "";
            tbKilometraza.Text = "";
            chbRaspoloziv.IsChecked = false;
            cbTip.SelectedIndex = -1;
            datumVazenjeReg.SelectedDate = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mw.ListaVozaca.Visibility = Visibility.Hidden;
            mw.ListaKamiona.Visibility = Visibility.Visible;
            mw.ListaCisterni.Visibility = Visibility.Hidden;
            mw.DodajKamion.Visibility = Visibility.Hidden;
            mw.DodajVozaca.Visibility = Visibility.Hidden;
            mw.DodajCisternu.Visibility = Visibility.Hidden;
            mw.Otpremnica.Visibility = Visibility.Hidden;
        }
    }
}
