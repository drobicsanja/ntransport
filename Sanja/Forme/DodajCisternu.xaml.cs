using Sanja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    public partial class DodajCisternu : UserControl
    {
        private Window parentWindow;
        private MainWindow mw;

        public DodajCisternu()
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mw.ListaVozaca.Visibility = Visibility.Hidden;
            mw.ListaKamiona.Visibility = Visibility.Hidden;
            mw.ListaCisterni.Visibility = Visibility.Visible;
            mw.DodajKamion.Visibility = Visibility.Hidden;
            mw.DodajVozaca.Visibility = Visibility.Hidden;
            mw.DodajCisternu.Visibility = Visibility.Hidden;
            mw.Otpremnica.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

            bool opran;
            if (chbOprana.IsChecked == true)
            {
                opran = true;
            }
            else
            {
                opran = false;
            }

            Cisterna c = new Cisterna(tbRegBroj.Text, dateString, opran, raspoloziv);

            if (provera())
            {
                if(mw.Pod.Cisterne == null)
                {
                    if (mw.Pod.Kamioni != null)
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
                    }

                    mw.Pod.Cisterne = new ObservableCollection<Cisterna>();
                    mw.Pod.Cisterne.Add(c);
                    mw.ListaCisterni.dataCisterne.ItemsSource = mw.Pod.Cisterne;
                    mw.ListaCisterni.dataCisterne.Items.Refresh();
                    refreshField();
                }
                else
                {
                    foreach (Cisterna ci in mw.Pod.Cisterne)
                    {
                        if(ci.Registracija == tbRegBroj.Text)
                        {
                            MessageBox.Show("Registracija nije dostupna!");
                            tbRegBroj.Focus();
                            return;
                        }
                    }

                    if(mw.Pod.Kamioni != null)
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
                    }
                    

                    mw.Pod.Cisterne.Add(c);
                    mw.ListaCisterni.dataCisterne.ItemsSource = mw.Pod.Cisterne;
                    mw.ListaCisterni.dataCisterne.Items.Refresh();
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
                message += "ID vozaca ne sme biti prazno!\n";
                tbRegBroj.Focus();
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
            datumVazenjeReg.SelectedDate = null;
            chbOprana.IsChecked = false;
            chbRaspoloziv.IsChecked = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            refreshField();
        }
    }
}
