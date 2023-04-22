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
    /// Логика взаимодействия для RecipesPage.xaml
    /// </summary>
    public partial class RecipesPage : Page
    {

        public RecipesPage()
        {
            InitializeComponent();

            ListRecipes.ItemsSource = DB.entities.Recipes.ToList();

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

            //фильтрация по приему пищи
            if (indexMeals != 0)
            {
                r = r.Where(x => x.MealId == indexMeals).ToList();
            }
          
            //фильтрация по типу рецепта
            if (indexRecipeTypes != 0)
            {
                r = r.Where(x => x.RecipeType == indexRecipeTypes).ToList();
            }
          

            //фильтрация по специфики
            if (indexSpecifics != 0)
            {
                r = r.Where(x => x.SpecificsId == indexSpecifics).ToList();
            }
         

            //фильтрация по способу приготовления
            if (indexPreparations != 0)
            {
                r = r.Where(x => x.CookingId == indexPreparations).ToList();
            }
          

            //фильтрация по кухне
            if (indexKitchens != 0)
            {
                r = r.Where(x => x.KitchenId == indexKitchens).ToList();
            }
         

            //фильтрация по сложности
            if (indexDifficulties != 0)
            {
                r = r.Where(x => x.DifficultyId == indexDifficulties).ToList();
            }
        

            //фильтрация по сложности
            if (indexMinutesOfCooking != 0)
            {
                switch(ComboBoxMinutesOfCooking.SelectedIndex)
                {
                    case 1:
                        {
                            r = r.Where(x => x.MinutesOfCooking <=10).ToList();
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
                MessageBox.Show("Нет записей", "Сообщение");
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
            Grid st = (Grid)sender;
            int id = Convert.ToInt32(st.Uid);
            Recipes recipes = DB.entities.Recipes.FirstOrDefault(x => x.RecipeId == id);
            Classes.FrameClassTwo.frame.Navigate(new Pages.StepsPage(recipes));
        }
    }
}
