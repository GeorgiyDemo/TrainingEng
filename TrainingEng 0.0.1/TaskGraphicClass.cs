using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TrainingEng_0._0._1
{

    class TaskGraphicClass
    {
        Image LocalImage;
        Label LocalLabel;
        TextBox LocalTextBox;
        RadioButton Radio1;
        RadioButton Radio2;
        RadioButton Radio3;
        RadioButton Radio4;
        
        public TaskGraphicClass(Image LocalImage, Label LocalLabel, TextBox LocalTextBox, RadioButton Radio1, RadioButton Radio2, RadioButton Radio3, RadioButton Radio4)
        {
            this.LocalImage = LocalImage;
            this.LocalLabel = LocalLabel;
            this.LocalTextBox = LocalTextBox;
            this.Radio1 = Radio1;
            this.Radio2 = Radio2;
            this.Radio3 = Radio3;
            this.Radio4 = Radio4;
        }

        //Проверяет на корректность выбранных данных
        public Boolean IsCorrect()
        {
            return true;
        }
    }
}
