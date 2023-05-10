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


            ButtonEat1.Style = FindResource("menuButtonActiv") as Style;
            ButtonEat2.Style = FindResource("menuButtonActiv") as Style;
            ButtonEat3.Style = FindResource("menuButtonActiv") as Style;
            ButtonEat4.Style = FindResource("menuButtonActiv") as Style;
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

        private void ButtonEat1_Click(object sender, RoutedEventArgs e)
        {
            if (ListDiaryBreakfast.Visibility != Visibility.Visible)
            {
                ButtonEat1.Style = FindResource("menuButtonActiv") as Style;
                ListDiaryBreakfast.Visibility = Visibility.Visible;
               
            }
            else
            {
                ButtonEat1.Style = FindResource("menuButton") as Style;
                ListDiaryBreakfast.Visibility = Visibility.Collapsed;
               
            }
        }

        private void ButtonEat2_Click(object sender, RoutedEventArgs e)
        {
            if (ListDiaryLunch.Visibility != Visibility.Visible)
            {
              
                ListDiaryLunch.Visibility = Visibility.Visible;
                ButtonEat2.Style = FindResource("menuButtonActiv") as Style;
            }
            else
            {
                ButtonEat2.Style = FindResource("menuButton") as Style;
                ListDiaryLunch.Visibility = Visibility.Collapsed;
               
            }
        }

        private void ButtonEat3_Click(object sender, RoutedEventArgs e)
        {
            if (ListDiaryDinner.Visibility != Visibility.Visible)
            {
                ButtonEat3.Style = FindResource("menuButtonActiv") as Style;
                ListDiaryDinner.Visibility = Visibility.Visible;

            }
            else
            {
                ButtonEat3.Style = FindResource("menuButton") as Style;
                ListDiaryDinner.Visibility = Visibility.Collapsed;
               
            }
        }

        private void ButtonEat4_Click(object sender, RoutedEventArgs e)
        {
            if (ListDiarySnack.Visibility != Visibility.Visible)
            {
                ButtonEat4.Style = FindResource("menuButtonActiv") as Style;
                ListDiarySnack.Visibility = Visibility.Visible;
                
            }
            else
            {
                ButtonEat4.Style = FindResource("menuButton") as Style;
                ListDiarySnack.Visibility = Visibility.Collapsed;
               
            }
        }
    }
}
