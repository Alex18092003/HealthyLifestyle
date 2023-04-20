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
    /// Логика взаимодействия для ActivitiesPage.xaml
    /// </summary>
    public partial class ActivitiesPage : Page
    {
        HttpClient client = new HttpClient();
        ActivitiesCollection _activities = new ActivitiesCollection();

        public int idActivities;
        public string login, password;

        public ActivitiesPage(string login, string password)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;

            client.BaseAddress = new Uri("https://iis.ngknn.ru/ngknn/лебедевааф/");
            client.DefaultRequestHeaders.Accept.Add(
                           new MediaTypeWithQualityHeaderValue("application/json"));


            this.ListActivities.ItemsSource = _activities;
            ListOutput();

        }


        /// <summary>
        /// метод для загрузки листа
        /// </summary>
        private async void ListOutput()
        {
            try
            {

                var response = await client.GetAsync("api/Activities");
                response.EnsureSuccessStatusCode(); // Throw on error code.

                var activities = await response.Content.ReadAsAsync<IEnumerable<Activities>>();
                _activities.CopyFrom(activities);
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

        private void ButtonFurther_Click(object sender, RoutedEventArgs e)
        {
            if(CheckActivities1.IsChecked == true || CheckActivities2.IsChecked == true ||
                CheckActivities3.IsChecked == true || CheckActivities4.IsChecked == true ||
                CheckActivities5.IsChecked == true)
            {

                FrameClass.frame.Navigate(new Pages.UserDataPage(login, password , idActivities));
            }
            else
            {
                TextBlockHint.Text = "Выберите образ жизни";
               
            }
           
        }

        private void CheckActivities1_Checked(object sender, RoutedEventArgs e)
        {
            idActivities = 1;
            CheckActivities2.IsChecked = false;
            CheckActivities3.IsChecked = false;
            CheckActivities4.IsChecked = false;
            CheckActivities5.IsChecked = false;
        }

        private void CheckActivities2_Checked(object sender, RoutedEventArgs e)
        {
            idActivities = 2;
            CheckActivities1.IsChecked = false;
            CheckActivities3.IsChecked = false;
            CheckActivities4.IsChecked = false;
            CheckActivities5.IsChecked = false;
        }

        private void CheckActivities3_Checked(object sender, RoutedEventArgs e)
        {
            idActivities = 3;
            CheckActivities1.IsChecked = false;
            CheckActivities2.IsChecked = false;
            CheckActivities4.IsChecked = false;
            CheckActivities5.IsChecked = false;
        }

        private void CheckActivities4_Checked(object sender, RoutedEventArgs e)
        {
            idActivities = 4;
            CheckActivities1.IsChecked = false;
            CheckActivities2.IsChecked = false;
            CheckActivities3.IsChecked = false;
            CheckActivities5.IsChecked = false;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.NewUserPage());
        }

        private void CheckActivities5_Checked(object sender, RoutedEventArgs e)
        {
            idActivities = 5;
            CheckActivities2.IsChecked = false;
            CheckActivities1.IsChecked = false;
            CheckActivities3.IsChecked = false;
            CheckActivities4.IsChecked = false;
        }
    }
}
