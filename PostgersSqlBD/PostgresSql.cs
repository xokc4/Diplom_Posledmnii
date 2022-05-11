using Npgsql;
using System;
using System.Collections.Generic;

namespace PostgersSqlBD
{
    public class PostgresSql
    {
        public static string HOST;
        public static string DATABASE;
        public static string USERNAME;
        public static string PASSWORD;
        public static Dictionary<string, string> CollectionPer = new Dictionary<string, string>()
        { 
            { "CHAR", "character" },
            { "VARCHAR", "character varying" },
            { "text", "text" },
            { "TINYTEXT", "TEXT" },
            { "MEDIUMTEXT", "TEXT" },
            { "LARGETEXT", "TEXT" },
            { "TINYINT", "INT" },
            { "BOOL", "boolean" },
            { "TINYINT UNSIGNED", "INT" },
            { "SMALLINT", "integer" },
            { "SMALLINT UNSIGNED", "serial" },
            { "MEDIUMINT", "integer" },
            { "MEDIUMINT UNSIGNED", "smallint" },
            { "int", "int" },
            { "INT UNSIGNED", "bigint" },
            { "BIGINT", "bigint" },
            { "BIGINT UNSIGNED", "bigint" },
            { "DECIMAL", "decimal" },
            { "FLOAT", "decimal" },
            { "DOUBLE", "decimal" },
            { "date", "date" },
            { "TIME", "time" },
            { "datetime", "date" },
            { "TIMESTAMP", "timestamp" },
            { "YEAR", "date" },
            { "char(3)", "char(3)" }
        };

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
    }
}
