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

        public ProcessPage()
        {
            // todo: check user department

            _frisbeeModelService = new FrisbeeModelService();
            _processService = new ProcessService();

            InitializeComponent();
        }

        private async void ProcessPage_Loaded(object sender, EventArgs e)
        {
            AllFrisbeeModel = await _frisbeeModelService.Get();
            ModelInput.ItemsSource = AllFrisbeeModel;
            ProcessDataGrid.ItemsSource = await _processService.Get();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Process process = ((FrameworkElement)sender).DataContext as Process;
            ModifyNameInput.Text = process.Name;
            ModifyDescriptionInput.Text = process.Description;
            ModifyStepDescriptionInput.Text = process.StepDescription;
            ModifyModelInput.ItemsSource = AllFrisbeeModel;
            ModifyModelInput.SelectedItem = process.FrisbeeModel;
            ModifyPopup.IsOpen = true;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void ModifyValidationButton_Click(object sender, RoutedEventArgs e)
        {
            // do something
            ModifyPopup.IsOpen = false;
        }

        private void CloseModifyPopupButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ModifyPopup.IsOpen = false;
        }
    }
}
