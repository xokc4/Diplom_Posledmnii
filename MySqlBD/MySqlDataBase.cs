using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace MySqlBD
{
    
    public class MySqlDataBase
    {
        public static string HOST;
        public static string PORT;
        public static string DATABASE;
        public static string USERNAME;
        public static string PASSWORD;
        /// <summary>
        ///  Connection String
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="database"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static MySqlConnection GetDBConnection(string host, string port, string database, string username, string password)
        {
            HOST = host;
            PORT = port;
            DATABASE = database;
            USERNAME = username;
            PASSWORD = password;
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
        public static List<string> DatabaseTablies()
        {
            MySqlConnection conn = GetDBConnection(HOST, PORT, DATABASE, USERNAME, PASSWORD);
            string sql = $"SHOW TABLES;";
            conn.Open();

            List<string> List = new List<string>();

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                List.Add(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
            return List;
        }

        public static Dictionary<string, string> TabliesOne(string NameTable)
        {
            MySqlConnection conn = GetDBConnection(HOST, PORT, DATABASE, USERNAME, PASSWORD);
            string sql = $"DESCRIBE {NameTable};";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            Dictionary<string, string> InfTables = new Dictionary<string, string>();
            while (reader.Read())
            {
                InfTables.Add(reader[0].ToString(), reader[1].ToString());
            }
            reader.Close();
            conn.Close();
            return InfTables;
        }
        public static List<string> INF_Table(string NameTable)
        {
            MySqlConnection conn = GetDBConnection(HOST, PORT, DATABASE, USERNAME, PASSWORD);
            string sql = $"SELECT * FROM {NameTable};";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> List = new List<string>();
            while (reader.Read())
            {
                string inf ="";
               for (int i=0;i<reader.FieldCount;i++)
               {
                    if(i==0)
                    {
                        inf += $"{reader[i]}";
                    }
                    else
                    {
                        inf += $",{reader[i]}";
                    }
               }
                List.Add(inf);
            }
            reader.Close();
            conn.Close();
            return List;
        }
    }
}
