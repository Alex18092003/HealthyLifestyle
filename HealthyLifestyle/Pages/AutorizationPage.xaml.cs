using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {

        public AutorizationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// метод для проверки логина и пароля пользователя
        /// </summary>
        public void СheckAuthorization()
        {
            if (TextBoxPassword.Password == "" || TextBoxLogin.Text == "")
            {
                TextBlockHint.Text = "Поля не заполены\nДля входа необходимо ввести логин И пароль или пройти Регистрацию";
            }
            else
            {
                Users us = DB.entities.Users.FirstOrDefault(x => x.Login == TextBoxLogin.Text && x.Password == TextBoxPassword.Password);
                if (us != null)
                {
                    FrameClass.frame.Navigate(new Pages.MainPage(us));
                }
                else
                {
                    TextBlockHint.Text = "Введен неверный логин или пароль\nВозможно вы не зарегистрированы";
                    TextBoxLogin.Text = "";
                    TextBoxPassword.Password = "";
                }
            }

        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            СheckAuthorization();
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.NewUserPage());
        }

        private void TextBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBoxPassword.Focus();

            }
        }

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                СheckAuthorization();
            }
        }

        private void imVisiblePassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void ShowPassword()
        {
            imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible.png", UriKind.Relative));
            pbPasswordVisible.Visibility = Visibility.Visible;
            TextBoxPassword.Visibility = Visibility.Collapsed;
            pbPasswordVisible.Text = TextBoxPassword.Password;
        }

        private void HidePassword()
        {
            imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible.png", UriKind.Relative));
            pbPasswordVisible.Visibility = Visibility.Collapsed;
            TextBoxPassword.Visibility = Visibility.Visible;
            TextBoxPassword.Focus();
        }

        private void imVisiblePassword_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }
    }
}
