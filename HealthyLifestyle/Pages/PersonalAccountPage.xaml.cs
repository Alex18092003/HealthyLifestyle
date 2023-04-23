using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountPage.xaml
    /// </summary>
    public partial class PersonalAccountPage : Page
    {
        Users us;
        public PersonalAccountPage(Users us)
        {
            InitializeComponent();
            this.us = us;
            Conclusion();
        }

        private void Conclusion()
        {
            TextBoxWeidth.Text = Convert.ToString( us.Weight);
            TextBoxHeight.Text = Convert.ToString(us.Height);
            TextBoxAge.Text = Convert.ToString(us.DateOfBirth);
            ComboBoxActivities.ItemsSource = DB.entities.Activities.ToList(); 
            ComboBoxActivities.SelectedValuePath = "ActivityId";
            ComboBoxActivities.DisplayMemberPath = "Title";
            ComboBoxActivities.SelectedValue = us.ActivityId;
            ComboBoxGoal.ItemsSource = DB.entities.Goals.ToList();
            ComboBoxGoal.SelectedValuePath = "GoalId";
            ComboBoxGoal.DisplayMemberPath = "Title";
            ComboBoxGoal.SelectedValue = us.GoalId;

        }

        private void ButtonEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBoxWeidth.IsEnabled = true;
            TextBoxHeight.IsEnabled = true;
            TextBoxAge.IsEnabled = true;
          
            ComboBoxActivities.IsEnabled = true;
            ComboBoxGoal.IsEnabled = true;
            ButtonEdit.Visibility = Visibility.Collapsed;
            ButtonAdd.Visibility = Visibility.Visible;
        }

        private void ButtonEditLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditLoginWindow editLoginWindow = new EditLoginWindow(us);
            editLoginWindow.ShowDialog();
            FrameClass.frame.Navigate(new Pages.PersonalAccountPage(us));
            
        }
        // запрет ввода символов
        private void TextBoxWeidth_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0)) e.Handled = true;

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
                if (!Char.IsDigit(e.Text, 0)) e.Handled = true;

            }
            catch
            {

            }
        }
        // запрет ввода символов
        private void TextBoxAge_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0)) e.Handled = true;

            }
            catch
            {

            }
        }
 

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxWeidth.Text != "" && TextBoxHeight.Text != "" && TextBoxAge.Text != "")
            {
                us.Weight = Convert.ToDouble(TextBoxWeidth.Text);
                us.Height = Convert.ToDouble(TextBoxHeight.Text);
                us.DateOfBirth = Convert.ToInt32(TextBoxAge.Text);
                us.ActivityId = (int)ComboBoxActivities.SelectedValue;
                us.GoalId = (int)ComboBoxGoal.SelectedValue;
                DB.entities.SaveChanges();
                MessageBox.Show("Данные успешно обновлены");

                TextBoxWeidth.IsEnabled = false;
                TextBoxHeight.IsEnabled = false;
                TextBoxAge.IsEnabled = false;
                ComboBoxActivities.IsEnabled = false;
                ComboBoxGoal.IsEnabled = false;
                ButtonEdit.Visibility = Visibility.Visible;
                ButtonAdd.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBoxHint.Text = "Заполните все поля";
            }
        }
    }
}
