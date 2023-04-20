using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UsersGoalPage.xaml
    /// </summary>
    public partial class UsersGoalPage : Page
    {
        HttpClient client = new HttpClient();
        GoalsCollection _goals = new GoalsCollection();
        UsersCollection _users = new UsersCollection();

        public int idActivities, idGenders, idGoal;
        public string login, password, age, height, weight;

        public  UsersGoalPage(string login, string password ,int idActivities ,int idGenders, string age, string height , string weight)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
            this.idActivities = idActivities;
            this.idGenders = idGenders;
            this.age = age;
            this.height = height;
            this.weight = weight;

            client.BaseAddress = new Uri("https://iis.ngknn.ru/ngknn/лебедевааф/");
            client.DefaultRequestHeaders.Accept.Add(
                           new MediaTypeWithQualityHeaderValue("application/json"));


            this.ListGoals.ItemsSource = _goals;
            ListOutput(); 
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.UserDataPage(login, password, idActivities));
        }

        /// <summary>
        /// метод для загрузки листа
        /// </summary>
        private async void ListOutput()
        {
            try
            {
                var response = await client.GetAsync("api/Goals");
                response.EnsureSuccessStatusCode(); // Throw on error code.
                var goals = await response.Content.ReadAsAsync<IEnumerable<Goals>>();
                _goals.CopyFrom(goals);
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

        /// <summary>
        /// метод для добавления нового пользователя
        /// </summary>
        private async void PostUsers()
        {
            try
            {
                var users = new Users()
                {
                    GenderId = idGenders,
                    Login = login,
                    Weight = Convert.ToDouble(weight),
                    Height = Convert.ToDouble(height),
                    ActivityId = idActivities,
                    GoalId = idGoal,
                    Calories = null,
                    Squirrels = null,
                    DateOfBirth =Convert.ToInt32(age),
                    Password= password,
                    Fats = null,
                    Carbohydrates = null
                };
                var response = await client.PostAsJsonAsync("api/Users", users);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                _users.Add(users);
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

        public void ButtonFurther_Click(object sender, RoutedEventArgs e)
        {
            if (CheckGoal1.IsChecked == true || CheckGoal2.IsChecked == true ||
                CheckGoal3.IsChecked == true )
            {
                PostUsers();

                Users us = _users.FirstOrDefault(x => x.Login == login && x.Password == password);
                if (us != null)
                {
                    FrameClass.frame.Navigate(new Pages.MainPage(us));
                }
                
            }
            else
            {
                TextBlockHint.Text = "Выберите цель";
            }
            
        }

        private void CheckGoal1_Checked(object sender, RoutedEventArgs e)
        {
            idGoal = 1;
            CheckGoal2.IsChecked = false;
            CheckGoal3.IsChecked = false;
        }

        private void CheckGoal2_Checked(object sender, RoutedEventArgs e)
        {
            idGoal = 2;
            CheckGoal1.IsChecked = false;
            CheckGoal3.IsChecked = false;
        }

        private void CheckGoal3_Checked(object sender, RoutedEventArgs e)
        {
            idGoal = 3;
            CheckGoal2.IsChecked = false;
            CheckGoal1.IsChecked = false;
        }
    }
}
