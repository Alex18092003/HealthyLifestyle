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

        int s;
        public DiaryPage(Users users, int s)
        {
            InitializeComponent();
            this.users = users;

            this.s = s;
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Today;
            List<DailyRation> dailyRation = DB.entities.DailyRation.Where(x => x.Date == dateTime && x.UserId == users.UserId).ToList();

            ListDiaryBreakfast.ItemsSource = dailyRation.Where(x => x.MealId == 1).ToList();
            ListDiaryLunch.ItemsSource = dailyRation.Where(x => x.MealId == 2).ToList();
            ListDiaryDinner.ItemsSource = dailyRation.Where(x => x.MealId == 4).ToList();
            ListDiarySnack.ItemsSource = dailyRation.Where(x => x.MealId == 3).ToList();
            if(s != 0)
            {
                DailyRation daily = DB.entities.DailyRation.FirstOrDefault(x => x.DailyRationId == s);
                DB.entities.DailyRation.Remove(daily);
                DB.entities.SaveChanges();
               Classes.FrameClassTwo.frame.Navigate(new Pages.DiaryPage(users));
            }
        }

        private void ButtonBDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = "Подтвердите удаление";
                Button btn = (Button)sender;
                int index = Convert.ToInt32(btn.Uid);
                Windows.ErorYesNo eror = new Windows.ErorYesNo(users, str, index);
                eror.ShowDialog();
                if(s !=0)
                {
                    Classes.FrameClassTwo.frame.Navigate(new Pages.DiaryPage(users, index));
                }
                else
                {
                    Classes.FrameClassTwo.frame.Navigate(new Pages.DiaryPage(users));
                }

            }
            catch
            {
                MessageBox.Show("При удаление товара возникла ошибка");
            }
        }
    }
}
