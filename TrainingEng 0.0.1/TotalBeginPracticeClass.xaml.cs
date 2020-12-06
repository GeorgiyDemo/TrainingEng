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

    public partial class TotalBeginPracticeClass : Page
    {
        private List<TaskClass> TaskList;
        public TotalBeginPracticeClass()
        {
            InitializeComponent();
            //Название темы
            TopicLabel.Content = "Итоговый тест по классу " + Globals.Classes.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //Выбранный класс школьника
            int ClassNumber = Globals.Classes;

            //Получаем данные с SQLite
            TaskList = SQLiteClass.SQLiteGetTotalTasks(ClassNumber);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            //Если ввели имя и прошли фильтрацию
                if ((NameInputTextBox.Text != "") && (Regex.IsMatch(NameInputTextBox.Text, @"\p{IsCyrillic}")))
                {
                    //Выставляем то, что мы сейчас проходим тест
                    Globals.isTestProcessing = true;
                    String UserName = NameInputTextBox.Text;
                    //Перемешивание вопросов в списке
                    TaskList = TaskList.OrderBy(a => Guid.NewGuid()).ToList();
                    PracticeClass newPractice = new PracticeClass(UserName, TaskList, 0, 20);
                    NavigationService.Navigate(newPractice);
                }
                else
                {
                    MessageBox.Show("Для продолжения работы введите ваше имя на русском языке");
                }
            
        }

    }

}
