using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для StepsPage.xaml
    /// </summary>
    public partial class StepsPage : Page
    {
        Recipes recipes1;

        public StepsPage(Recipes recipes)
        {
            InitializeComponent();

            this.recipes1 = recipes;
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

        }
    }
}
