using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecipesPage.xaml
    /// </summary>
    public partial class RecipesPage : Page
    {
        Users users;
        public RecipesPage(Users users)
        {
            InitializeComponent();
            this.users = users;
            Conclusion();
        }

        private void Conclusion()
        {
            ListRecipes.ItemsSource = DB.entities.Recipes.ToList();

            List<Meals> types = DB.entities.Meals.ToList();
            ComboBoxMeals.Items.Add("Прием пищи");
            for (int i = 0; i < types.Count; i++)
            {
                ComboBoxMeals.Items.Add(types[i].Title);
            }

            List<RecipeTypes> recipeTypes = DB.entities.RecipeTypes.ToList();
            ComboBoxRecipeTypes.Items.Add("Тип рецепта");
            for (int i = 0; i < recipeTypes.Count; i++)
            {
                ComboBoxRecipeTypes.Items.Add(recipeTypes[i].Title);
            }

            List<Specifics> specifics = DB.entities.Specifics.ToList();
            ComboBoxSpecifics.Items.Add("Специфика");
            for (int i = 0; i < specifics.Count; i++)
            {
                ComboBoxSpecifics.Items.Add(specifics[i].Title);
            }

            List<Preparations> preparations = DB.entities.Preparations.ToList();
            ComboBoxPreparations.Items.Add("Приготовление");
            for (int i = 0; i < preparations.Count; i++)
            {
                ComboBoxPreparations.Items.Add(preparations[i].Title);
            }

            List<Kitchens> kitchens = DB.entities.Kitchens.ToList();
            ComboBoxKitchens.Items.Add("Кухня");
            for (int i = 0; i < kitchens.Count; i++)
            {
                ComboBoxKitchens.Items.Add(kitchens[i].Title);
            }

            List<Difficulties> difficulties = DB.entities.Difficulties.ToList();
            ComboBoxDifficulties.Items.Add("Сложность");
            for (int i = 0; i < difficulties.Count; i++)
            {
                ComboBoxDifficulties.Items.Add(difficulties[i].Title);
            }

            List<Diets> diets = DB.entities.Diets.ToList();
            ComboBoxDiets.Items.Add("Диеты");
            for (int i = 0; i < diets.Count; i++)
            {
                ComboBoxDiets.Items.Add(diets[i].Title);
            }

            ComboBoxMeals.SelectedIndex = 0;
            ComboBoxRecipeTypes.SelectedIndex = 0;
            ComboBoxSpecifics.SelectedIndex = 0;
            ComboBoxPreparations.SelectedIndex = 0;
            ComboBoxKitchens.SelectedIndex = 0;
            ComboBoxDifficulties.SelectedIndex = 0;
            ComboBoxMinutesOfCooking.SelectedIndex = 0;
            ComboBoxDiets.SelectedIndex = 0;
        }


        /// <summary>
        /// Метод для фильтрации рецептов
        /// </summary>
        private void Filter()
        {
            List<Recipes> r = DB.entities.Recipes.ToList();

            int indexMeals = ComboBoxMeals.SelectedIndex;
            int indexRecipeTypes = ComboBoxRecipeTypes.SelectedIndex;
            int indexSpecifics = ComboBoxSpecifics.SelectedIndex;
            int indexPreparations = ComboBoxPreparations.SelectedIndex;
            int indexKitchens = ComboBoxKitchens.SelectedIndex;
            int indexDifficulties = ComboBoxDifficulties.SelectedIndex;
            int indexMinutesOfCooking = ComboBoxMinutesOfCooking.SelectedIndex;
            int indexDiets = ComboBoxDiets.SelectedIndex;

            //фильтрация по приему пищи
            if (indexMeals > 0)
            {
                r = r.Where(x => x.MealId == indexMeals).ToList();
            }

            //фильтрация по диете
            if (indexDiets > 0)
            {
                r = r.Where(x => x.DietId == indexDiets).ToList();
            }


            //фильтрация по типу рецепта
            if (indexRecipeTypes > 0)
            {
                r = r.Where(x => x.RecipeType == indexRecipeTypes).ToList();
            }


            //фильтрация по специфики
            if (indexSpecifics > 0)
            {
                r = r.Where(x => x.SpecificsId == indexSpecifics).ToList();
            }


            //фильтрация по способу приготовления
            if (indexPreparations > 0)
            {
                r = r.Where(x => x.CookingId == indexPreparations).ToList();
            }


            //фильтрация по кухне
            if (indexKitchens > 0)
            {
                r = r.Where(x => x.KitchenId == indexKitchens).ToList();
            }


            //фильтрация по сложности
            if (indexDifficulties > 0)
            {
                r = r.Where(x => x.DifficultyId == indexDifficulties).ToList();
            }


            //фильтрация по сложности
            if (indexMinutesOfCooking > 0)
            {
                switch (ComboBoxMinutesOfCooking.SelectedIndex)
                {
                    case 1:
                        {
                            r = r.Where(x => x.MinutesOfCooking <= 10).ToList();
                        }
                        break;
                    case 2:
                        {
                            r = r.Where(x => x.MinutesOfCooking <= 20).ToList();
                        }
                        break;
                    case 3:
                        {
                            r = r.Where(x => x.MinutesOfCooking <= 30).ToList();
                        }
                        break;
                    case 4:
                        {
                            r = r.Where(x => x.MinutesOfCooking <= 40).ToList();
                        }
                        break;
                    case 5:
                        {
                            r = r.Where(x => x.MinutesOfCooking <= 50).ToList();
                        }
                        break;
                    case 6:
                        {
                            r = r.Where(x => x.MinutesOfCooking <= 60).ToList();
                        }
                        break;
                    case 7:
                        {
                            r = r.Where(x => x.MinutesOfCooking > 60).ToList();
                        }
                        break;
                }
            }

            //поиск по названию
            if (!string.IsNullOrWhiteSpace(TextBoxSearchTitle.Text))
            {
                r = r.Where(x => x.Title.ToLower().Contains(TextBoxSearchTitle.Text.ToLower())).ToList();
            }

            ListRecipes.ItemsSource = r;
            if (r.Count == 0)
            {
                string str = "По вашим параметрам не найдено рецептов";
                Windows.Eror eror = new Windows.Eror(users, str);
                eror.ShowDialog();
                Classes.FrameClassTwo.frame.Navigate(new Pages.RecipesPage(users));
            }
        }

        private void ComboBoxMeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TextBoxSearchTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void STToTheSteps_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border st = (Border)sender;
            int id = Convert.ToInt32(st.Uid);
            Recipes recipes = DB.entities.Recipes.FirstOrDefault(x => x.RecipeId == id);
            Classes.FrameClassTwo.frame.Navigate(new Pages.StepsPage(recipes, users));
        }

    }
}
