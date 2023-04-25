using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для StepsPage.xaml
    /// </summary>
    public partial class StepsPage : Page
    {
        Recipes recipes1;
        Users users;

        DailyRation dailyRation;

        public StepsPage(Recipes recipes, Users users)
        {
            InitializeComponent();

            this.recipes1 = recipes;
            this.users = users;
            Conclusion();
        }


        /// <summary>
        /// метод для вывода данных
        /// </summary>
        private void Conclusion()
        {
            TextTitleRecipes.Text = recipes1.Title;
            TextDescriptionRecipes.Text = recipes1.Description;
            TextMinutesRecipes.Text = Convert.ToString(recipes1.MinutesOfCooking);
            TextComment.Text = recipes1.Comment;

            List<Steps> ad = DB.entities.Steps.Where(x => x.RecipeId == recipes1.RecipeId).ToList();
            ListSteps.ItemsSource = ad.ToList();

            List<IngredientForRecipe> ingredientForRecipes = DB.entities.IngredientForRecipe.Where(x => x.RecipeId == recipes1.RecipeId).ToList();
            ListIngredientsForRecepes.ItemsSource = ingredientForRecipes.ToList();

            TextBoxCaloriesIn100G.Text = Convert.ToString( recipes1.Calories);
            TextBox100g.Text = Convert.ToString(100);
            TextBoxSquirrels.Text = Convert.ToString(recipes1.Squirrels);
            TextBoxFat.Text = Convert.ToString(recipes1.Fats);
            TextBoxCarbohydrates.Text = Convert.ToString(recipes1.Carbohydrates);
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            DataToday.SelectedDate = dateTime;
            List<Meals> types = DB.entities.Meals.ToList();
            TextBoxMeal.Items.Add("Прием пищи");
            for (int i = 0; i < types.Count; i++)
            {
                TextBoxMeal.Items.Add(types[i].Title);
            }
            TextBoxMeal.SelectedIndex = 0;
        }

        private void ButtonAddDaily_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TextBox100g.Text == "")
            {
                MessageBox.Show("Необходимо ввести вес блюда");
                return;
            }

            if (TextBoxMeal.SelectedIndex == 0)
            {
                MessageBox.Show("Необходимо выбрать прием пищи");
                return;
            }
            dailyRation.UserId = users.UserId;
            dailyRation.RecepeId = recipes1.RecipeId;
            dailyRation.Date = Convert.ToDateTime(DataToday.SelectedDate);
            dailyRation.Calories = Convert.ToDouble(TextBoxCaloriesIn100G.Text);
            dailyRation.Squirrels = Convert.ToDouble(TextBoxSquirrels.Text);
            dailyRation.Fats = Convert.ToDouble(TextBoxFat.Text);
            dailyRation.Carbohydrates = Convert.ToDouble(TextBoxCarbohydrates.Text);
        }

        //запрет ввода символов
        private void TextBox100g_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.Text, 0) | (e.Text == Convert.ToString(",")) | e.Text == Convert.ToString('\b')) return;
                else
                    e.Handled = true;

            }
            catch
            {

            }
        }
    }
}
