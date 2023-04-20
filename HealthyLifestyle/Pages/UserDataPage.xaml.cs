using System.Windows;
using System.Windows.Controls;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserDataPage.xaml
    /// </summary>
    public partial class UserDataPage : Page
    {
        public int idActivities, idGenders;
        public string login, password, age, height, weight;

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.ActivitiesPage(login, password));
        }

        public UserDataPage(string login, string password, int idActivities)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
            this.idActivities = idActivities;
        }

        private void ButtonFurther_Click(object sender, RoutedEventArgs e)
        {
            if (CheckGenderMen.IsChecked == false && CheckGenderWomen.IsChecked == false)
            {
                TextBlockHintGender.Text = "Выберите свой пол";
            }
            else
            {
                TextBlockHintGender.Text = "";
            }

            if (TextBoxAge.Text == "")
            {
                TextBlockHintAge.Text = "Укажите свой возраст";
            }
            else
            {
                TextBlockHintAge.Text = "";
            }

            if (TextBoxHeight.Text == "")
            {
                TextBlockHintHeight.Text = "Укажите свой вес";
            }
            else
            {
                TextBlockHintHeight.Text = "";
            }

            if (TextBoxWeight.Text == "")
            {
                TextBlockHintWeight.Text = "Укажите свой рост";
            }
            else
            {
                TextBlockHintWeight.Text = "";
            }

            if ((CheckGenderMen.IsChecked != false || CheckGenderWomen.IsChecked != false) && TextBoxAge.Text != "" &&
    TextBoxHeight.Text != "" && TextBoxWeight.Text != "")
            {
                age = TextBoxAge.Text;
                height = TextBoxHeight.Text;
                weight = TextBoxWeight.Text;
                FrameClass.frame.Navigate(new Pages.UsersGoalPage(login, password, idActivities, idGenders, age, height, weight));
            }
        }

        private void CheckGenderMen_Checked(object sender, RoutedEventArgs e)
        {
            idGenders = 1;
            CheckGenderWomen.IsChecked = false;
        }

        private void CheckGenderWomen_Checked(object sender, RoutedEventArgs e)
        {
            idGenders = 2;
            CheckGenderMen.IsChecked = false;
        }
    }
}
