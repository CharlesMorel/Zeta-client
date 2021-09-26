using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZetaClient.Constants;
using ZetaClient.Entities;
using ZetaClient.Services;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour IngredientsPage.xaml
    /// </summary>
    public partial class IngredientsPage : Page
    {
        private readonly IngredientService _ingredientService;
        private List<Ingredient> allIngredients;
        public IngredientsPage()
        {
            _ingredientService = new IngredientService();

            InitializeComponent();
        }

        private async void IngredientsPage_Loaded(object sender, EventArgs e)
        {
            allIngredients = await _ingredientService.Get();
            IngDataGrid.ItemsSource = allIngredients;
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = ((FrameworkElement)sender).DataContext as Ingredient;

            await _ingredientService.Delete(ingredient.Id);
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = ((FrameworkElement)sender).DataContext as Ingredient;
            ModifyNameInput.Text = ingredient.Name;
            ModifyDescriptionInput.Text = ingredient.Description;
            ModifyPopup.IsOpen = true;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameInput.Text.Length > 0 && DescriptionInput.Text.Length > 0)
            {
                await _ingredientService.Create(new Ingredient()
                {
                    Name = NameInput.Text,
                    Description = DescriptionInput.Text
                });
            }
        }

        private void CloseModifyPopupButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModifyPopup.IsOpen = false;
        }

        private async void ModifyValidationButton_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = ((FrameworkElement)sender).DataContext as Ingredient;
            ingredient.Name = ModifyNameInput.Text;
            ingredient.Description = ModifyDescriptionInput.Text;
            await _ingredientService.Update(ingredient);
            ModifyPopup.IsOpen = false;
        }

        private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string search = SearchTextBox.Text;
            var filtered = allIngredients.Where(ingredient => ingredient.Name.Contains(search) || ingredient.Description.Contains(search));

            IngDataGrid.ItemsSource = filtered;
        }
    }
}
