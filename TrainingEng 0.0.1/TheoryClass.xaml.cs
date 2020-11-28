﻿using System;
using System.Collections.Generic;
using System.IO;
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

            if (Globals.TheoryFail != 0)
            {

                //Получает текущую директорию
                String CurrentDir = CurrentDirFormater();
                //Текущий номер задания
                String TaskNumber = Globals.TheoryFail.ToString();
                //Выбранный класс школьника
                String TaskClass = Globals.Classes.ToString();

                TheoryItem.Navigate(CurrentDir + @"\Theory\"+TaskClass+"_"+TaskNumber+".html");
       
            }

        }
        
        //Возвращает полный путь до корневой папки проекта
        private String CurrentDirFormater()
        {
            String buffer = Directory.GetCurrentDirectory();
            String[] words = buffer.Split('\\');
            String[] newWords = words.Take(words.Count() - 2).ToArray();
            return String.Join("\\", newWords);
    
        }

        private void TwoThema1Practic_Click(object sender, RoutedEventArgs e)
        {
            PracticeClass nextPage = new PracticeClass();
            NavigationService.Navigate(nextPage);
        }
    }
}
