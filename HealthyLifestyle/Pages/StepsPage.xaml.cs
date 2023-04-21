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
    /// Логика взаимодействия для StepsPage.xaml
    /// </summary>
    public partial class StepsPage : Page
    {
        HttpClient client = new HttpClient();
        StepsCollection _steps = new StepsCollection();
        IngredientForRecipeCollection _ingredients = new IngredientForRecipeCollection();
        IngredientsCollection _ingredient = new IngredientsCollection();
        Recipes recipes1;


        public StepsPage(Recipes recipes)
        {
            InitializeComponent();

            this.recipes1 = recipes;
            client.BaseAddress = new Uri("https://iis.ngknn.ru/ngknn/лебедевааф/");
            client.DefaultRequestHeaders.Accept.Add(
                           new MediaTypeWithQualityHeaderValue("application/json"));


      
            ListOutput();
            ListOutputIngredientForRecipes();
            ListOutputIngredient();
        }

        /// <summary>
        /// метод для загрузки листа шагов
        /// </summary>
        private async void ListOutput()
        {
            try
            {
                var response = await client.GetAsync("api/Steps");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var steps = await response.Content.ReadAsAsync<IEnumerable<Steps>>();
                _steps.CopyFrom(steps);
                List<Steps> s = _steps.Where(x => x.RecipeId == recipes1.RecipeId).ToList();
               
                this.ListSteps.ItemsSource = s;
                TextTitleRecipes.Text = recipes1.Title;
                TextDescriptionRecipes.Text = recipes1.Description;
                TextMinutesRecipes.Text = Convert.ToString( recipes1.MinutesOfCooking);
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

        List<IngredientForRecipe> ing;
        /// <summary>
        /// метод для загрузки листа ингридиента
        /// </summary>
        private async void ListOutputIngredientForRecipes()
        {
            try
            {
                var response = await client.GetAsync("api/IngredientForRecipes");
                response.EnsureSuccessStatusCode(); // Throw on error code.
                var ingredients = await response.Content.ReadAsAsync<IEnumerable<IngredientForRecipe>>();
                _ingredients.CopyFrom(ingredients);

                ing = _ingredients.Where(x => x.RecipeId == recipes1.RecipeId).ToList();
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

        List<Ingredients> ingred;
        /// <summary>
        /// метод для загрузки листа ингридиента
        /// </summary>
        private async void ListOutputIngredient()
        {
            try
            {
                var response = await client.GetAsync("api/Ingredients");
                response.EnsureSuccessStatusCode(); // Throw on error code.
                var ingredient = await response.Content.ReadAsAsync<IEnumerable<Ingredients>>();
                _ingredient.CopyFrom(ingredient);
               
                foreach(IngredientForRecipe ingredientForRecipe in ing)
                {
                    ingred = _ingredient.Where(x => x.IngredientId == ingredientForRecipe.IngredientId).ToList();
                   
                }
                this.ListIngredients.ItemsSource = ingred;
                //MessageBox.Show($"{ingredientForRecipe.IngredientId}");

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

    }
}
