using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZetaClient.Entities;
using ZetaClient.Entities.Enums;
using ZetaClient.Services;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour ModelsPage.xaml
    /// </summary>
    public partial class ModelsPage : Page
    {
        private readonly FrisbeeModelService _frisbeeModelService;
        private readonly IngredientService _ingredientService;
        public ModelsPage()
        {
            // todo: check user department

            _frisbeeModelService = new FrisbeeModelService();
            _ingredientService = new IngredientService();

            InitializeComponent();
        }

        private async void ModelPage_Loaded(object sender, EventArgs e)
        {
            //ModelDataGrid.ItemsSource = await _ingredientService.Get();
            //IngredientsListBox.ItemsSource = await _ingredientService.Get();
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            FrisbeeModel model = ((FrameworkElement)sender).DataContext as FrisbeeModel;

            await _frisbeeModelService.Delete(model.Id);
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

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameInput.Text.Length > 0 &&
                DescriptionInput.Text.Length > 0 &&
                pUHTInput.Text.Length > 0 &&
                IngredientsListBox.SelectedItems.Count > 0)
            {
                await _frisbeeModelService.Create(new FrisbeeModel()
                {
                    Name = NameInput.Text,
                    Description = DescriptionInput.Text,
                    pUHT = pUHTInput.Text,
                    Range = (RangeType)RangeInput.SelectedItem
                }, (List<Ingredient>)IngredientsListBox.SelectedItems);
            }
        }

        private async void SeeIngredients_Click(object sender, RoutedEventArgs e)
        {
            FrisbeeModel model = ((FrameworkElement)sender).DataContext as FrisbeeModel;
            IngPopupTitle.Content = $"Ingrédients du frisbee {model.Name}";
            IngPopupDataGrid.ItemsSource = await _frisbeeModelService.GetIngredientByModel(model.Id);
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

        private async void ModifyValidationButton_Click(object sender, RoutedEventArgs e)
        {
            FrisbeeModel model = ((FrameworkElement)sender).DataContext as FrisbeeModel;
            model.Name = NameInput.Text;
            model.Description = DescriptionInput.Text;
            model.pUHT = pUHTInput.Text;
            model.Range = (RangeType)RangeInput.SelectedItem;
            await _frisbeeModelService.Update(model);
            ModifyPopup.IsOpen = false;
        }
    }
}
