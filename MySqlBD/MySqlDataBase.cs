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
            string sql = $"SHOW OPEN TABLES;";
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
        public static string TabliesOne(string NameTable)
        {
            MySqlConnection conn = GetDBConnection(HOST, PORT, DATABASE, USERNAME, PASSWORD);

            string sql = $" SHOW[FULL] COLUMNS FROM {NameTable}[FROM {DATABASE}] [LIKE wild]";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            return "54";
        }
        public static string INF_Table(string NameTable)
        {
            return "23";
        }
    }
}
