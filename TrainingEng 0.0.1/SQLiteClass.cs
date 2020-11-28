using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingEng_0._0._1
{
    class SQLiteClass
    {
        private static string ConnectionPath = "DataSource=../../../TrainingEng.db;";

        //Выполнение операции над SQLite без возврата значения (UPDATE, INSERT, DELETE и т.д) 
        public static void SQLiteExecute(string sql)
        {

            SqliteConnection myConn = new SqliteConnection(ConnectionPath);
            SqliteCommand sqCommand = new SqliteCommand(sql);
            sqCommand.Connection = myConn;
            myConn.Open();
            try
            {
                sqCommand.ExecuteNonQuery();
            }
            finally
            {
                myConn.Close();
            }
        }

        //Получение одного объекта из SQLite по SQL-строке
        public static string SQLiteGetOne(string sql)
        {
            string outstr = "";
            using (SqliteConnection con = new SqliteConnection(ConnectionPath))
            {
                con.Open();

                using (SqliteCommand cmd = new SqliteCommand(sql, con))
                {
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                            outstr += rdr.GetString(0);
                    }
                }

                con.Close();
            }
            return outstr;
        }

        //Получение заданий (объектов класса TaskClass) из SQLite
        public static List<TaskClass> SQLiteGetTasks(int TopicNumber, int ClassNumber)
        {

            var TasksList = new List<TaskClass>();
            
            using (SqliteConnection con = new SqliteConnection(ConnectionPath))
            {
                con.Open();

                String SqlString = "SELECT * FROM Tasks WHERE (topic_id =" + TopicNumber + " AND class_id=" + ClassNumber + ");";
                using (SqliteCommand cmd = new SqliteCommand(SqlString, con))
                {
                    using (SqliteDataReader r = cmd.ExecuteReader())
                    {
                        //Читаем данные из СУБД
                        while (r.Read())
                        {
                            //Создаем экземпляры TaskClass
                            TaskClass obj = new TaskClass(r.GetString(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetString(5), r.GetString(6), r.GetString(7), r.GetString(8), r.GetString(9));
                            //Добавляем в список
                            TasksList.Add(obj);
                        }
                    }
                }

                con.Close();
            }
            return TasksList;

        }

          
    }
}
