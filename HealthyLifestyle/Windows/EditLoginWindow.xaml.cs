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
                MessageBox.Show("Старый пароль введён не верно!");
            }
            else
            {
                if (pbNewPassword.Password.ToString() != "")
                {
                    //Regex regexCapitalLatinCharacter = new Regex("(?=.*[A-Z])"); // Регулярное выражение для проверки наличия 1 заглавного латинского символа
                    //if (regexCapitalLatinCharacter.IsMatch(pbNewPassword.Password.ToString()) == false)
                    //{
                    //    MessageBox.Show("Новый пароль должен содержать не менее 1 заглавного латинского символа");
                    //    return;
                    //}
                    //Regex regexAtLeastCharacters = new Regex("(?=.*[a-z].*[a-z].*[a-z])"); // Регулярное выражение для проверки наличия 3 строчных латинских символов
                    //if (regexAtLeastCharacters.IsMatch(pbNewPassword.Password.ToString()) == false)
                    //{
                    //    MessageBox.Show("Новый пароль должен содержать не менее 3 строчных латинских символов");
                    //    return;
                    //}
                    //Regex regexAtLeastDigits = new Regex("(?=.*[0-9].*[0-9])"); // Регулярное выражение для проверки наличия 2 цифр
                    //if (regexAtLeastDigits.IsMatch(pbNewPassword.Password.ToString()) == false)
                    //{
                    //    MessageBox.Show("Новый пароль должен содержать не менее 2 цифр");
                    //    return;
                    //}
                    //Regex regexSpecialСharacter = new Regex("(?=.*[!@#$&*])"); // Регулярное выражение для проверки наличия 1 спец. символа
                    //if (regexSpecialСharacter.IsMatch(pbNewPassword.Password.ToString()) == false)
                    //{
                    //    MessageBox.Show("Новый пароль должен содержать не менее 1 спец. символа");
                    //    return;
                    //}
                    //Regex regexLength = new Regex(".{8,}"); // Регулярное выражение для проверки длины пароля
                    //if (regexSpecialСharacter.IsMatch(pbNewPassword.Password.ToString()) == false)
                    //{
                    //    MessageBox.Show("Общая длина нового пароля должна быть не менее 8 символов");
                    //    return;
                    //}
                    if (pbNewPassword.Password.ToString() != pbNewPasswordRepeated.Password.ToString())
                    {
                        MessageBox.Show("Пароль не подтверждён!");
                        return;
                    }
                    us.Password = pbNewPassword.Password;
                }
                us.Login = tbLogin.Text;
                DB.entities.SaveChanges();
                this.Close();
                MessageBox.Show("Данные успешно обнавлены");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
