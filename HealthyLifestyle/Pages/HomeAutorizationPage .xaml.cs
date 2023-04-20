using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для HomeAutorizationPage.xaml
    /// </summary>
    public partial class HomeAutorizationPage : Page
    {
        public HomeAutorizationPage()
        {
            InitializeComponent();
        }

        private void ButtonNewUser_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.NewUserPage());
        }

        private void ButtonUser_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.AutorizationPage());
        }
    }
}
