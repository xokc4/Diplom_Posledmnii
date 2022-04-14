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
            
        }

    }
}
