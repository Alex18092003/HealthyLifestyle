using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthyLifestyle.Windows
{
    /// <summary>
    /// Логика взаимодействия для ErorYesNo.xaml
    /// </summary>
    public partial class ErorYesNo : Window
    {
        Users us;
        int index;
        public ErorYesNo(Users us, string str, int index)
        {
            InitializeComponent();
            this.us = us;
            TextEror.Text = str;
            this.index = index;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
          
            Classes.FrameClassTwo.frame.Navigate(new Pages.DiaryPage(us, index));
            Close();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
