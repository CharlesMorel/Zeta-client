using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZetaClient.Constants;
using ZetaClient.Entities;
using ZetaClient.pages;
using ZetaClient.Services;

namespace ZetaClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // todo
            AppConstants.BaseApiUrl = "http://localhost:8000/";
            if (AppConstants.ApiKey == null)
            {
                LoginWindow login = new LoginWindow();
                login.Show();
                Close();
            } else
            {
                frame.NavigationService.Navigate(new HomePage());
            }
        }
    }
}
