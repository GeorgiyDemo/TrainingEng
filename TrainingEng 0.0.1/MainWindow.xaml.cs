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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public static class Globals
    {
        public static string TheoryFail = null;
        public static int Classes = 0;
    }


    public partial class MainWindow : Window
    {
       /// string TheoryFail = null;
       // public static string TheoryFail { get; set; }
        //private SqlConnection sqlConnection = null;

        public MainWindow()
        {
            InitializeComponent();

            //sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\TrainingEng\TrainingEng 0.0.1\TrainingEng 0.0.1\TrainingEng 0.0.1\KursachBD.mdf;Integrated Security=True");

           // sqlConnection.Open();

        }
  

        private void BtnPage1_Click(object sender, RoutedEventArgs e) // Переход на 1 лист АВТОРИЗАЦИЯ
        {
            Globals.TheoryFail = null;
            Globals.Classes = 2;
            mainframe.Navigate(new TwoClass());
            BtnPage1.Background = new SolidColorBrush(Colors.Green);
            BtnPage2.Background = new SolidColorBrush(Colors.White);
            BtnPage3.Background = new SolidColorBrush(Colors.White);
            // mainFrame.NavigationService.Navigate(new Uri("LoginIN.xaml", UriKind.Relative));
        }

        private void BtnPage2_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = null;
            Globals.Classes = 3;
            BtnPage1.Background = new SolidColorBrush(Colors.White);
            BtnPage2.Background = new SolidColorBrush(Colors.Green);
            BtnPage3.Background = new SolidColorBrush(Colors.White);
            mainframe.Navigate(new ThreeClass());
        }

        private void BtnPage3_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = null;
            Globals.Classes = 4;
            BtnPage1.Background = new SolidColorBrush(Colors.White);
            BtnPage2.Background = new SolidColorBrush(Colors.White);
            BtnPage3.Background = new SolidColorBrush(Colors.Green);
            // webBrowser1.DocumentCompleted;
            //    webBrowser1.Navigate("file:///D:/24.txt");
            // webBrowser1.Navigate("file:///D:/eFoto.jpg");
            // webBrowser1.Navigate("file:///D:/Frame2.png");
            //WebBrowser1.Navigate("D://eq5KrzySaRo.jpg");
        }

        private void BtnPage4_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
