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
    /// Interaction logic for ListaCisterna.xaml
    /// </summary>
    public partial class ListaCisterna : UserControl, INotifyPropertyChanged
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
        private ObservableCollection<Cisterna> cisterna_searchView;

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

        public ListaCisterna()
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
            mw.DodajKamion.Visibility = Visibility.Hidden;
            mw.DodajVozaca.Visibility = Visibility.Hidden;
            mw.DodajCisternu.Visibility = Visibility.Visible;
            mw.Otpremnica.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(dataCisterne.SelectedIndex != -1)
            {
                Cisterna c = (Cisterna)dataCisterne.SelectedItem;
                IzmeniCisternu izmenaWindow = new IzmeniCisternu(mw, this, c);
                izmenaWindow.ShowDialog();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dataCisterne.SelectedIndex != -1)
            {
                Cisterna c = (Cisterna)dataCisterne.SelectedItem;
                mw.Pod.Cisterne.Remove(c);

                if(cisterna_searchView != null)
                {
                    cisterna_searchView.Remove(c);
                }
                dataCisterne.ItemsSource = mw.Pod.Cisterne;
                dataCisterne.Items.Refresh();
            }
        }

        private void BtnPretraga_Click(object sender, RoutedEventArgs e)
        {
            cisterna_searchView = new ObservableCollection<Cisterna>();

            foreach(Cisterna c in mw.Pod.Cisterne)
            {
                if(c.Registracija == Pretraga)
                {
                    cisterna_searchView.Add(c);
                }
            }

            if(Pretraga == "")
            {
                dataCisterne.ItemsSource = mw.Pod.Cisterne;
                cisterna_searchView = new ObservableCollection<Cisterna>();
                return;
            }
            else if(cisterna_searchView.Count > 0)
            {
                dataCisterne.ItemsSource = cisterna_searchView;
            }
            else
            {
                MessageBox.Show("Cisterna sa registracijom " + Pretraga + " ne postoji!");
                cisterna_searchView = new ObservableCollection<Cisterna>();
                return;
            }


        }
    }
}
