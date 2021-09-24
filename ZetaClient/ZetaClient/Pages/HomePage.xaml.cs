﻿using System.Windows;
using System.Windows.Controls;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            // todo: check user department

            InitializeComponent();
        }

        private void Models_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ModelsPage());
        }

        private void Ingredients_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngredientsPage());
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProcessPage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
