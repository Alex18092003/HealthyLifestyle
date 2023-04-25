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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Users us;

        public MainPage(Users us)
        {
            InitializeComponent();

            this.us = us;
            Classes.FrameClassTwo.frame = FrameMain;
            Classes.FrameClassTwo.frame.Navigate(new Pages.HomePageWithCalories(us));

            
        }

        private void ButtonRecipes_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClassTwo.frame.Navigate(new Pages.RecipesPage(us));
        }

        private void ButtonDiary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFavourites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCounter_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClassTwo.frame.Navigate(new Pages.HomePageWithCalories(us));
        }

        private void BButtonPersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClassTwo.frame.Navigate(new Pages.PersonalAccountPage(us));
        }

        private void ButtonExe_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.HomeAutorizationPage());
        }
    }
}
