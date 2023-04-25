using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для DiaryPage.xaml
    /// </summary>
    public partial class DiaryPage : Page
    {
        Users users;
        public DiaryPage(Users users)
        {
            InitializeComponent();
            this.users = users;

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Today;
            List<DailyRation> dailyRation = DB.entities.DailyRation.Where(x => x.Date == dateTime && x.UserId == users.UserId).ToList();

            ListDiaryBreakfast.ItemsSource = dailyRation.Where(x => x.MealId == 1).ToList();
            ListDiaryLunch.ItemsSource = dailyRation.Where(x => x.MealId == 2).ToList();
            ListDiaryDinner.ItemsSource = dailyRation.Where(x => x.MealId == 4).ToList();
            ListDiarySnack.ItemsSource = dailyRation.Where(x => x.MealId == 3).ToList();
        }

        private void ButtonBDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (MessageBox.Show("Подтвердите удаление", "Сообщение", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        {
                            Button btn = (Button)sender;
                            int index = Convert.ToInt32(btn.Uid);
                            DailyRation daily = DB.entities.DailyRation.FirstOrDefault(x => x.DailyRationId == index);
                            DB.entities.DailyRation.Remove(daily);
                            DB.entities.SaveChanges();
                            Classes.FrameClassTwo.frame.Navigate(new Pages.DiaryPage(users));
                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("При удаление товара возникла ошибка");
            }
        }
    }
}
