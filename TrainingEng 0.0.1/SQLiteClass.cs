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
        private static string ConnectionPath = "DataSource=../../../../MillionDatabase.db;";
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

        public static string SQLiteGet(string sql)
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
    }
}
