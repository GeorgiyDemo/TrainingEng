using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TrainingEng_0._0._1
{
    /// <summary>
    /// Логика взаимодействия для TwoThemaPractic_1.xaml
    /// </summary>
    /// 

    public partial class EndPracticeClass : Page
    {
        private String UserName;
        private int TotalPoints;
        public EndPracticeClass(String UserName, int TotalPoints, int QuestionsCount)
        {
            InitializeComponent();

            //Вывод результата на экран
            ResultsLabel.Content = "Ваш результат: " + TotalPoints.ToString() + "/"+QuestionsCount;

            //Выставление полей
            this.TotalPoints = TotalPoints;
            this.UserName = UserName;

            //Запись итогов тестирования в СУБД
            this.ResultSQLWriter();

        }

        //Запись результата тестирования в SQlite
        private void ResultSQLWriter()
        {
            //Текущий номер топика
            String TopicNumber = Globals.TheoryFail.ToString();

            //Выбранный класс школьника
            String TaskClass = Globals.Classes.ToString();

            //Текущее время
            String TimeNow = DateTime.Now.ToString(@"dd\/MM\/yyyy HH:mm:ss");

            //Строка для записи данных в SQLite
            String SQLString = String.Format("INSERT INTO Results(class_id, topic_id, points,username, time) VALUES ({0},{1},{2},'{3}','{4}')", TaskClass, TopicNumber, this.TotalPoints, this.UserName, TimeNow);
            SQLiteClass.SQLiteExecute(SQLString);

        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            String TimeNow = DateTime.Now.ToString("ddMMyyyy HHmmss");
            List<UserResultsClass> UserResults = SQLiteClass.SQLiteGetUserResults(this.UserName);
            PDFCreatorClass PdfObject = new PDFCreatorClass("Export " + TimeNow + ".pdf", this.UserName, UserResults);
        }
    }

}
