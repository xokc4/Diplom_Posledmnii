using Npgsql;
using System;

namespace PostgersSqlBD
{
    public class PostgresSql
    {
        public static string HOST;
        public static string DATABASE;
        public static string USERNAME;
        public static string PASSWORD;

        public static NpgsqlConnection GetDBConnection(string host, string database, string username, string password)
        {
            HOST = host;
            DATABASE = database;
            USERNAME = username;
            PASSWORD = password;
            String connString =$"Host={host};Username={username};Password={password};Database={database}";

            NpgsqlConnection conn =  new NpgsqlConnection(connString);

            return conn;
        }

        public static void ScriptsCreatTable(string scripts)
        {
            try
            {
                NpgsqlConnection conn = GetDBConnection(HOST, DATABASE, USERNAME, PASSWORD);
                conn.Open();
                NpgsqlCommand npgc = new NpgsqlCommand(scripts, conn);


                conn.Close();
            }
            catch(Exception e)
            {
                 e.ToString();
            }
           
        }
        public static void ScriptsInfTables(string scripts)
        {
            try
            {
                NpgsqlConnection conn = GetDBConnection(HOST, DATABASE, USERNAME, PASSWORD);
                conn.Open();
                NpgsqlCommand npgc = new NpgsqlCommand(scripts, conn);


                conn.Close();
            }
            catch (Exception e)
            {
                 e.ToString();
            }
        }
    }
}
