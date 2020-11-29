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

    public partial class PracticeClass : Page
    {

        
        public Dictionary<string, string> TaskKeysDict = new Dictionary<string, string>();
        public TaskClass currentTask;

        public PracticeClass(TaskClass currentTask)
        {
            InitializeComponent();
            this.currentTask = currentTask;

            this.PageFormater();
            ResultLabel.Visibility = Visibility.Hidden;
        }

        private void PageFormater()
        {

        }

        // Получение значений из элементов задания
        private String GetTaskAnswer(TextBox TextBox, RadioButton radio1, RadioButton radio2, RadioButton radio3, RadioButton radio4)
        {
            String result = "NONE";
            //Если виден Textbot, то ответ берем оттуда
            if (TextBox.Visibility == Visibility.Visible)
            {
                result = TextBox.Text;
            }

            //Значит ответ находится где-то в RadioButton'ах
            else
            {
                if (radio1.IsChecked == true)
                {
                    result = radio1.Content.ToString();
                }
                else if (radio2.IsChecked == true)
                {
                    result = radio2.Content.ToString();
                }
                else if (radio3.IsChecked == true)
                {
                    result = radio3.Content.ToString();
                }
                else if (radio4.IsChecked == true)
                {
                    result = radio4.Content.ToString();
                }
            }

            return result;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "Кол-во правильных ответов:";

            //Текущий номер топика
            int TopicNumber = Globals.TheoryFail;
            //Выбранный класс школьника
            int ClassNumber = Globals.Classes;

            TaskClass currentTask = this.currentTask;
            string CurrentDir = Globals.CurrentDirFormater();

            //Текст задания
            TaskLabel.Content = currentTask.Text;

            //Словарь ответов
            TaskKeysDict.Add("Task", currentTask.Option4);

            //Если тип задания без выбора от ответов, то деактивируем RadioButtons 
            if (currentTask.TypeId == 2)
            {
                TaskRadioButton1.Visibility = Visibility.Hidden;
                TaskRadioButton2.Visibility = Visibility.Hidden;
                TaskRadioButton3.Visibility = Visibility.Hidden;
                TaskRadioButton4.Visibility = Visibility.Hidden;
                TaskInputTextBox.Visibility = Visibility.Visible;
            }
            //Иначе это тип с выбором через RadioButtons
            else
            {

                //Перемешиваем ответы
                String[] OfferArray = { currentTask.Option1, currentTask.Option2, currentTask.Option3, currentTask.Option4 };
                Random r = new Random();
                OfferArray = OfferArray.OrderBy(x => r.Next()).ToArray();

                //Перемешивание верного ответа 
                TaskRadioButton1.Visibility = Visibility.Visible;
                TaskRadioButton1.Content = OfferArray[0];

                TaskRadioButton2.Visibility = Visibility.Visible;
                TaskRadioButton2.Content = OfferArray[1];

                TaskRadioButton3.Visibility = Visibility.Visible;
                TaskRadioButton3.Content = OfferArray[2];

                TaskRadioButton4.Visibility = Visibility.Visible;
                TaskRadioButton4.Content = OfferArray[3];

                TaskInputTextBox.Visibility = Visibility.Hidden;
            }

            //Если есть фото - отображаем
            if (currentTask.Photo != null)
            {
                TaskImage.Visibility = Visibility.Visible;
                String ImageString = CurrentDir + currentTask.Photo;
                TaskImage.Source = new BitmapImage(new Uri(ImageString));
            }
            //Если нет фото - не отображаем
            else
                TaskImage.Visibility = Visibility.Hidden;
            }

        //TODO Какое-то визуальное подтверждение того, что верно, а что-нет?
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //Кол-во верных заданий
            int GoodTasksCounter = 0;
            ResultLabel.Visibility = Visibility.Visible;

            //Получаем ответы из элементов
            String Task1Answer = GetTaskAnswer(TaskInputTextBox, TaskRadioButton1, TaskRadioButton2, TaskRadioButton3, TaskRadioButton4);
            //Если результаты 1 задания равны, то +1
            if (TaskKeysDict["Task"].ToLower() == Task1Answer.ToLower())
                GoodTasksCounter++;

            //Выводим на Label результат
            if (GoodTasksCounter == 0)
                ResultLabel.Content = "Вы ответили неправильно";
            else
                ResultLabel.Content = "Поздравляем, Вы ответили правильно";
        }
    }

}
    

