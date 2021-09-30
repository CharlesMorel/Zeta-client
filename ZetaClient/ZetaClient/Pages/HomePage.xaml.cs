using System.Windows;
using System.Windows.Controls;
using ZetaClient.Constants;
using ZetaClient.Services;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly UserService userService;
        public HomePage()
        {
            // todo: check user department
            userService = new UserService();

            InitializeComponent();
        }

        private void Models_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ModelsPage());
        }

        private void Ingredients_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new IngredientsPage());
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProcessPage());
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            await userService.Logout();
            LoginWindow login = new LoginWindow();
            Window main = Window.GetWindow(this);
            login.Show();
            main.Close();
        }
    }
}
