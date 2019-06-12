using Sanja.Forme;
using Sanja.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Sanja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Podaci pod;

        public Podaci Pod
        {
            get { return this.pod; }
            set { this.pod = value; }
        }

        public MainWindow()
        {
            pod = new Podaci();
            InitializeComponent();
            this.DataContext = this;

            ListaVozaca.dataVozaci.ItemsSource = Pod.Vozaci;
            ListaKamiona.dataKamioni.ItemsSource = Pod.Kamioni;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MiDodajCisternu_Click(object sender, RoutedEventArgs e)
        {
            ListaVozaca.Visibility = Visibility.Hidden;
            ListaKamiona.Visibility = Visibility.Hidden;
            ListaCisterni.Visibility = Visibility.Hidden;
            DodajKamion.Visibility = Visibility.Hidden;
            DodajVozaca.Visibility = Visibility.Hidden;
            DodajCisternu.Visibility = Visibility.Visible;
            Otpremnica.Visibility = Visibility.Hidden;
        }

        private void MiDodajKamion_Click(object sender, RoutedEventArgs e)
        {
            ListaVozaca.Visibility = Visibility.Hidden;
            ListaKamiona.Visibility = Visibility.Hidden;
            ListaCisterni.Visibility = Visibility.Hidden;
            DodajKamion.Visibility = Visibility.Visible;
            DodajVozaca.Visibility = Visibility.Hidden;
            DodajCisternu.Visibility = Visibility.Hidden;
            Otpremnica.Visibility = Visibility.Hidden;
        }

        private void MiDodajVozaca_Click(object sender, RoutedEventArgs e)
        {
            ListaVozaca.Visibility = Visibility.Hidden;
            ListaKamiona.Visibility = Visibility.Hidden;
            ListaCisterni.Visibility = Visibility.Hidden;
            DodajKamion.Visibility = Visibility.Hidden;
            DodajVozaca.Visibility = Visibility.Visible;
            DodajCisternu.Visibility = Visibility.Hidden;
            Otpremnica.Visibility = Visibility.Hidden;
        }

        private void MiDodajOtpremnicu_Click(object sender, RoutedEventArgs e)
        {
            ListaVozaca.Visibility = Visibility.Hidden;
            ListaKamiona.Visibility = Visibility.Hidden;
            ListaCisterni.Visibility = Visibility.Hidden;
            DodajKamion.Visibility = Visibility.Hidden;
            DodajVozaca.Visibility = Visibility.Hidden;
            DodajCisternu.Visibility = Visibility.Hidden;
            Otpremnica.Visibility = Visibility.Visible;
        }

        private void MiHelp_Click(object sender, RoutedEventArgs e)
        {
            //string workingDirectory = Environment.CurrentDirectory;
            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;           
            System.Diagnostics.Process.Start(System.IO.Path.GetFullPath(@"..\..\Help.chm"));
        }
    }
}
