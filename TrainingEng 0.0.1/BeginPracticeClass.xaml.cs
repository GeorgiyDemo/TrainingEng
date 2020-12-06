using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TrainingEng_0._0._1
{
    /// <summary>
    /// Логика взаимодействия для TwoThemaPractic_1.xaml
    /// </summary>
    /// 

    public partial class BeginPracticeClass : Page
    {
        private List<TaskClass> TaskList;
        public BeginPracticeClass(String TopicName)
        {
            InitializeComponent();
            //Название темы
            TopicLabel.Content = "Тестирование по теме:\n" + TopicName;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //Текущий номер топика
            int TopicNumber = Globals.TheoryFail;
            //Выбранный класс школьника
            int ClassNumber = Globals.Classes;
            //Получаем данные с SQLite
            TaskList = SQLiteClass.SQLiteGetTasks(TopicNumber, ClassNumber);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //Если ввели имя и прошли фильтрацию
            if ((NameInputTextBox.Text != "") && (Regex.IsMatch(NameInputTextBox.Text, @"\p{IsCyrillic}")))
            {
                //Флаг того, что мы начали прохождение теста
                Globals.isTestProcessing = true;
                String UserName = NameInputTextBox.Text;
                //Перемешивание вопросов в списке
                TaskList = TaskList.OrderBy(a => Guid.NewGuid()).ToList();
                PracticeClass newPractice = new PracticeClass(UserName, TaskList, 0, 5);
                NavigationService.Navigate(newPractice);
            }
            else
            {
                MessageBox.Show("Для продолжения работы введите ваше имя на русском языке");
            }
        }
    }

}
