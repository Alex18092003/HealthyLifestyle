using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            CaloriesDay.Text = Convert.ToString(us.CaloriesInDay);
            brush();
        }

        private void brush()
        {
            if (Convert.ToDouble(CaloriesDay.Text) > Convert.ToDouble(TextBlockCalories.Text))
            {
                CaloriesDay.Foreground = Brushes.Red;
                HintText.Visibility = Visibility.Visible;
                HintText.Text = "Предупреждение\nВы превысили дневную норму калорий";
                HintText.Foreground = Brushes.Red;
            }
            else
            {
                SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFromString("#274025");
                CaloriesDay.Foreground = color;
            }
        }

        private void s()
        {
            us.Calories = us.CaloriesUsers;
            DB.entities.SaveChanges();
        }
    }
}
