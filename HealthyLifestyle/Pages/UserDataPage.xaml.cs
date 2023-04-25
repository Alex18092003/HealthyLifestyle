using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserDataPage.xaml
    /// </summary>
    public partial class UserDataPage : Page
    {
        public int idActivities, idGenders;
        public string login, password, age, height, weight;

        // запрет ввода символов
        private void TextBoxAge_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                { e.Handled = true; }
            }
            catch
            {
                
            }
        }

        // запрет ввода символов
        private void TextBoxWeight_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.Text, 0) | (e.Text == Convert.ToString(",")) | e.Text == Convert.ToString('\b')) return;
                else
                    e.Handled = true;

            }
            catch
            {
                
            }
        }

        // запрет ввода символов
        private void TextBoxHeight_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.Text, 0) | (e.Text == Convert.ToString(",")) | e.Text == Convert.ToString('\b')) return;
                else
                    e.Handled = true;

            }
            catch
            {
                
            }
}

        private void TextBoxWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxWeight.Text))
            {
                if (Convert.ToDouble(TextBoxWeight.Text) < 50 || Convert.ToDouble(TextBoxWeight.Text) > 265)
                {
                    TextBlockHintWeight.Text = "Рост введен некорректно ";
                  
                }
                else
                {
                    TextBlockHintWeight.Text = "";
                }
            }
            
        }

        private void TextBoxHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxHeight.Text))
            {
                if (Convert.ToDouble(TextBoxHeight.Text) < 30 ||Convert.ToDouble(TextBoxHeight.Text) > 500)
                {
                    TextBlockHintHeight.Text = "Вес введен некорректно ";
                }
                else
                {
                    TextBlockHintHeight.Text = "";
                    
                }
            }
        }

        private void TextBoxAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBoxAge.Text))
            {
                if (Convert.ToInt32(TextBoxAge.Text) < 14 || Convert.ToInt32(TextBoxAge.Text) > 80)
                {
                    TextBlockHintAge.Text = "Возвраст введен некорректно ";
                }
                else
                {
                    TextBlockHintAge.Text = "";

                }
            }
        }

        private void TextBoxAge_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBoxWeight.Focus();
            }
        }

        private void TextBoxWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBoxHeight.Focus();
            }
        }

        private void TextBoxHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Proverka();
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.ActivitiesPage(login, password));
        }

        public UserDataPage(string login, string password, int idActivities)
        {
            InitializeComponent();
            TextBoxHeight.TextChanged += TextBoxHeight_TextChanged;
            TextBoxWeight.TextChanged += TextBoxWeight_TextChanged;
            TextBoxAge.TextChanged += TextBoxAge_TextChanged;
            this.login = login;
            this.password = password;
            this.idActivities = idActivities;
        }
        private void Proverka()
        {

            if (CheckGenderMen.IsChecked == false && CheckGenderWomen.IsChecked == false)
            {
                TextBlockHintGender.Text = "Выберите свой пол";
            }
            else
            {
                TextBlockHintGender.Text = "";
            }

            if (TextBoxAge.Text == "" || Convert.ToInt32(TextBoxAge.Text) < 14 || Convert.ToInt32(TextBoxAge.Text) > 80)
            {
                TextBlockHintAge.Text = "Укажите свой возраст";
            }
            else
            {
                TextBlockHintAge.Text = "";
            }

            if (TextBoxHeight.Text == "" || Convert.ToDouble(TextBoxHeight.Text) < 30 || Convert.ToDouble(TextBoxHeight.Text) > 500)
            {
                TextBlockHintHeight.Text = "Укажите свой вес";
            }
            else
            {
                TextBlockHintHeight.Text = "";
            }

            if (TextBoxWeight.Text == "" || Convert.ToDouble(TextBoxWeight.Text) < 50 || Convert.ToDouble(TextBoxWeight.Text) > 265)
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

        private void ButtonFurther_Click(object sender, RoutedEventArgs e)
        {
            Proverka();
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
