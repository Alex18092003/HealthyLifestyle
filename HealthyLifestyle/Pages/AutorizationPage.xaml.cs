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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {

        HttpClient client = new HttpClient();
        UsersCollection _users = new UsersCollection();
        public AutorizationPage()
        {
            InitializeComponent();


            client.BaseAddress = new Uri("https://iis.ngknn.ru/ngknn/лебедевааф/");
            client.DefaultRequestHeaders.Accept.Add(
                           new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// метод для проверки логина и пароля пользователя
        /// </summary>
        public async void СheckAuthorization()
        {
            try
            {
                var response = await client.GetAsync("api/Users");
                response.EnsureSuccessStatusCode(); 

                var users = await response.Content.ReadAsAsync<ObservableCollection<Users>>();
                _users.CopyFrom(users);

                if (TextBoxPassword.Password == "" || TextBoxLogin.Text == "")
                {
                    TextBlockHint.Text = "Поля не заполены\nДля входа необходимо ввести логин И пароль или пройти Регистрацию";
                }
                else
                {

                     Users us = _users.FirstOrDefault(x => x.Login == TextBoxLogin.Text && x.Password == TextBoxPassword.Password);
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
            catch (Newtonsoft.Json.JsonException jEx)
            {
                // This exception indicates a problem deserializing the request body.
                MessageBox.Show(jEx.Message);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
