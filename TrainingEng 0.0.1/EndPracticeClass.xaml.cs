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
        
        //TODO Запись результата тестирования в SQlite
        private void ResultSQLWriter()
        {
            MessageBox.Show("ЗАПИСАЛИ ДАННЫЕ В СУБД "); 
        }
    }
    
}
