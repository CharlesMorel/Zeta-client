using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZetaClient.Entities;
using ZetaClient.Entities.Enums;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour ModelsPage.xaml
    /// </summary>
    public partial class ModelsPage : Page
    {
        public ModelsPage()
        {
            InitializeComponent();
        }

        private void ModelPage_Loaded(object sender, EventArgs e)
        {
            ModelDataGrid.ItemsSource = LoadFrisbeeModelCollection();
            IngredientsListBox.ItemsSource = LoadIngredientCollection();
        }

        private List<FrisbeeModel> LoadFrisbeeModelCollection()
        {
            return new List<FrisbeeModel>()
            {
                new FrisbeeModel()
                {
                    Name = "Large",
                    Description = "Ceci est un frisbee de grande taille",
                    pUHT = "Coucou",
                    Range = RangeType.Luxe 
                },
                new FrisbeeModel()
                {
                    Name = "Medium",
                    Description = "Ceci est un frisbee de moyenne taille",
                    pUHT = "test",
                    Range = RangeType.Luxe 
                },
                new FrisbeeModel()
                {
                    Name = "Small",
                    Description = "Ceci est un frisbee de petite taille",
                    pUHT = "test2",
                    Range = RangeType.Standard 
                },
                new FrisbeeModel()
                {
                    Name = "Extra Large",
                    Description = "Ceci est un frisbee de très grande taille",
                    pUHT = "test3",
                    Range = RangeType.Standard 
                },
            };
        }

        List<Ingredient> LoadIngredientCollection()
        {
            return new List<Ingredient>()
            {
                new Ingredient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Plomb",
                    Description = "Ceci est du plomb.",
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
            //Ingredient ingredient = ((FrameworkElement)sender).DataContext as Ingredient;

            // todo : send http delete request
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            //Ingredient ingredient = ((FrameworkElement)sender).DataContext as Ingredient;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // todo get form informations, check inputs, and add object in database
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SeeIngredients_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
