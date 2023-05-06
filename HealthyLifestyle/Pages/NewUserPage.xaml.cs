using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewUserPage.xaml
    /// </summary>
    public partial class NewUserPage : Page
    {
        public NewUserPage()
        {
            InitializeComponent();

        }

        /// <summary>
        /// метод для проверки логина и пароля пользователя
        /// </summary>
        private void СheckUsers()
        {
                if (TextBoxPassword.Password == "" || TextBoxLogin.Text == "")
                {

                    TextBlockHint.Text = "Поля не заполены\nНеобходимо придумать логин И пароль";
                   
                }
                else
                {
                    Users us = DB.entities.Users.FirstOrDefault(x => x.Login == TextBoxLogin.Text);
                    if (us == null)
                    {
                        string login = TextBoxLogin.Text;
                        string password = TextBoxPassword.Password;
                        FrameClass.frame.Navigate(new Pages.ActivitiesPage(login, password));
                    }
                    else
                    {

                        TextBlockHint.Text = "Пользователь с таким логином уже зарегистрирован";
                     
                    }
                }
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            СheckUsers();
            
        }

        private void ButtonAutorization_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.AutorizationPage());
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
                СheckUsers();
            }
        }

        private void imVisiblePassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void ShowPassword()
        {
            if (pbPasswordVisible.Visibility == Visibility.Visible)
            {
                imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible1.png", UriKind.Relative));
                pbPasswordVisible.Visibility = Visibility.Collapsed;
                TextBoxPassword.Visibility = Visibility.Visible;
                TextBoxPassword.Focus();
            }
            else
            {
                imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible1.png", UriKind.Relative));
                pbPasswordVisible.Visibility = Visibility.Visible;
                TextBoxPassword.Visibility = Visibility.Collapsed;
                pbPasswordVisible.Text = TextBoxPassword.Password;
            }
        }

        private void HidePassword()
        {
            imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible1.png", UriKind.Relative));
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
