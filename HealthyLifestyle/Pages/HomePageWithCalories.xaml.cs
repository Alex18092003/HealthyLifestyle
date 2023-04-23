using System;
using System.Windows;
using System.Windows.Controls;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePageWithCalories.xaml
    /// </summary>
    public partial class HomePageWithCalories : Page
    {
        Users us;
        public HomePageWithCalories(Users us)
        {
            InitializeComponent();

            this.us = us;
            TextBlockCalories.Text = Convert.ToString(us.CaloriesUsers);
            us.GenderId = us.GenderId;
            us.Login = us.Login;
            us.Weight = us.Weight;
            us.Height = us.Height;
            us.ActivityId = us.ActivityId;
            us.GoalId = us.GoalId;
            us.Squirrels = us.Squirrels;
            us.DateOfBirth = us.DateOfBirth;
            us.Password = us.Password;
            us.Fats = us.Fats;
            us.Carbohydrates = us.Carbohydrates;
            us.Calories = us.Calories;
            s();


        }

        private void s()
        {
            us.Calories = us.CaloriesUsers;
            DB.entities.SaveChanges();
        }
    }
}
