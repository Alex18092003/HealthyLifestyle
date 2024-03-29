﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthyLifestyle.Pages
{
    /// <summary>
    /// Логика взаимодействия для ActivitiesPage.xaml
    /// </summary>
    public partial class ActivitiesPage : Page
    {
        public int idActivities;
        public string login, password;

        public ActivitiesPage(string login, string password)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
            this.ListActivities.ItemsSource = DB.entities.Activities.ToList();
           
        }

        private void ButtonFurther_Click(object sender, RoutedEventArgs e)
        {
            if(icon1.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked ||
                icon2.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked ||
                icon3.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked ||
               icon4.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked ||
                icon5.Kind == MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked)
            {

                FrameClass.frame.Navigate(new Pages.UserDataPage(login, password , idActivities));
            }
            else
            {
                TextBlockHint.Text = "Выберите образ жизни";
               
            }
           
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Pages.NewUserPage());
        }

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            idActivities = 1;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon4.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon5.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            idActivities = 2;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon4.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon5.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            idActivities = 3;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;
            icon4.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon5.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            idActivities = 4;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon4.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;
            icon5.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            idActivities = 5;
            icon1.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon2.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon3.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon4.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxBlank;
            icon5.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RadioboxMarked;
        }




    }
}
