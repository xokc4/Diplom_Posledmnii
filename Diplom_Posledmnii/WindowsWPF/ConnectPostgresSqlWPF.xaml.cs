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
    /// Логика взаимодействия для ConnectPostgresSqlWPF.xaml
    /// </summary>
    public partial class ConnectPostgresSqlWPF : Window
    {
        public ConnectPostgresSqlWPF()
        {
            InitializeComponent();
        }

        private void ConnectPostgresSql_Click(object sender, RoutedEventArgs e)
        {
            PostgersSqlBD.PostgresSql.GetDBConnection(AdressPGSql.Text, NameBasePGSql.Text, LoginPGSql.Text, PasswordPGSql.Text);
            MessageBox.Show("подключение успешно произошло");
            this.Close();
        }

        private void Bak_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
