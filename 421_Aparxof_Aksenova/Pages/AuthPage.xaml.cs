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

namespace _421_Aparxof_Aksenova.Pages
{
 
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }


        private void loginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ваш код для обработки изменения текста в loginTextBox
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Код для обработки изменения пароля (если требуется)
        }

        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password = passwordBox.Password.Trim();

            // Проверка на заполненность полей
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка учетной записи в базе данных
            using (Entities context = new Entities())
            {
                // Попробуем найти пользователя с соответствующим логином и паролем
                var user = context.User.FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null) // Если пользователь найден
                {
                    MessageBox.Show("Пользователь успешно найден!");

                    switch (user.Role)
                    {
                        case "admin":
                            NavigationService?.Navigate(new AdminMenu());
                            break;
                        case "user":
                            NavigationService?.Navigate(new UserMenu());
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Учетная запись не найдена. Пожалуйста, проверьте ваши данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}