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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom_Posledmnii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void ButtonMigr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlBD.MySqlDataBase.GetDBConnection(AdressMySql.Text, PortMysql.Text, NameBaseMySql.Text, LoginMySql.Text, PasswordMySql.Text);
                List<string> NameTable = MySqlBD.MySqlDataBase.DatabaseTablies();
                WindowsWPF.ScriptingAndMigration scripting = new WindowsWPF.ScriptingAndMigration(NameTable);
                scripting.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.ToString()}");
            }
        }
    }
}
