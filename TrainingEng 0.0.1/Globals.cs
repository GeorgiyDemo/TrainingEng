using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingEng_0._0._1
{
    public static class Globals
    {
        public static int TheoryFail = 0;
        public static int Classes = 0;

        //Возвращает полный путь до корневой папки проекта
        public static String CurrentDirFormater()
        {
            String buffer = Directory.GetCurrentDirectory();
            String[] words = buffer.Split('\\');
            String[] newWords = words.Take(words.Count() - 2).ToArray();
            return String.Join("\\", newWords);

        }

        //Фильтрация на null
        public static String NullFilter(String Input)
        {
            String result;
            if (String.IsNullOrEmpty(Input) == true)
                result = "NULL";
            else
                result = Input;
            return result;
        }
        public static String NullFilter(Nullable Input)
        {
            String result;
            if (String.IsNullOrEmpty(Input) == true)
                result = "NULL";
            else
                result = Input;
            return "NULL";
        }
    }



}
