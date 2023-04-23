using System;
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
            TextBoxCal.Text = Convert.ToString(us.Calories);
        }

        private void ButtonEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBoxWeidth.IsEnabled = true;
            TextBoxHeight.IsEnabled = true;
            TextBoxAge.IsEnabled = true;
            TextBoxCal.IsEnabled = true;
            ButtonEdit.Content = "Сохранить изменения";
        }

        private void ButtonEditLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditLoginWindow editLoginWindow = new EditLoginWindow(us);
            editLoginWindow.ShowDialog();
            FrameClass.frame.Navigate(new Pages.PersonalAccountPage(us));
            
        }
    }
}
