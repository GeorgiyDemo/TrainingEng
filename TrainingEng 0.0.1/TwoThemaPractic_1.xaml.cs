using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace TrainingEng_0._0._1
{
    /// <summary>
    /// Логика взаимодействия для TwoThemaPractic_1.xaml
    /// </summary>
    public partial class TwoThemaPractic_1 : Page
    {
        public TwoThemaPractic_1()
        {
            InitializeComponent();
            LabelItogShet.Visibility = Visibility.Hidden;
        }

        private void TwoThema1_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            int maxpoints = 5;
            if(TextBoxCat.Text == "" || TextBoxMonkey.Text == "" || 
                TextBoxSlon.Text == "" || TextBoxUtka.Text == "" ||(
                RadioButtonDog1.IsChecked == false && RadioButtonDog2.IsChecked == false &&
                RadioButtonDog3.IsChecked == false && RadioButtonDog4.IsChecked == false))
            {
                MessageBox.Show("Ответье на все вопросы!");
            }
            else
        {
            if (TextBoxCat.Text == "Cat" || TextBoxCat.Text == "cat")
            {
                points++;
                    TextBoxCat.Background = new SolidColorBrush(Colors.Green);
            }
                else
                {
                    TextBoxCat.Background = new SolidColorBrush(Colors.Red);
                }
            if (RadioButtonDog2.IsChecked == true)
            {
                points++;
                    RadioButtonDog1.Background = new SolidColorBrush(Colors.Green);
                    RadioButtonDog2.Background = new SolidColorBrush(Colors.Green);
                    RadioButtonDog3.Background = new SolidColorBrush(Colors.Green);
                    RadioButtonDog4.Background = new SolidColorBrush(Colors.Green);
            }
                else
                {
                    RadioButtonDog1.Background = new SolidColorBrush(Colors.Red);
                    RadioButtonDog2.Background = new SolidColorBrush(Colors.Red);
                    RadioButtonDog3.Background = new SolidColorBrush(Colors.Red);
                    RadioButtonDog4.Background = new SolidColorBrush(Colors.Red);
                }
            if (TextBoxMonkey.Text == "Monkey" || TextBoxMonkey.Text == "monkey")
            {
                points++;
                    TextBoxMonkey.Background = new SolidColorBrush(Colors.Green);
            }
                else
                {
                    TextBoxMonkey.Background = new SolidColorBrush(Colors.Red);
                }
            if (TextBoxSlon.Text == "Слон" || TextBoxSlon.Text == "слон")
            {
                points++;
                    TextBoxSlon.Background = new SolidColorBrush(Colors.Green);
            }
                else
                {
                    TextBoxSlon.Background = new SolidColorBrush(Colors.Red);
                }
            if (TextBoxUtka.Text == "Утка" || TextBoxUtka.Text == "утка")
            {
                points++;
                    TextBoxUtka.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    TextBoxUtka.Background = new SolidColorBrush(Colors.Red);
                }
                LabelItogShet.Content = "Количество правильных ответов: " +
                        Convert.ToString(points) + " / " + Convert.ToString(maxpoints);
                LabelItogShet.Visibility = Visibility.Visible;
            }
    }

        private void ButtonSoundDuck_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer Simple = new SoundPlayer(@"E:\TrainingEng.V2\TrainingEng 0.0.1\Sound\AudDuck.wav");
            Simple.Play();
        }

        private void Border_Initialized(object sender, EventArgs e)
        {
            MessageBox.Show("ИНИЦИАЛИЗИРОВАЛСЯ И ЖИВ");
           // sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\TrainingEng\TrainingEng 0.0.1\TrainingEng 0.0.1\TrainingEng 0.0.1\KursachBD.mdf;Integrated Security=True");
            
           // sqlConnection.Open();

            //sqlDataAdapter = SqlDataAdapter("SELECT ");

        }
    }
    
}
