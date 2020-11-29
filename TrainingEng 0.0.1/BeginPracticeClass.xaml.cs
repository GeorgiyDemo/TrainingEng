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
    /// 

    public partial class BeginPracticeClass : Page
    {
        private List<TaskClass> TaskList;
        public BeginPracticeClass(String TopicName)
        {
            InitializeComponent();
            //Название темы
            TopicLabel.Content = "Тестирование по теме:\n"+TopicName;
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
            PracticeClass newPractice = new PracticeClass(TaskList, 0);
            NavigationService.Navigate(newPractice);
        }
    }
    
}
