using System;
using System.Windows;
using System.Windows.Media;

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
            //Если сейчас не выполняется какой-либо тест
            if (Globals.isTestProcessing == false)
            {
                Globals.TheoryFail = 0;
                Globals.Classes = 2;
                mainframe.Navigate(new TopicsClass());
                BtnPage1.Background = new SolidColorBrush(Colors.Green);
                BtnPage2.Background = new SolidColorBrush(Colors.White);
                BtnPage3.Background = new SolidColorBrush(Colors.White);
            }
            //Иначе спрашиваем
            else
            {
                //Вопрос перед закрытием приложения
                if (MessageBox.Show("Вы действительно хотите завершить прохождение текущего теста?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //Выставляем заавершение теста
                    Globals.isTestProcessing = false;
                    Globals.TheoryFail = 0;
                    Globals.Classes = 2;
                    mainframe.Navigate(new TopicsClass());
                    BtnPage1.Background = new SolidColorBrush(Colors.Green);
                    BtnPage2.Background = new SolidColorBrush(Colors.White);
                    BtnPage3.Background = new SolidColorBrush(Colors.White);
                }

            }
        }

        private void BtnPage2_Click(object sender, RoutedEventArgs e)
        {
            //Если сейчас не выполняется какой-либо тест
            if (Globals.isTestProcessing == false)
            {
                Globals.TheoryFail = 0;
                Globals.Classes = 3;
                mainframe.Navigate(new TopicsClass());
                BtnPage1.Background = new SolidColorBrush(Colors.White);
                BtnPage2.Background = new SolidColorBrush(Colors.Green);
                BtnPage3.Background = new SolidColorBrush(Colors.White);
            }
            //Иначе спрашиваем
            else
            {
                //Вопрос перед закрытием приложения
                if (MessageBox.Show("Вы действительно хотите завершить прохождение текущего теста?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //Выставляем заавершение теста
                    Globals.isTestProcessing = false;
                    Globals.TheoryFail = 0;
                    Globals.Classes = 3;
                    mainframe.Navigate(new TopicsClass());
                    BtnPage1.Background = new SolidColorBrush(Colors.White);
                    BtnPage2.Background = new SolidColorBrush(Colors.Green);
                    BtnPage3.Background = new SolidColorBrush(Colors.White);
                }

            }

        }

        private void BtnPage3_Click(object sender, RoutedEventArgs e)
        {
            //Если сейчас не выполняется какой-либо тест
            if (Globals.isTestProcessing == false)
            {
                Globals.TheoryFail = 0;
                Globals.Classes = 4;
                mainframe.Navigate(new TopicsClass());
                BtnPage1.Background = new SolidColorBrush(Colors.White);
                BtnPage2.Background = new SolidColorBrush(Colors.White);
                BtnPage3.Background = new SolidColorBrush(Colors.Green);
            }
            //Иначе спрашиваем
            else
            {
                //Вопрос перед закрытием приложения
                if (MessageBox.Show("Вы действительно хотите завершить прохождение текущего теста?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //Выставляем заавершение теста
                    Globals.isTestProcessing = false;
                    Globals.TheoryFail = 0;
                    Globals.Classes = 4;
                    mainframe.Navigate(new TopicsClass());
                    BtnPage1.Background = new SolidColorBrush(Colors.White);
                    BtnPage2.Background = new SolidColorBrush(Colors.White);
                    BtnPage3.Background = new SolidColorBrush(Colors.Green);
                }

            }
        }

        private void BtnPage4_Click(object sender, RoutedEventArgs e)
        {
            //Вопрос перед закрытием приложения
            if (MessageBox.Show("Вы действительно хотите закрыть приложение?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }

        }
    }
}
