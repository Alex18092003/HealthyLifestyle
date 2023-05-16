using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePageWithCalories.xaml
    /// </summary>
    public partial class HomePageWithCalories : Page
    {
        Users us;
        public HomePageWithCalories(Users us)
        {
            InitializeComponent();

            this.us = us;
            TextBlockCalories.Text = Convert.ToString(us.CaloriesUsers);
            us.GenderId = us.GenderId;
            us.Login = us.Login;
            us.Weight = us.Weight;
            us.Height = us.Height;
            us.ActivityId = us.ActivityId;
            us.GoalId = us.GoalId;
            us.Squirrels = us.Squirrels;
            us.DateOfBirth = us.DateOfBirth;
            us.Password = us.Password;
            us.Fats = us.Fats;
            us.Carbohydrates = us.Carbohydrates;
            us.Calories = us.Calories;
            s();

            CaloriesDay.Text = Convert.ToString(us.CaloriesInDay);
            brush();

        }

        private void brush()
        {
            if (Convert.ToDouble(CaloriesDay.Text) > Convert.ToDouble(TextBlockCalories.Text))
            {
                CaloriesDay.Foreground = Brushes.Red;
                HintText.Visibility = Visibility.Visible;
                HintText.Text = "Предупреждение\nВы превысили дневную норму калорий";
                HintText.Foreground = Brushes.Red;
            }
            else
            {
                SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFromString("#274025");
                CaloriesDay.Foreground = color;
            }
        }

        private void s()
        {
            us.Calories = us.CaloriesUsers;
            DB.entities.SaveChanges();

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Today;
            List<DailyRation> dailyRation = DB.entities.DailyRation.Where(x => x.Date == dateTime && x.UserId == us.UserId).ToList();
            List<DailyRation> d = dailyRation.Where(x => x.MealId == 1).ToList();
            double p = 0;
            foreach (DailyRation dailyRation1 in dailyRation)
            {
                foreach (DailyRation daily in d)
                {
                    p = +(double)daily.Calories;

                }

            }
            if (dailyRation != null)
            {
                int pp2 = Convert.ToInt32(100 * p);
                if (pp2 != 0)
                { 
                int pp = Convert.ToInt32(100 * p / us.CaloriesInDay);
                Zavtrac.Text = " " + pp + "%";
                }
                else
                {
                    Zavtrac.Text = " " + "0" + "%";
                }
            }


            List<DailyRation> d2 = dailyRation.Where(x => x.MealId == 2).ToList();
            double o = 0;
            foreach (DailyRation dailyRation1 in dailyRation)
            {
                foreach (DailyRation daily in d2)
                {
                    o = +(double)daily.Calories;
                }

            }
            if (dailyRation != null)
            {
                int pp2 = Convert.ToInt32(100 * o);
                if (pp2 != 0)
                {
                    int oo = Convert.ToInt32(100 * o / us.CaloriesInDay);
                    Obed.Text = " " + oo + "%";
                }
                else
                {
                    Obed.Text = " " +"0" + "%";
                }
            }

            List<DailyRation> d4 = dailyRation.Where(x => x.MealId == 4).ToList();
            double y = 0;
            foreach (DailyRation dailyRation1 in dailyRation)
            {
                foreach (DailyRation daily in d4)
                {
                    y = +(double)daily.Calories;
                }

            }
            if (dailyRation != null)
            {
                int pp2 = Convert.ToInt32(100 * y);
                if (pp2 != 0)
                {
                    int yy = Convert.ToInt32(100 * y / us.CaloriesInDay);
                    Yzhin.Text = " " + yy + "%";
                }
                else
                {
                    Yzhin.Text = " " + "0" + "%";
                }
            }

            List<DailyRation> d3 = dailyRation.Where(x => x.MealId == 3).ToList();
            double t = 0;
            foreach (DailyRation dailyRation1 in dailyRation)
            {
                foreach (DailyRation daily in d3)
                {
                    t = +(double)daily.Calories;
                }

            }
            if (dailyRation != null)
            {
                int pp2 = Convert.ToInt32(100 * t);
                if (pp2 != 0)
                {
                    int tt = Convert.ToInt32(100 * t / us.CaloriesInDay);
                    Perecys.Text = " " + tt + "%";
                }
                else
                {
                    Perecys.Text = " " + "0" + "%";
                }
            }



            ButtonFAQ1.Style = FindResource("menuButton") as Style;
            ButtonFAQ2.Style = FindResource("menuButton") as Style;
            ButtonFAQ3.Style = FindResource("menuButton") as Style;
            ButtonFAQ4.Style = FindResource("menuButton") as Style;
            ButtonFAQ5.Style = FindResource("menuButton") as Style;
        }

        private void ButtonFAQ1_Click(object sender, RoutedEventArgs e)
        {

            if (TextFAQ1.Visibility != Visibility.Visible)
            {
                ButtonFAQ1.Style = FindResource("menuButtonActiv") as Style;
                TextFAQ1.Visibility = Visibility.Visible;
                TextFAQ1.Text = "Калории подсчитываются по популярной формуле Миффлину - Сан Жеору. Она позволяет рассчитать количество калорий, которые затрачивает организм на базовый обмен веществ.\nЖенская формула: 10 х вес + 6,25 х рост - 5 х возраст - 161;\n" +
                    "Мужская формула: 10 х вес + 6,25 х рост - 5 х возраст + 5; \n" +
                    "С помощью данной формулы определяется лишь базовый уровень калорий.";
            }
            else
            {
                ButtonFAQ1.Style = FindResource("menuButton") as Style;
                TextFAQ1.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonFAQ2_Click(object sender, RoutedEventArgs e)
        {

            if (TextFAQ2.Visibility != Visibility.Visible)
            {
                ButtonFAQ2.Style = FindResource("menuButtonActiv") as Style;
                TextFAQ2.Visibility = Visibility.Visible;
                TextFAQ2.Text = "Калория - это единица энергии, которцю получает организм при расщеплении белков, жиров и углеводов." +
                    " Для обозначения ценности продукта чаще всегда используют килокалории (ккал) в расчете на 100г." +
                    " Ещё на этикетках продуктов, - килоджоули (кДж). Это эквивалент килокалориям " +
                    "в Международной системе единиц, и 4,2 кДж примерно соответствует 1 ккал.";
            }
            else
            {
                ButtonFAQ2.Style = FindResource("menuButton") as Style;
                TextFAQ2.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonFAQ3_Click(object sender, RoutedEventArgs e)
        {
            if (TextFAQ3.Visibility != Visibility.Visible)
            {
                ButtonFAQ3.Style = FindResource("menuButtonActiv") as Style;
                TextFAQ3.Visibility = Visibility.Visible;
                TextFAQ3.Text = "Потребности организма зависят от физической нагрузки человека:\n" +
                    "Сидячий образ жизни без нагрузок - Подсчитанные калории умножить на 1,2;\n" +
                    "Тренировки 1-3 раза в неделю - Подсчитанные калории умножить на 1,375;\n" +
                    "Занятия 3-5 дней в неделю - Подсчитанные калории умножить на 1,55;\n" +
                    "Интенсивные тренировки 6-7 раз в неделю - Подсчитанные калории умножить на 1,725;\n" +
                    "Интенсивные тренировки 6-7 раз в неделю - Подсчитанные калории умножить на 1,725;\n" +
                    "Спортсмены, выполняющие упражнения чаще, чем раз в неделю - Подсчитанные калории умножить на 1,9;\n";
            }
            else
            {
                ButtonFAQ3.Style = FindResource("menuButton") as Style;
                TextFAQ3.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonFAQ4_Click(object sender, RoutedEventArgs e)
        {
            if (TextFAQ4.Visibility != Visibility.Visible)
            {
                ButtonFAQ4.Style = FindResource("menuButtonActiv") as Style;
                TextFAQ4.Visibility = Visibility.Visible;
                TextFAQ4.Text = "В основе ЗОЖ лежат следующие несложные рекомендации:\n" +
                    "правильное питание с преобладанием овощей, фруктов, зелени, нежирного мяса и рыбы, приготовленных на пару;\n" +
                    "употребление оптимального количества чистой воды;\n" +
                    "умеренный уровень физической активности;\n" +
                    "регулярные прогулки на свежем воздухе;\n" +
                    "отказ от вредных привычек;\n" +
                    "борьба со стрессами и интенсивными психоэмоциональными нагрузками.";
            }
            else
            {
                ButtonFAQ4.Style = FindResource("menuButton") as Style;
                TextFAQ4.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonFAQ5_Click(object sender, RoutedEventArgs e)
        {
            if (TextFAQ5.Visibility != Visibility.Visible)
            {
                ButtonFAQ5.Style = FindResource("menuButtonActiv") as Style;
                TextFAQ5.Visibility = Visibility.Visible;
                TextFAQ5.Text = "Соблюдение принципов здорового образа жизни благотворно сказывается на всех органах и системах организма:\n" +
                    "нормализуется артериальное давление и частота сердечных сокращений;\n" +
                    "приходит в норму моторная и секреторная функции пищеварительной системы;\n" +
                    "улучшается фильтрационная способность печени и почек;\n" +
                    "нормализуется состав крови, включая уровень холестерина;\n" +
                    "уменьшается объем жировых отложений;\n" +
                    "повышается жизненный тонус и достигается ровный эмоциональный фон.";
            }
            else
            {
                ButtonFAQ5.Style = FindResource("menuButton") as Style;
                TextFAQ5.Visibility = Visibility.Collapsed;
            }
        }
    }
}
