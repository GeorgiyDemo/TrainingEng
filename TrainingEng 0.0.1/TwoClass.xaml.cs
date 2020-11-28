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

namespace TrainingEng_0._0._1
{
    /// <summary>
    /// Логика взаимодействия для LoginIN.xaml
    /// </summary>
    /// 

    //public static class NextTheoryForm
    //{
    //    static void Main(string[] args)
    //    {
    //        TheoryTwoClass nextPage = new TheoryTwoClass();
    //        //NavigationService.Navigate(nextPage);
    //    }
    //}

    public partial class TwoClass : Page
    {
        public TwoClass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TwoExitList_Click(object sender, RoutedEventArgs e)
        {
            //Navigate(new TwoClass());
        }

        private void TwoThema1_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 1;
            TheoryClass nextPage = new TheoryClass();
            NavigationService.Navigate(nextPage);
            // https://techarks.ru/qa/csharp/kak-perejti-na-druguyu-strani-JK/
        }

        private void TwoThema2_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 2;
            TheoryClass nextPage = new TheoryClass();
            NavigationService.Navigate(nextPage);
        }

        private void TwoThema3_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 3;
            TheoryClass nextPage = new TheoryClass();
            NavigationService.Navigate(nextPage);
        }

        private void TwoThema4_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 4;
            TheoryClass nextPage = new TheoryClass();
            NavigationService.Navigate(nextPage);
        }

        private void TwoThema5_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 5;
            TheoryClass nextPage = new TheoryClass();
            NavigationService.Navigate(nextPage);
        }

        private void TwoItogTest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
