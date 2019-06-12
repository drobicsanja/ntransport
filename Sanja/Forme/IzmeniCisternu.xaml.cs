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
using System.Windows.Shapes;

namespace Sanja.Forme
{
    /// <summary>
    /// Interaction logic for IzmeniCisternu.xaml
    /// </summary>
    public partial class IzmeniCisternu : Window
    {
        private MainWindow mw;
        private Cisterna cisterna;
        private ListaCisterna parent;

        public IzmeniCisternu(MainWindow w, ListaCisterna d, Cisterna c)
        {
            parent = d;
            mw = w;
            cisterna = c;

            InitializeComponent();
            this.DataContext = this;

            tbRegBroj.Text = cisterna.Registracija;
            if (String.IsNullOrEmpty(cisterna.RegDate))
                {

                datumVazenjeReg.SelectedDate = null;
            }
            else
            {
                datumVazenjeReg.SelectedDate = Convert.ToDateTime(cisterna.RegDate);
            }       
            chbOprana.IsChecked = cisterna.Oprana;
            chbRaspoloziv.IsChecked = cisterna.Raspolozivo;
        }

        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
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

            foreach (Cisterna c in mw.Pod.Cisterne)
            {
                if(c.Registracija == cisterna.Registracija)
                {
                    if (provera())
                    {
                        c.RegDate = dateString;
                        c.Raspolozivo = raspoloziv;
                        c.Oprana = opran;
                        parent.dataCisterne.Items.Refresh();
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

        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
