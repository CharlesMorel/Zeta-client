using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZetaClient.Entities;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour IngredientsPage.xaml
    /// </summary>
    public partial class IngredientsPage : Page
    {
        public IngredientsPage()
        {
            InitializeComponent();
        }

        private void IngredientsPage_Loaded(object sender, EventArgs e)
        {
            IngDataGrid.ItemsSource = LoadIngredientCollection();
        }

        List<Ingredient> LoadIngredientCollection()
        {
            return new List<Ingredient>()
            {
                new Ingredient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Plomb",
                    Description = "Ceci est du plomb."
                },
                new Ingredient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ciment",
                    Description = "Ceci est du ciment."
                },
                new Ingredient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Plastique",
                    Description = "Ceci est du Plastique."
                }
            };
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = ((FrameworkElement)sender).DataContext as Ingredient;

            // todo : send http delete request
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = ((FrameworkElement)sender).DataContext as Ingredient;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // todo get form informations, check inputs, and add object in database
        }
    }
}
