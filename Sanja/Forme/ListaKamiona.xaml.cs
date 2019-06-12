using Sanja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ListaKamiona.xaml
    /// </summary>
    public partial class ListaKamiona : UserControl, INotifyPropertyChanged
    {

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Window parentWindow;
        private MainWindow mw;
        private ObservableCollection<Kamion> kamion_searchView;

        private string _pretraga;
        public string Pretraga
        {
            get
            {
                return _pretraga;
            }
            set
            {
                if (_pretraga != value)
                {
                    _pretraga = value;
                    OnPropertyChanged("Pretraga");
                }
            }
        }

        public ListaKamiona()
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
            mw.ListaVozaca.Visibility = Visibility.Hidden;
            mw.ListaKamiona.Visibility = Visibility.Hidden;
            mw.ListaCisterni.Visibility = Visibility.Hidden;
            mw.DodajKamion.Visibility = Visibility.Visible;
            mw.DodajVozaca.Visibility = Visibility.Hidden;
            mw.DodajCisternu.Visibility = Visibility.Hidden;
            mw.Otpremnica.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(dataKamioni.SelectedIndex != -1)
            {
                Kamion k = (Kamion)dataKamioni.SelectedItem;
                IzmeniKamion izmenaWindow = new IzmeniKamion(mw, this, k);
                izmenaWindow.ShowDialog();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dataKamioni.SelectedIndex != -1)
            {
                Kamion k = (Kamion)dataKamioni.SelectedItem;
                mw.Pod.Kamioni.Remove(k);

                if(kamion_searchView != null)
                {
                    kamion_searchView.Remove(k);
                }

                dataKamioni.ItemsSource = mw.Pod.Kamioni;
                dataKamioni.Items.Refresh();
            }
        }

        private void BtnPretraga_Click(object sender, RoutedEventArgs e)
        {
            kamion_searchView = new ObservableCollection<Kamion>();

            foreach (Kamion c in mw.Pod.Kamioni)
            {
                if (c.Registracija == Pretraga)
                {
                    kamion_searchView.Add(c);
                }
            }

            if (Pretraga == "")
            {
                dataKamioni.ItemsSource = mw.Pod.Kamioni;
                kamion_searchView = new ObservableCollection<Kamion>();
                return;
            }
            else if (kamion_searchView.Count > 0)
            {
                dataKamioni.ItemsSource = kamion_searchView;
            }
            else
            {
                MessageBox.Show("Kamion sa registracijom " + Pretraga + " ne postoji!");
                kamion_searchView = new ObservableCollection<Kamion>();
                return;
            }
        }
    }
}
