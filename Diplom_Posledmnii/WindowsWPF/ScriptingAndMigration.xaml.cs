using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Diplom_Posledmnii.WindowsWPF
{
    /// <summary>
    /// Логика взаимодействия для ScriptingAndMigration.xaml
    /// </summary>
    public partial class ScriptingAndMigration : Window
    {
        public static List<string> Mysqls;
        public static List<string> MyShekedTable = new List<string>();
        public static List<ScriptingPostgreSql> ListScriptTable  = new List<ScriptingPostgreSql>();
        
        public ScriptingAndMigration(List<string> vs)
        {
            InitializeComponent();
            List<TablesMySql> Mysqls =  ListTablesMethod(vs);

            ListTables.ItemsSource = Mysqls;
        }

        private void ConnectMainWPF_Click(object sender, RoutedEventArgs e)
        {
            WindowsWPF.ConnectPostgresSqlWPF connect = new ConnectPostgresSqlWPF();
            connect.Show();

        }

        private void MigrationMainWPF_Click(object sender, RoutedEventArgs e)
        {
            string Scripts = "";
            PostgersSqlBD.PostgresSql.ScriptsCreatTable(Scripts);
        }
        public static List<TablesMySql> ListTablesMethod(List<string> vs)
        {
            List<TablesMySql> tables = new List<TablesMySql>();
            foreach(var item in vs)
            { 
                tables.Add(new TablesMySql($"{item}"));
            }
            return tables;
        }
        private void SqlScripting_Click(object sender, RoutedEventArgs e)
        {
            FullScript();
            FullInfScriptMethod();
            ListScipting.ItemsSource = ListScriptTable;
        }

        private void CheckBoxNameTb(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = sender as CheckBox;
            string textCH = chBox.Content.ToString();
            MyShekedTable.Add($"{textCH}");
        }


        public static string ScriptTable(string Name)
        {
            Dictionary<string, string> InfOnliDatabase = MySqlBD.MySqlDataBase.TabliesOne(Name);
            string script = $"CREATE TABLE {Name} (";
            int  firstElement= 0;
            foreach (var item in InfOnliDatabase)
            {
                foreach (var itemPermen in PostgersSqlBD.PostgresSql.CollectionPer)
                {
                    if(itemPermen.Key == item.Value)
                    {
                        if (firstElement == 0)
                        {
                            script += $" {item.Key} {itemPermen.Value}";
                            firstElement++;
                        }
                        else
                        {
                            script += $", {item.Key} {item.Value}";
                        }
                    }
                }
            }
            script += ");";
            return script;
        }
        public static void FullInfScriptMethod()
        {
            foreach (var item in MyShekedTable)
            {
                List<string> infBD = MySqlBD.MySqlDataBase.INF_Table(item);
                string script = $"INSERT INTO {item} VALUES";
                foreach (var ItemString in infBD)
                {
                    string last = infBD.LastOrDefault();
                    script += "(";
                    string[] vs = ItemString.Split(new char[] { ','});
                    for (int i = 0; i < vs.Length; i++)
                    {
                        if(i==0) script += $"{vs[i]}";
                        else script += $",{vs[i]}";
                    }
                    if(last== ItemString.ToString())script += $")";
                    else script += $"),";
                }
                script += ";";
                ListScriptTable.Add(new ScriptingPostgreSql(script));
            }
        }




        public static void FullScript()
        {
            foreach (var table in MyShekedTable)
            {
                string script = ScriptTable(table);
                ListScriptTable.Add(new ScriptingPostgreSql(script));
            }
        }
    }
}
