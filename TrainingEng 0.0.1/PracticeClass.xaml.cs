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

    class TaskGraphicClass
    {
        public Image LocalImage;
        public Label LocalLabel;
        public TextBox LocalTextBox;
        public RadioButton Radio1;
        public RadioButton Radio2;
        public RadioButton Radio3;
        public RadioButton Radio4;
        public TaskClass obj;

        public TaskGraphicClass(Image LocalImage, Label LocalLabel, TextBox LocalTextBox, RadioButton Radio1, RadioButton Radio2, RadioButton Radio3, RadioButton Radio4, TaskClass obj)
        {
            this.LocalImage = LocalImage;
            this.LocalLabel = LocalLabel;
            this.LocalTextBox = LocalTextBox;
            this.Radio1 = Radio1;
            this.Radio2 = Radio2;
            this.Radio3 = Radio3;
            this.Radio4 = Radio4;
            this.obj = obj;
        }


        //Проверяет на корректность выбранных данных
        public Boolean IsCorrect()
        {
            return true;
        }
    }

    public partial class PracticeClass : Page
    {
        private Dictionary<string, string> TaskKeysDict = new Dictionary<string, string>();
        private int GoodTasksCounter;
        public PracticeClass()
        {
            InitializeComponent();
            ResultLabel.Visibility = Visibility.Hidden;
        }


        //TODO Получение значений из элементов задания
        private String GetTaskAnswer(TextBox textbot, RadioButton radio1, RadioButton radio2, RadioButton radio3, RadioButton radio4)
        {
            return "KOT";
        }
        //TODO Проверка на правильные ответы
        private void CheckResult_Click(object sender, RoutedEventArgs e)
        {
            //Кол-во верных заданий
            GoodTasksCounter = 0;
            ResultLabel.Visibility = Visibility.Visible;

            //gettaskanswer

            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "Кол-во правильных ответов:";

            //Текущий номер топика
            int TopicNumber = Globals.TheoryFail;
            //Выбранный класс школьника
            int ClassNumber = Globals.Classes;


            //Получаем данные с SQLite
            var ResultList = SQLiteClass.SQLiteGetTasks(TopicNumber, ClassNumber);

            //Элементы заданий

            List<Image> Images = new List<Image>() { Task1Image, Task2Image, Task3Image, Task4Image, Task5Image };
            List<Label> Labels = new List<Label>() { Task1Label, Task2Label, Task3Label, Task4Label, Task5Label };
            List<TextBox> TextBoxes = new List<TextBox>() { Task1InputTextBox, Task2InputTextBox, Task3InputTextBox, Task4InputTextBox, Task5InputTextBox };
            List<RadioButton> RadioButtons1 = new List<RadioButton>() { Task1RadioButton1, Task2RadioButton1, Task3RadioButton1, Task4RadioButton1, Task5RadioButton1 };
            List<RadioButton> RadioButtons2 = new List<RadioButton>() { Task1RadioButton2, Task2RadioButton2, Task3RadioButton2, Task4RadioButton2, Task5RadioButton2 };
            List<RadioButton> RadioButtons3 = new List<RadioButton>() { Task1RadioButton3, Task2RadioButton3, Task3RadioButton3, Task4RadioButton3, Task5RadioButton3 };
            List<RadioButton> RadioButtons4 = new List<RadioButton>() { Task1RadioButton4, Task2RadioButton4, Task3RadioButton4, Task4RadioButton4, Task5RadioButton4 };

            string CurrentDir = Globals.CurrentDirFormater();
            for (int i = 0; i < ResultList.Count; i++)
            {
                TaskClass currentTask = ResultList[i];

                //Текст задания
                Labels[i].Content = currentTask.Text;

                //Словарь ответов
                TaskKeysDict.Add("Task"+(i+1).ToString(), currentTask.Option4);

                //Если тип задания без выбора от ответов, то деактивируем RadioButtons 
                if (currentTask.TypeId == 2)
                {
                    RadioButtons1[i].Visibility = Visibility.Hidden;
                    RadioButtons2[i].Visibility = Visibility.Hidden;
                    RadioButtons3[i].Visibility = Visibility.Hidden;
                    RadioButtons4[i].Visibility = Visibility.Hidden;
                    TextBoxes[i].Visibility = Visibility.Visible;
                }
                //Иначе это тип с выбором через RadioButtons
                else
                {

                    //Перемешиваем ответы
                    String[] OfferArray = { currentTask.Option1, currentTask.Option2, currentTask.Option3, currentTask.Option4 };
                    Random r = new Random();
                    OfferArray = OfferArray.OrderBy(x => r.Next()).ToArray();


                    //Перемешивание верного ответа 
                    RadioButtons1[i].Visibility = Visibility.Visible;
                    RadioButtons1[i].Content = OfferArray[0];

                    RadioButtons2[i].Visibility = Visibility.Visible;
                    RadioButtons2[i].Content = OfferArray[1];

                    RadioButtons3[i].Visibility = Visibility.Visible;
                    RadioButtons3[i].Content = OfferArray[2];

                    RadioButtons4[i].Visibility = Visibility.Visible;
                    RadioButtons4[i].Content = OfferArray[3];

                    TextBoxes[i].Visibility = Visibility.Hidden;
                }

                //Если есть фото - отображаем
                if (currentTask.Photo != null)
                {
                    Images[i].Visibility = Visibility.Visible;
                    String ImageString = CurrentDir + currentTask.Photo;
                    Images[i].Source = new BitmapImage(new Uri(ImageString));
                }
                //Если нет фото - не отображаем
                else
                    Images[i].Visibility = Visibility.Hidden;
            }
        }
    }
    
}
