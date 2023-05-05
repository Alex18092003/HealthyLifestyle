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
        int ii = 0;

        public MainPage(Users us)
        {
            InitializeComponent();

            this.us = us;
            Classes.FrameClassTwo.frame = FrameMain;
            Classes.FrameClassTwo.frame.Navigate(new Pages.HomePageWithCalories(us));


            ButtonCounter.Style = FindResource("menuButtonActiv") as Style;
            ButtonRecipes.Style = FindResource("menuButton") as Style;
            ButtonDiary.Style = FindResource("menuButton") as Style;
            BButtonPersonalAccount.Style = FindResource("menuButton") as Style;
        }

        private void ButtonRecipes_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClassTwo.frame.Navigate(new Pages.RecipesPage(us));

            ButtonCounter.Style = FindResource("menuButton") as Style;
            ButtonRecipes.Style = FindResource("menuButtonActiv") as Style;
            ButtonDiary.Style = FindResource("menuButton") as Style;
            BButtonPersonalAccount.Style = FindResource("menuButton") as Style;

        }

        private void ButtonDiary_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClassTwo.frame.Navigate(new Pages.DiaryPage(us));
            ButtonCounter.Style = FindResource("menuButton") as Style;
            ButtonRecipes.Style = FindResource("menuButton") as Style;
            ButtonDiary.Style = FindResource("menuButtonActiv") as Style;
            BButtonPersonalAccount.Style = FindResource("menuButton") as Style;

        }


        private void ButtonCounter_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClassTwo.frame.Navigate(new Pages.HomePageWithCalories(us));
            ButtonCounter.Style = FindResource("menuButtonActiv") as Style;
            ButtonRecipes.Style = FindResource("menuButton") as Style;
            ButtonDiary.Style = FindResource("menuButton") as Style;
            BButtonPersonalAccount.Style = FindResource("menuButton") as Style;

        }

        private void BButtonPersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClassTwo.frame.Navigate(new Pages.PersonalAccountPage(us));
            ButtonCounter.Style = FindResource("menuButton") as Style;
            ButtonRecipes.Style = FindResource("menuButton") as Style;
            ButtonDiary.Style = FindResource("menuButton") as Style;
            BButtonPersonalAccount.Style = FindResource("menuButtonActiv") as Style;

        }

        private void ButtonExe_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.HomeAutorizationPage());

        }
    }
}
