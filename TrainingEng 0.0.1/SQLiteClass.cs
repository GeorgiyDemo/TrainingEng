using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

                            //Получаем поля
                            String TaskId = r.IsDBNull(1) ? null : r.GetString(1);
                            String TopicId = r.IsDBNull(2) ? null : r.GetString(2);
                            String ClassId = r.IsDBNull(3) ? null : r.GetString(3);
                            String TypeId = r.IsDBNull(4) ? null : r.GetString(4);
                            String Text = r.IsDBNull(5) ? null : r.GetString(5);
                            String Photo = r.IsDBNull(6) ? null : r.GetString(6);
                            String Option1 = r.IsDBNull(7) ? null : r.GetString(7);
                            String Option2 = r.IsDBNull(8) ? null : r.GetString(8);
                            String Option3 = r.IsDBNull(9) ? null : r.GetString(9);
                            String Option4 = r.IsDBNull(10) ? null : r.GetString(10);

                            TaskClass obj = new TaskClass(TaskId, TopicId, ClassId, TypeId, Text, Photo, Option1, Option2, Option3, Option4);
                            //Добавляем в список
                            TasksList.Add(obj);
                        }
                    }
                }

                con.Close();
            }
            return TasksList;

        }

        public static List<UserResultsClass> SQLiteGetUserResults(String UserName)
        {
            var UserResultsList = new List<UserResultsClass>();

            using (SqliteConnection con = new SqliteConnection(ConnectionPath))
            {
                con.Open();

                String SQLString = String.Format("SELECT * FROM Results WHERE username='{0}';", UserName);
                using (SqliteCommand cmd = new SqliteCommand(SQLString, con))
                {
                    using (SqliteDataReader r = cmd.ExecuteReader())
                    {
                        //Читаем данные из СУБД
                        while (r.Read())
                        {
                            UserResultsClass obj = new UserResultsClass(r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetString(5));
                            //Добавляем в список
                            UserResultsList.Add(obj);
                        }
                    }
                }
            }
            return UserResultsList;
        }
    }
}
