using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersGoalPage.xaml
    /// </summary>
    public partial class UsersGoalPage : Page
    {

        public int idActivities, idGenders, idGoal;
        public string login, password, age, height, weight;

        public UsersGoalPage(string login, string password, int idActivities, int idGenders, string age, string height, string weight)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
            this.idActivities = idActivities;
            this.idGenders = idGenders;
            this.age = age;
            this.height = height;
            this.weight = weight;

            this.ListGoals.ItemsSource = DB.entities.Goals.ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.UserDataPage(login, password, idActivities));
        }

        /// <summary>
        /// метод для добавления нового пользователя
        /// </summary>
        private void PostUsers()
        {
            Users users = new Users()
            {
                GenderId = idGenders,
                Login = login,
                Weight = Convert.ToDouble(weight),
                Height = Convert.ToDouble(height),
                ActivityId = idActivities,
                GoalId = idGoal,
                Calories = null,
                Squirrels = null,
                DateOfBirth = Convert.ToInt32(age),
                Password = password,
                Fats = null,
                Carbohydrates = null
            };

            DB.entities.Users.Add(users);
            DB.entities.SaveChanges();
        }

        public void ButtonFurther_Click(object sender, RoutedEventArgs e)
        {
            if (CheckGoal1.IsChecked == true || CheckGoal2.IsChecked == true ||
                CheckGoal3.IsChecked == true)
            {
                PostUsers();
                Users us = DB.entities.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
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
