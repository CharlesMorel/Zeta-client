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

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            // todo: check user department

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
    }
}
