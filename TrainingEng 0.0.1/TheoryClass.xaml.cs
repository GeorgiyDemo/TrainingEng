using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrainingEng_0._0._1
{
    /// <summary>
    /// Логика взаимодействия для TheoryTwoClass.xaml
    /// </summary>
    public partial class TheoryClass : Page
    {
        public TheoryClass()
        {
           InitializeComponent();
            //TheoryTwoTem1.Navigate(@"E:\TrainingEng\TrainingEng 0.0.1\TrainingEng 0.0.1\TrainingEng 0.0.1\Frame3.png");
       
            if (Globals.TheoryFail != null)
       
            {
                if (Globals.Classes == 2)
                {
                    if (Globals.TheoryFail == "Moi_bukvy")
                    {
                        TheoryTwoTem1.Navigate(@"E:\TrainingEng.V2\TrainingEng 0.0.1\Theory\Moi_bukvy.html");
                    }
                    else if (Globals.TheoryFail == "Moy_dom")
                    {
                        TheoryTwoTem1.Navigate(@"E:\TrainingEng.V2\TrainingEng 0.0.1\Theory\Moy_dom.html");
                    }
                    else if (Globals.TheoryFail == "Moya_semya")
                    {
                        TheoryTwoTem1.Navigate(@"E:\TrainingEng.V2\TrainingEng 0.0.1\Theory\Moya_semya.html");
                    }
                    else if (Globals.TheoryFail == "V_vannoy")
                    {
                        TheoryTwoTem1.Navigate(@"E:\TrainingEng.V2\TrainingEng 0.0.1\Theory\V_vannoy.html");
                    }
                    else if (Globals.TheoryFail == "Veselo_v_shkole")
                    {
                        TheoryTwoTem1.Navigate(@"E:\TrainingEng.V2\TrainingEng 0.0.1\Theory\Veselo_v_shkole.html");
                    }
                }
                if (Globals.Classes == 3)
                { 

                }
                if (Globals.Classes == 4)
                {

                }
       
            }

            //TheoryTwoTem1.Navigate(@"E:\TrainingEng\TrainingEng 0.0.1\TrainingEng 0.0.1\TrainingEng 0.0.1\V_vannoy.html");
       
        }

        private void TwoThema1Practic_Click(object sender, RoutedEventArgs e)
        {
            TwoThemaPractic_1 nextPage = new TwoThemaPractic_1();
            NavigationService.Navigate(nextPage);
        }
    }
}
