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

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour ProcessPage.xaml
    /// </summary>
    public partial class ProcessPage : Page
    {
        public ProcessPage()
        {
            // todo: check user department

            InitializeComponent();
        }

        private void ProcessPage_Loaded(object sender, EventArgs e)
        {
            ModelInput.ItemsSource = LoadFrisbeeModelCollection();
            ProcessDataGrid.ItemsSource = LoadProcessCollection();
        }

        private List<Process> LoadProcessCollection()
        {
            return new List<Process>()
            {
                new Process()
                {
                    Name = "truc",
                    Description = "truc",
                    StepDescription = "truc",
                    FrisbeeModel = new FrisbeeModel()
                    {
                        Name = "trtrtr"
                    }
                }
            };
        }

        private List<FrisbeeModel> LoadFrisbeeModelCollection()
        {
            return new List<FrisbeeModel>()
            {

            };
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Process process = ((FrameworkElement)sender).DataContext as Process;
            ModifyNameInput.Text = process.Name;
            ModifyDescriptionInput.Text = process.Description;
            ModifyStepDescriptionInput.Text = process.StepDescription;
            ModifyModelInput.ItemsSource = LoadFrisbeeModelCollection();
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
