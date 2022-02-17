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

namespace Ultrabalaton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Main main = new Main();
        public MainWindow()
        { 
            InitializeComponent();
            
            main.Fill();
            lbFirst.Content += main.VersenyzoCount + " fő";
            main.Category(cboxCategory);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Versenyzo result = main.Keres(sender, e, tbName);
            lbSecond.Content = result == null ? "Nincs ilyen nevű versenyző" : $"Rajtszáma: {result.Rajtszam} ideje: {result.Ido} megtett táv: {result.Tav}%";
        }

        private void cboxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (btnToFile.IsEnabled == false) btnToFile.IsEnabled = true;
            Versenyzo v = main.KatGyoztes(cboxCategory);
            main.KategoriaVersenyzo(lboxNames, cboxCategory);
            lbThird.Content = lbFourth.Content = null;
            lbThird.Content = $"Ebből célbaért {main.CelbaErt()} fő.";
            lbFourth.Content = $"Kategória győztese: {v.Nev}. Ideje: {v.Ido}";
        }

        private void btnToFile_Click(object sender, RoutedEventArgs e)
        {
            if (main.Save() == 1) MessageBox.Show("Sikeres fájlba írás.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Sikertelen fájlba írás", "Hiba", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
