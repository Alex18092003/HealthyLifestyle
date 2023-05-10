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
    /// Логика взаимодействия для Eror.xaml
    /// </summary>
    public partial class Eror : Window
    {
        Users us;
        public Eror(Users us, string str)
        {
            InitializeComponent();
            this.us = us;
            TextEror.Text = str;
        }
 
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonFurther_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
