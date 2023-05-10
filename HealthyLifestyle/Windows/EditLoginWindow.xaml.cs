using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HealthyLifestyle
{
    /// <summary>
    /// Логика взаимодействия для EditLoginWindow.xaml
    /// </summary>
    public partial class EditLoginWindow : Window
    {
        Users us;
        public EditLoginWindow(Users us)
        {
            InitializeComponent();
            this.us = us;
            Conclusion();
        }

        private void Conclusion()
        {
            tbLogin.Text = us.Login;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string p = pbOldPassword.Password;
            Users users  = DB.entities.Users.FirstOrDefault(x => x.Login == us.Login && x.Password == p);
            if (users == null)
            {
                TextBoxHint.Text = "Старый пароль введён не верно!";
            }
            else
            {
                if (pbNewPassword.Password.ToString() != "")
                {
                    if (pbNewPassword.Password.ToString() != pbNewPasswordRepeated3.Password.ToString())
                    {
                        TextBoxHint.Text = "Пароль не подтверждён!";
                        return;
                    }
                    us.Password = pbNewPassword.Password;
                }
                us.Login = tbLogin.Text;
                DB.entities.SaveChanges();
                this.Close();
                MessageBox.Show("Данные успешно обновлены");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void imVisiblePassword_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void imVisiblePassword_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HidePassword();
        }
        private void ShowPassword()
        {
            imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible1.png", UriKind.Relative));
            pbPasswordVisible.Visibility = Visibility.Visible;
            pbOldPassword.Visibility = Visibility.Collapsed;
            pbPasswordVisible.Text = pbOldPassword.Password;
        }

        private void HidePassword()
        {
            imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible1.png", UriKind.Relative));
            pbPasswordVisible.Visibility = Visibility.Collapsed;
            pbOldPassword.Visibility = Visibility.Visible;
            pbOldPassword.Focus();
        }

        private void imVisiblePassword2_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShowPassword2();
        }

        private void imVisiblePassword2_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HidePassword2();
        }

        private void ShowPassword2()
        {
            imVisiblePassword2.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible1.png", UriKind.Relative));
            pbPasswordVisible2.Visibility = Visibility.Visible;
            pbNewPassword.Visibility = Visibility.Collapsed;
            pbPasswordVisible2.Text = pbNewPassword.Password;

            //if (pbPasswordVisible.Visibility == Visibility.Visible)
            //{
            //    imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible1.png", UriKind.Relative));
            //    pbPasswordVisible.Visibility = Visibility.Collapsed;
            //    pbNewPassword.Visibility = Visibility.Visible;
            //    pbNewPassword.Focus();
            //}
            //else
            //{
            //    imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible1.png", UriKind.Relative));
            //    pbPasswordVisible.Visibility = Visibility.Visible;
            //    pbNewPassword.Visibility = Visibility.Collapsed;
            //    pbPasswordVisible.Text = pbNewPassword.Password;
            //}
        }

        private void HidePassword2()
        {
            imVisiblePassword2.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible1.png", UriKind.Relative));
            pbPasswordVisible2.Visibility = Visibility.Collapsed;
            pbNewPassword.Visibility = Visibility.Visible;
            pbNewPassword.Focus();
        }

        private void imVisiblePassword3_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShowPassword3();
        }

        private void imVisiblePassword3_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HidePassword3();
        }
        private void ShowPassword3()
        {
            imVisiblePassword3.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible1.png", UriKind.Relative));
            pbPasswordVisible3.Visibility = Visibility.Visible;
            pbNewPasswordRepeated3.Visibility = Visibility.Collapsed;
            pbPasswordVisible3.Text = pbNewPasswordRepeated3.Password;

            //if (pbPasswordVisible.Visibility == Visibility.Visible)
            //{
            //    imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible1.png", UriKind.Relative));
            //    pbPasswordVisible.Visibility = Visibility.Collapsed;
            //    pbNewPasswordRepeated3.Visibility = Visibility.Visible;
            //    pbNewPasswordRepeated3.Focus();
            //}
            //else
            //{
            //    imVisiblePassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible1.png", UriKind.Relative));
            //    pbPasswordVisible.Visibility = Visibility.Visible;
            //    pbNewPasswordRepeated3.Visibility = Visibility.Collapsed;
            //    pbPasswordVisible.Text = pbNewPasswordRepeated3.Password;
            //}
        }

        private void HidePassword3()
        {
            imVisiblePassword3.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible1.png", UriKind.Relative));
            pbPasswordVisible3.Visibility = Visibility.Collapsed;
            pbNewPasswordRepeated3.Visibility = Visibility.Visible;
            pbNewPasswordRepeated3.Focus();
        }
    }
}
