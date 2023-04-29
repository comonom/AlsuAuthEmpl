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

namespace AlsuAuthEmpl
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DataContext = App.LocalUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //здесь также проверки на заполнение остальных полей напиши как ниже, ток сравнение что tbLogin.Text != ""
            if (cbPol.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите пол");
                return;
            }
            bool isMale = cbPol.SelectedIndex == 0; //если первый элемент - это М, иначе Ж
            //ЧТОБЫ ВСТАВКА РАБОТАЛА, НЕ ЗАБУДЬ AUTOINCREMENT ПОСТАВИТЬ НА СТОЛБЕЦ АЙДИШНИКА
            //Допустим что я буду писать про пол в роль, не суть важно
            try
            {
                DbContext.Context.Select(@$"
                INSERT INTO `users` (`user_familiya`, `user_name`, `user_patronymic`, `user_role`, `user_podr`)
                VALUES
                ('{tbFam.Text}', '{tbName.Text}', '{tbPat.Text}', '{cbPol.SelectedIndex}', 0)");

                MessageBox.Show("Успешно добавлено!");

                //Не забудь очистить поля
                tbFam.Text = "";
                tbPat.Text = "";
                tbName.Text = "";
                cbPol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении" + ex.Message);
            }
        }
    }
}
