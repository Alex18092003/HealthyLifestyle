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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.UserDataPage(login, password, idActivities));
        }

        Users users;
        /// <summary>
        /// метод для добавления нового пользователя
        /// </summary>
        private void PostUsers()
        {
            users = new Users()
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
            if(icon1.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked ||
                icon2.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked ||
                icon3.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked )
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            idGoal = 1;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            idGoal = 2;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            idGoal = 3;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;

        }


    }
}
