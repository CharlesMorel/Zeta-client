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
            // todo: check user department

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
            FrisbeeModel model = ((FrameworkElement)sender).DataContext as FrisbeeModel;
            ModifyNameInput.Text = model.Name;
            ModifyDescriptionInput.Text = model.Description;
            ModifypUHTInput.Text = model.pUHT;
            ModifyRangeInput.SelectedItem = model.Range;
            ModifyPopup.IsOpen = true;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // todo get form informations, check inputs, and add object in database
        }

        private void SeeIngredients_Click(object sender, RoutedEventArgs e)
        {
            FrisbeeModel model = ((FrameworkElement)sender).DataContext as FrisbeeModel;
            IngPopupTitle.Content = $"Ingrédients du frisbee {model.Name}";
            // todo : retrieve model ingredients (service)
            IngPopupDataGrid.ItemsSource = new List<ModelIngredient>()
            {
                new ModelIngredient()
                {
                    Ingredient = new Ingredient()
                    {
                        Name = "Ordure ménagère",
                        Description = "Mmmmmh c'est bon !"
                    },
                    FrisbeeModel = model,
                    Grammage = 249.5
                },
                new ModelIngredient()
                {
                    Ingredient = new Ingredient()
                    {
                        Name = "Béton armé",
                        Description = "Ouh c'est dur !"
                    },
                    FrisbeeModel = model,
                    Grammage = 10.50
                },
                new ModelIngredient()
                {
                    Ingredient = new Ingredient()
                    {
                        Name = "Amour",
                        Description = "Essence de tout être..."
                    },
                    FrisbeeModel = model,
                    Grammage = 500.50
                },
            };
            IngredientsPopup.IsOpen = true;
        }

        private void ClosePopupButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IngredientsPopup.IsOpen = false;
        }

        private void CloseModifyPopupButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModifyPopup.IsOpen = false;
        }

        private void ModifyValidationButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
