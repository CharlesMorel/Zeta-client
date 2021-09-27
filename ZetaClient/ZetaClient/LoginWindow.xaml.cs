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
using System.Windows.Shapes;
using ZetaClient.Constants;
using ZetaClient.Services;

namespace ZetaClient
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserService _userService;
        public LoginWindow()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailInput.Text;
            string password = PasswordInput.Text;
            if (email.Length > 0 && password.Length > 0)
            {
                try
                {
                    await _userService.Login(email, password);
                }
                catch (Exception ex)
                {
                    AlertLabel.Text = ex.Message;
                }
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            }
            else
            {
                AlertLabel.Text = "Veuillez compléter les champs ci-dessus.";
            }
        }
    }
}
