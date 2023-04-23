using System.Linq;
using System.Windows;

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
                    if (pbNewPassword.Password.ToString() != pbNewPasswordRepeated.Password.ToString())
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
    }
}
