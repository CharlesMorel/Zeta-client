using System.Windows;
using ZetaClient.Constants;
using ZetaClient.Services;

namespace ZetaClient
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IngredientService _ingredientService = new IngredientService();

        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
            // todo: retrieve BaseApiUrl & user
        }
    }
}
