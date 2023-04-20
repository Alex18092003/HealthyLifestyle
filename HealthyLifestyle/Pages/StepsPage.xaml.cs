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
        Recipes recipes1;
        //Steps stepss;

        public StepsPage(Recipes recipes)
        {
            InitializeComponent();

            this.recipes1 = recipes;
            client.BaseAddress = new Uri("https://iis.ngknn.ru/ngknn/лебедевааф/");
            client.DefaultRequestHeaders.Accept.Add(
                           new MediaTypeWithQualityHeaderValue("application/json"));

          
            ListOutput();
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
