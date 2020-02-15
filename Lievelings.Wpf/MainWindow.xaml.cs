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
#region Opdracht
/*
Methode WijzigBeschikbaarheidTaalKnoppen
Deze methode zorgt ervoor dat er altijd maar één button beschikbaar(enabled) is. De parameter isNlBeschikbaar duidt aan of de btnNL al dan niet beschikbaar is. Voor de btnENG geldt steeds het tegenovergestelde.

De methode wordt gecalled bij het opstarten(btnENG beschikbaar) en bij btnNL_Click en btnENG_Click.

WijzigZichtbaarheid
ToonKnoppen en VerbergKnoppen wordt gereduceerd tot één methode.

Deze methode ontvangt een parameter zichtbaarheid van het type Visibility en zal dus de waarde Visibility.Visible of Visibility.Hidden moeten ontvangen.

Verwijder nadien ToonKnoppen en VerbergKnoppen en pas de calls aan
*/ 
#endregion
namespace Lievelings.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variabelen

        #region Variabelen
        string stad;
        string beginVanDeZin;

        const string BeginNed = "Je lievelingsstad is ";
        const string BeginEng = "Your favorite city is ";
        const string TitelNed = "Kies je lievelingsstad";
        const string TitelEng = "Choose your favorite city";

        #endregion
        //Methodes
        #region Methodes

        void WijzigBeschikbaarheidTaalKnoppen(bool isBtnNederlandsBeschikbaar)
        {
            btnNl.IsEnabled = isBtnNederlandsBeschikbaar;
            btnEn.IsEnabled = !isBtnNederlandsBeschikbaar;
        }
        void WijzigZichtbaarheidTaalknoppen(Visibility zichtbaarheid)
        {
            btnEn.Visibility = zichtbaarheid;
            btnNl.Visibility = zichtbaarheid;
        }
        private void VulLstSteden()
        {
            lstSteden.Items.Add("Antwerpen");
            lstSteden.Items.Add("Brugge");
            lstSteden.Items.Add("Brussel");
            lstSteden.Items.Add("Gent");
            lstSteden.Items.Add("Hasselt");
        }
        /*
        private void ToonKnoppen()
        {
            btnEn.Visibility = Visibility.Visible;
            btnNl.Visibility = Visibility.Visible;
        }
        private void VerbergKnoppen()
        {
            btnEn.Visibility = Visibility.Hidden;
            btnNl.Visibility = Visibility.Hidden;
        }
        */
        private void ToonNederlandstaligeOpschriften()
        {
            beginVanDeZin = BeginNed;

            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            Title = TitelNed;
        }
        private void ToonEngelstaligeOpschriften()
        {
            beginVanDeZin = BeginEng;

            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            Title = TitelEng;
        }

        #endregion

        //Event handelers
        #region Eventhandelers

        public MainWindow()
        {
            InitializeComponent();
            beginVanDeZin = BeginNed;
        }

        private void btnEn_Click(object sender, RoutedEventArgs e)
        {
            ToonEngelstaligeOpschriften();
            WijzigBeschikbaarheidTaalKnoppen(true);
        }

        private void btnNl_Click(object sender, RoutedEventArgs e)
        {
            ToonNederlandstaligeOpschriften();
            WijzigBeschikbaarheidTaalKnoppen(false);
        }

        private void lstSteden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stad = lstSteden.SelectedItem.ToString();
            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            WijzigZichtbaarheidTaalknoppen(Visibility.Visible);
        }

        private void wndMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VulLstSteden();

            WijzigZichtbaarheidTaalknoppen(Visibility.Visible);
            WijzigBeschikbaarheidTaalKnoppen(false);

            Title = TitelNed;
        } 
        #endregion
    }
}
