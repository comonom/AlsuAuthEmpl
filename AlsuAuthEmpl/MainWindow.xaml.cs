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

namespace AlsuAuthEmpl
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //допустим что у нас podr = 1 это охрана, а 2 это офисный работник
            var dtOhrana = DbContext.Context.Select(
                $"SELECT * FROM `users` WHERE `user_login` = '{tbLogin.Text}' AND `user_pass` = '{tbPass.Text}' and `user_podr` = 1");
            var dtOffice = DbContext.Context.Select(
                $"SELECT * FROM `users` WHERE `user_login` = '{tbLogin.Text}' AND `user_pass` = '{tbPass.Text}' and `user_podr` = 2");

            if (dtOhrana.Rows.Count > 0)
            {
                new OhranaWindow().Show();
                Hide();
            }
            else if(dtOffice.Rows.Count > 0)
            {
                new OfficeWindow().Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void roleClick(object sender, RoutedEventArgs e)
        {
            if(cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль");
            }
            else if(cbRole.SelectedIndex == 0)
            {
                var dtAdmin = DbContext.Context.Select(
                $"SELECT * FROM `users` WHERE `user_login` = '{tbLogin.Text}' AND `user_pass` = '{tbPass.Text}' and `user_role` = 1");
                if(dtAdmin.Rows.Count > 0)
                {
                    //в файле app.xaml.cs создал статик переменную для хранения текущего авторизованного пользователя
                    //чтобы потом в окне показать его фио
                    App.LocalUser = new User(dtAdmin.Rows[0]);
                    new AdminWindow().Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Не удалось авторизоваться.");
                }
            }
            else
            {
                MessageBox.Show("В разработке");
            }
        }
    }
}
