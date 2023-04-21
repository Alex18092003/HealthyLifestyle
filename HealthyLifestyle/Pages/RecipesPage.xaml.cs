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
        HttpClient client = new HttpClient();
        RecipesCollection _recipes = new RecipesCollection();
        MealsCollection _meals = new MealsCollection();
        RecipeTypesCollection _recipetype = new RecipeTypesCollection();
        SpecificsCollection _specifics = new SpecificsCollection();
        PreparationsCollection _preparations = new PreparationsCollection();
        KitchensCollection _kitchens = new KitchensCollection();
        DifficultiesCollection _difficulties = new DifficultiesCollection();
        DietsCollection _diets = new DietsCollection();


        public RecipesPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("https://iis.ngknn.ru/ngknn/лебедевааф/");
            client.DefaultRequestHeaders.Accept.Add(
                           new MediaTypeWithQualityHeaderValue("application/json"));

            ListOutput();
            ListRecipes.ItemsSource = _recipes;
            

            LoadingMeals();
            LoadingRecipeTypes();
            LoadingSpecifics();
            LoadingPreparations();
            LoadingKitchens();
            LoadingDifficulties();
            ComboBoxMinutesOfCooking.SelectedIndex = 0;
            LoadingDiets();

        }

        /// <summary>
        /// метод для загрузки диеты
        /// </summary>
        private async void LoadingDiets()
        {
            try
            {

                var response = await client.GetAsync("api/Diets");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var diets = await response.Content.ReadAsAsync<IEnumerable<Diets>>();
                _diets.CopyFrom(diets);
                ComboBoxDiets.Items.Add("Диеты");
                List<Diets> pr = _diets.ToList();
                for (int i = 0; i < pr.Count; i++)
                {
                    ComboBoxDiets.Items.Add(pr[i].Title);
                }
                ComboBoxDiets.SelectedIndex = 0;
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
        /// метод для загрузки сложности
        /// </summary>
        private async void LoadingDifficulties()
        {
            try
            {

                var response = await client.GetAsync("api/Difficulties");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var difficulties = await response.Content.ReadAsAsync<IEnumerable<Difficulties>>();
                _difficulties.CopyFrom(difficulties);
                ComboBoxDifficulties.Items.Add("Сложность");
                List<Difficulties> pr = _difficulties.ToList();
                for (int i = 0; i < pr.Count; i++)
                {
                    ComboBoxDifficulties.Items.Add(pr[i].Title);
                }
                ComboBoxDifficulties.SelectedIndex = 0;
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
        /// метод для загрузки кухни
        /// </summary>
        private async void LoadingKitchens()
        {
            try
            {

                var response = await client.GetAsync("api/Kitchens");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var kitchens = await response.Content.ReadAsAsync<IEnumerable<Kitchens>>();
                _kitchens.CopyFrom(kitchens);
                ComboBoxKitchens.Items.Add("Кухня");
                List<Kitchens> pr = _kitchens.ToList();
                for (int i = 0; i < pr.Count; i++)
                {
                    ComboBoxKitchens.Items.Add(pr[i].Title);
                }
                ComboBoxKitchens.SelectedIndex = 0;
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
        /// метод для загрузки приготовления
        /// </summary>
        private async void LoadingPreparations()
        {
            try
            {

                var response = await client.GetAsync("api/Preparations");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var preparations = await response.Content.ReadAsAsync<IEnumerable<Preparations>>();
                _preparations.CopyFrom(preparations);
                ComboBoxPreparations.Items.Add("Приготовление");
                List<Preparations> pr = _preparations.ToList();
                for (int i = 0; i < pr.Count; i++)
                {
                    ComboBoxPreparations.Items.Add(pr[i].Title);
                }
                ComboBoxPreparations.SelectedIndex = 0;
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
        /// метод для загрузки спицифики
        /// </summary>
        private async void LoadingSpecifics()
        {
            try
            {

                var response = await client.GetAsync("api/Specifics");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var specifics = await response.Content.ReadAsAsync<IEnumerable<Specifics>>();
                _specifics.CopyFrom(specifics);
                ComboBoxSpecifics.Items.Add("Специфика");
                List<Specifics> specific = _specifics.ToList();
                for (int i = 0; i < specific.Count; i++)
                {
                    ComboBoxSpecifics.Items.Add(specific[i].Title);
                }
                ComboBoxSpecifics.SelectedIndex = 0;
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
        /// метод для загрузки типов рецептов
        /// </summary>
        private async void LoadingRecipeTypes()
        {
            try
            {

                var response = await client.GetAsync("api/RecipeTypes");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var recipetype = await response.Content.ReadAsAsync<IEnumerable<RecipeTypes>>();
                _recipetype.CopyFrom(recipetype);
                ComboBoxRecipeTypes.Items.Add("Тип рецепта");
                List<RecipeTypes> recipeTypes = _recipetype.ToList();
                for (int i = 0; i < recipeTypes.Count; i++)
                {
                    ComboBoxRecipeTypes.Items.Add(recipeTypes[i].Title);
                }
                ComboBoxRecipeTypes.SelectedIndex = 0;
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
        /// метод для загрузки приемов пищи
        /// </summary>
        private async void LoadingMeals()
        {
            try
            {

                var response = await client.GetAsync("api/Meals");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var meals = await response.Content.ReadAsAsync<IEnumerable<Meals>>();
                _meals.CopyFrom(meals);

                ComboBoxMeals.Items.Add("Прием пищи");

                List<Meals> types = _meals.ToList();
                for (int i = 0; i < types.Count; i++)
                {
                    ComboBoxMeals.Items.Add(types[i].Title);
                }
                ComboBoxMeals.SelectedIndex = 0;
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
        /// метод для загрузки листа рецептов
        /// </summary>
        private async void ListOutput()
        {
            try
            {

                var response = await client.GetAsync("api/Recipes");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var recipes = await response.Content.ReadAsAsync<ObservableCollection<Recipes>>();
                _recipes.CopyFrom(recipes);
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
        /// Метод для фильтрации рецептов
        /// </summary>
        private void Filter()
        {
            List<Recipes> r = _recipes.ToList();
           

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
            Recipes recipes = _recipes.FirstOrDefault(x => x.RecipeId == id);
            Classes.FrameClassTwo.frame.Navigate(new Pages.StepsPage(recipes));
        }
    }
}
