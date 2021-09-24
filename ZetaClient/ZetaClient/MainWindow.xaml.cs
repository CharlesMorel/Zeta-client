using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZetaClient.Constants;
using ZetaClient.pages;

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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppConstants.IdSession == null)
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
