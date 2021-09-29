using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private List<FrisbeeModel> allModels;
        private FrisbeeModel selectedModel;

        public ModelsPage()
        {
            // todo: check user department

            _frisbeeModelService = new FrisbeeModelService();
            _ingredientService = new IngredientService();

            InitializeComponent();
        }

        private async void ModelPage_Loaded(object sender, EventArgs e)
        {
            allModels = await _frisbeeModelService.Get();
            ModelDataGrid.ItemsSource = allModels;
            IngredientsListBox.ItemsSource = await _ingredientService.Get();
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            FrisbeeModel model = ((FrameworkElement)sender).DataContext as FrisbeeModel;

            await _frisbeeModelService.Delete(model.Id);
            allModels = await _frisbeeModelService.Get();
            ModelDataGrid.ItemsSource = allModels;
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            FrisbeeModel model = ((FrameworkElement)sender).DataContext as FrisbeeModel;
            selectedModel = model;
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

                allModels = await _frisbeeModelService.Get();
                ModelDataGrid.ItemsSource = allModels;
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
            selectedModel.Name = NameInput.Text;
            selectedModel.Description = DescriptionInput.Text;
            selectedModel.pUHT = pUHTInput.Text;
            selectedModel.Range = (RangeType)RangeInput.SelectedItem;
            await _frisbeeModelService.Update(selectedModel);
            allModels = await _frisbeeModelService.Get();
            ModelDataGrid.ItemsSource = allModels;
            ModifyPopup.IsOpen = false;
        }

        private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string search = SearchTextBox.Text;
            var filtered = allModels.Where(model => 
                model.Name.Contains(search) || 
                model.Description.Contains(search) || 
                model.pUHT.Contains(search) || 
                model.Range.ToString().Contains(search));

            ModelDataGrid.ItemsSource = filtered;
        }
    }
}
