using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace TrainingEng_0._0._1
{
    /// <summary>
    /// Логика взаимодействия для TwoThemaPractic_1.xaml
    /// </summary>
    /// 

    public partial class PracticeClass : Page
    {


        private string TaskKey;
        private List<TaskClass> TaskList;
        private TaskClass CurrentTask;
        private int GoodAnswersCount;
        private String UserName;
        private int QuestionsCount;

        public PracticeClass(String UserName, List<TaskClass> TaskList, int GoodAnswersCount, int QuestionsCount)
        {
            InitializeComponent();
            //Текущее задание, которое мы отображаем на этой странице
            this.CurrentTask = TaskList[0];
            //Удаляем задание из списка, которое мы отображаем на этой странице
            TaskList.RemoveAt(0);
            //Выставляем остальные поля
            this.TaskList = TaskList;
            this.GoodAnswersCount = GoodAnswersCount;
            this.UserName = UserName;
            this.QuestionsCount = QuestionsCount;
            //Вызываем метод форматирования интерфейса
            this.PageFormater();
        }

        //Метод для визуального оформления элементов в зависимости от текущего задания
        private void PageFormater()
        {
            //Отображаем прогресс 
            PointsLabel.Content = "Кол-во набранных баллов:\n" + this.GoodAnswersCount + "/"+this.QuestionsCount;

            //Текущий номер топика
            int TopicNumber = Globals.TheoryFail;
            //Выбранный класс школьника
            int ClassNumber = Globals.Classes;

            TaskClass CurrentTask = this.CurrentTask;
            string CurrentDir = Globals.CurrentDirFormater();

            //Текст задания
            TaskLabel.Content = CurrentTask.Text;

            //Выставляем правильный ответ
            this.TaskKey = CurrentTask.Option4;

            //Если тип задания без выбора от ответов, то деактивируем RadioButtons 
            if (CurrentTask.TypeId == 2)
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
                String[] OfferArray = { CurrentTask.Option1, CurrentTask.Option2, CurrentTask.Option3, CurrentTask.Option4 };
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
            if (CurrentTask.Photo != null)
            {
                TaskImage.Visibility = Visibility.Visible;
                String ImageString = CurrentDir + CurrentTask.Photo;
                TaskImage.Source = new BitmapImage(new Uri(ImageString));
            }
            //Если нет фото - не отображаем
            else
                TaskImage.Visibility = Visibility.Hidden;

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

        //TODO Какое-то визуальное подтверждение того, что верно, а что-нет?
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //Получаем ответы из элементов
            String Task1Answer = GetTaskAnswer(TaskInputTextBox, TaskRadioButton1, TaskRadioButton2, TaskRadioButton3, TaskRadioButton4);
            //Если результаты 1 задания равны, то +1
            if (TaskKey.ToLower() == Task1Answer.ToLower())
                this.GoodAnswersCount++;

            if (this.TaskList.Count == 0)
            {
                EndPracticeClass nextPage = new EndPracticeClass(this.UserName, this.GoodAnswersCount, this.QuestionsCount);
                NavigationService.Navigate(nextPage);
            }
            else
            {
                PracticeClass nextPage = new PracticeClass(this.UserName, this.TaskList, this.GoodAnswersCount, this.QuestionsCount);
                NavigationService.Navigate(nextPage);
            }

        }
    }

}


