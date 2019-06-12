using Sanja.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ListaVozaca.xaml
    /// </summary>
    public partial class ListaVozaca : UserControl
    {
        private Window parentWindow;
        private MainWindow mw;

        public ListaVozaca()
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

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataVozaci.SelectedIndex != -1)
            {
                Vozac v = (Vozac)dataVozaci.SelectedItem;
                IzmeniVozaca izmenaWindow = new IzmeniVozaca(mw, this, v);
                izmenaWindow.ShowDialog();
            }
        }

        private void BtnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataVozaci.SelectedIndex != -1)
            {
                Vozac v = (Vozac)dataVozaci.SelectedItem;
                mw.Pod.Vozaci.Remove(v);
                dataVozaci.Items.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            mw.ListaVozaca.Visibility = Visibility.Hidden;
            mw.ListaKamiona.Visibility = Visibility.Hidden;
            mw.ListaCisterni.Visibility = Visibility.Hidden;
            mw.DodajKamion.Visibility = Visibility.Hidden;
            mw.DodajVozaca.Visibility = Visibility.Visible;
            mw.DodajCisternu.Visibility = Visibility.Hidden;
            mw.Otpremnica.Visibility = Visibility.Hidden;
        }
    }
}
