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
    /// Interaction logic for DodajVozaca.xaml
    /// </summary>
    public partial class DodajVozaca : UserControl
    {
        private Window parentWindow;
        private MainWindow mw;

        public DodajVozaca()
        {
   
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
            int id;
            Int32.TryParse(tbIdVozaca.Text, out id);

            Vozac vozac = new Vozac(id, tbImeVozaca.Text, tbPrezimeVozaca.Text, tbAdresaVozaca.Text, tbJMBGVozaca.Text, tbKontaktVozaca.Text);

            if (provera())
            {
                if(mw.Pod.Vozaci == null)
                {                  
                    mw.Pod.Vozaci = new ObservableCollection<Vozac>();
                    mw.Pod.Vozaci.Add(vozac);
                    mw.ListaVozaca.dataVozaci.ItemsSource = mw.Pod.Vozaci;
                    mw.ListaVozaca.dataVozaci.Items.Refresh();
                    refreshFields();
                }
                else
                {
                    foreach (Vozac v in mw.Pod.Vozaci)
                    {
                        if(v.Id == id)
                        {
                            MessageBox.Show("Vozac sa tim ID-jem vec postoji!");
                            tbIdVozaca.Focus();
                            return;
                        }

                        if(v.JMBG == tbJMBGVozaca.Text)
                        {
                            MessageBox.Show("Vozac sa tim JMBG-om vec postoji!");
                            tbIdVozaca.Focus();
                            return;
                        }
                    }

                    mw.Pod.Vozaci.Add(vozac);
                    mw.ListaVozaca.dataVozaci.ItemsSource = mw.Pod.Vozaci;
                    mw.ListaVozaca.dataVozaci.Items.Refresh();
                    refreshFields();
                    
                }
            }
        }

        private void refreshFields()
        {
            tbIdVozaca.Text = "";
            tbImeVozaca.Text = "";
            tbPrezimeVozaca.Text = "";
            tbAdresaVozaca.Text = "";
            tbJMBGVozaca.Text = "";
            tbKontaktVozaca.Text = "";

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
            refreshFields();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mw.ListaVozaca.Visibility = Visibility.Visible;
            mw.ListaKamiona.Visibility = Visibility.Hidden;
            mw.ListaCisterni.Visibility = Visibility.Hidden;
            mw.DodajKamion.Visibility = Visibility.Hidden;
            mw.DodajVozaca.Visibility = Visibility.Hidden;
            mw.DodajCisternu.Visibility = Visibility.Hidden;
            mw.Otpremnica.Visibility = Visibility.Hidden;
        }
    }
}
