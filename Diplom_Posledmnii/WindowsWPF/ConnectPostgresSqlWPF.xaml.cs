
using System.Windows;


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
