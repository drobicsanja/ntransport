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
    /// Interaction logic for Otpremnica.xaml
    /// </summary>
    public partial class Otpremnica : UserControl
    {
        public Otpremnica()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resetFields();
        }

        private void resetFields()
        {
            tbBrojOtpremnice.Text = "";
            tbCena.Text = "";
            tbImeVozaca.Text = "";
            tbKolicina.Text = "";
            tbMestoIstovara.Text = "";
            tbMestoUtovara.Text = "";
            tbPrezimeVozaca.Text = "";
            tbRegistracija.Text = "";
            tbVrstaRobe.Text = "";
        }
    }
}
