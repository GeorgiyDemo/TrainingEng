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
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace TrainingEng_0._0._1
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
  

        private void BtnPage1_Click(object sender, RoutedEventArgs e) // Переход на 1 лист АВТОРИЗАЦИЯ
        {
            Globals.TheoryFail = 0;
            Globals.Classes = 2;
            mainframe.Navigate(new TopicsClass());
            BtnPage1.Background = new SolidColorBrush(Colors.Green);
            BtnPage2.Background = new SolidColorBrush(Colors.White);
            BtnPage3.Background = new SolidColorBrush(Colors.White);
        }

        private void BtnPage2_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 0;
            Globals.Classes = 3;
            mainframe.Navigate(new TopicsClass());
            BtnPage1.Background = new SolidColorBrush(Colors.White);
            BtnPage2.Background = new SolidColorBrush(Colors.Green);
            BtnPage3.Background = new SolidColorBrush(Colors.White);
        }

        private void BtnPage3_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 0;
            Globals.Classes = 4;
            mainframe.Navigate(new TopicsClass());
            BtnPage1.Background = new SolidColorBrush(Colors.White);
            BtnPage2.Background = new SolidColorBrush(Colors.White);
            BtnPage3.Background = new SolidColorBrush(Colors.Green);
        }

        private void BtnPage4_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
