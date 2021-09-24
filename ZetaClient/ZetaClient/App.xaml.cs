using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZetaClient.Constants;
using ZetaClient.DataAccess;
using ZetaClient.Entities;
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

            // todo: retrieve BaseApiUrl

            await _ingredientService.Get();
        }
    }
}
