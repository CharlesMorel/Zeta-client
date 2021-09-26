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
        private readonly SessionService sessionService;
        public MainWindow()
        {
            sessionService = new SessionService();

            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // todo
            //AppConstants.BaseApiUrl = Properties.Settings.Default.BaseApiUrl;
            //AppConstants.IdSession = Properties.Settings.Default.IdSession;
            //Voir comment récupérer l'apikey si idsession récupéré
            if (AppConstants.IdSession == null)
            {
                LoginWindow login = new LoginWindow();
                login.Show();
                Close();
            } else
            {
                Session session = await sessionService.Get(AppConstants.IdSession);
                AppConstants.CurrentUser = session.User;
                frame.NavigationService.Navigate(new HomePage());
            }
        }
    }
}
