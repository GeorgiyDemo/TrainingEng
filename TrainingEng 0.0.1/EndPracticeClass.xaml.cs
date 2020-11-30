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

    public partial class EndPracticeClass : Page
    {
        private String UserName;
        private int TotalPoints;
        public EndPracticeClass(String UserName, int TotalPoints)
        {
            InitializeComponent();
            //Вывод результата на экран
            ResultsLabel.Content = "Ваш результат: " + TotalPoints.ToString()+"/5";

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
            String SQLString = String.Format("INSERT INTO Results(class_id, topic_id, points,username, time) VALUES ({0},{1},{2},'{3}','{4}')",TaskClass, TopicNumber, this.TotalPoints, this.UserName, TimeNow);
            SQLiteClass.SQLiteExecute(SQLString);

        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            String TimeNow = DateTime.Now.ToString("ddMMyyyy HHmmss");
            PDFCreatorClass PdfObject = new PDFCreatorClass("Export " + TimeNow + ".pdf", "ТЕСТ");
        }
    }
    
}
