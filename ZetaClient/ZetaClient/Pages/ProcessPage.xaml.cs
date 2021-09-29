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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZetaClient.Entities;
using ZetaClient.Services;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour ProcessPage.xaml
    /// </summary>
    public partial class ProcessPage : Page
    {
        private readonly FrisbeeModelService _frisbeeModelService;
        private readonly ProcessService _processService;
        public List<FrisbeeModel> AllFrisbeeModel;
        private List<Process> allProcess;
        private Process selectedProcess;

        public ProcessPage()
        {
            // todo: check user department

            _frisbeeModelService = new FrisbeeModelService();
            _processService = new ProcessService();

            InitializeComponent();
        }

        private async void ProcessPage_Loaded(object sender, EventArgs e)
        {
            allProcess = await _processService.Get();
            AllFrisbeeModel = await _frisbeeModelService.Get();
            ModelInput.ItemsSource = AllFrisbeeModel;
            ProcessDataGrid.ItemsSource = allProcess;
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Process process = ((FrameworkElement)sender).DataContext as Process;
            selectedProcess = process;
            ModifyNameInput.Text = process.Name;
            ModifyDescriptionInput.Text = process.Description;
            ModifyStepDescriptionInput.Text = process.StepDescription;
            ModifyModelInput.ItemsSource = AllFrisbeeModel;
            ModifyModelInput.SelectedItem = process.FrisbeeModel;
            ModifyPopup.IsOpen = true;
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            Process process = ((FrameworkElement)sender).DataContext as Process;
            await _processService.Delete(process.Id);
            allProcess = await _processService.Get();
            ProcessDataGrid.ItemsSource = allProcess;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            await _processService.Create(new Process()
            {
                Name = NameInput.Text,
                Description = DescriptionInput.Text,
                StepDescription = StepDescriptionInput.Text,
                FrisbeeModel = (FrisbeeModel)ModelInput.SelectedItem
            });
            allProcess = await _processService.Get();
            ProcessDataGrid.ItemsSource = allProcess;
        }

        private async void ModifyValidationButton_Click(object sender, RoutedEventArgs e)
        {
            selectedProcess.Name = ModifyNameInput.Text;
            selectedProcess.Description = ModifyDescriptionInput.Text;
            selectedProcess.StepDescription = ModifyStepDescriptionInput.Text;
            selectedProcess.FrisbeeModel = (FrisbeeModel)ModifyModelInput.SelectedItem;
            await _processService.Update(selectedProcess);
            allProcess = await _processService.Get();
            ProcessDataGrid.ItemsSource = allProcess;
            ModifyPopup.IsOpen = false;
        }

        private void CloseModifyPopupButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ModifyPopup.IsOpen = false;
        }

        private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string search = SearchTextBox.Text;
            var filtered = allProcess.Where(process => 
                process.Name.Contains(search) || 
                process.Description.Contains(search) || 
                process.StepDescription.Contains(search) || 
                process.FrisbeeModel.Name.Contains(search));

            ProcessDataGrid.ItemsSource = filtered;
        }
    }
}
