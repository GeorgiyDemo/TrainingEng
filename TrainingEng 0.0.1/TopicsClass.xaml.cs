using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TrainingEng_0._0._1
{

    public partial class TopicsClass : Page
    {
        public TopicsClass()
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


        private void Topic20_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 20;
            TheoryClass nextPage = new TheoryClass(Topic20.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic19_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 19;
            TheoryClass nextPage = new TheoryClass(Topic19.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic18_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 18;
            TheoryClass nextPage = new TheoryClass(Topic18.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic17_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 17;
            TheoryClass nextPage = new TheoryClass(Topic17.Content.ToString());
            NavigationService.Navigate(nextPage);

        }

        private void Topic16_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 16;
            TheoryClass nextPage = new TheoryClass(Topic16.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic15_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 15;
            TheoryClass nextPage = new TheoryClass(Topic15.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic14_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 14;
            TheoryClass nextPage = new TheoryClass(Topic14.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic13_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 13;
            TheoryClass nextPage = new TheoryClass(Topic13.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic12_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 12;
            TheoryClass nextPage = new TheoryClass(Topic12.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic11_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 11;
            TheoryClass nextPage = new TheoryClass(Topic11.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic10_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 10;
            TheoryClass nextPage = new TheoryClass(Topic10.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic9_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 9;
            TheoryClass nextPage = new TheoryClass(Topic9.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic8_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 8;
            TheoryClass nextPage = new TheoryClass(Topic8.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic7_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 7;
            TheoryClass nextPage = new TheoryClass(Topic7.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic6_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 6;
            TheoryClass nextPage = new TheoryClass(Topic6.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic5_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 5;
            TheoryClass nextPage = new TheoryClass(Topic5.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic4_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 4;
            TheoryClass nextPage = new TheoryClass(Topic4.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic3_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 3;
            TheoryClass nextPage = new TheoryClass(Topic3.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic2_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 2;
            TheoryClass nextPage = new TheoryClass(Topic2.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        private void Topic1_Click(object sender, RoutedEventArgs e)
        {
            Globals.TheoryFail = 1;
            TheoryClass nextPage = new TheoryClass(Topic1.Content.ToString());
            NavigationService.Navigate(nextPage);
        }

        //Получаем имена тем для button'ов с СУБД SQLite
        private void ThisGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Список всех Button'ов
            List<Button> ButtonsList = new List<Button>
            {
                Topic1, Topic2, Topic3, Topic4, Topic5,
                Topic6, Topic7, Topic8, Topic9, Topic10,
                Topic11, Topic12, Topic13, Topic14, Topic15,
                Topic16, Topic17, Topic18, Topic19, Topic20
            };

            //Выбранный класс школьника
            String TaskClass = Globals.Classes.ToString();

            //Заполняем названия button'ов из БД
            for (int i = 0; i < ButtonsList.Count; i++)
                ButtonsList[i].Content = SQLiteClass.SQLiteGetOne("SELECT text FROM Topics WHERE (class_id=" + TaskClass + " AND topic_id=" + (i + 1).ToString() + ");");

        }

        //TODO Берет из каждой темы рандомно по 1 вопросу и тем самым формирует новый список, который передается далее в конструктор
        private void FinalTestButton_Click(object sender, RoutedEventArgs e)
        {
            //21 тест будет финальным (по порядковому номеру)
            Globals.TheoryFail = 21;
            TotalBeginPracticeClass nextPage = new TotalBeginPracticeClass();
            NavigationService.Navigate(nextPage);

        }
    }
}
