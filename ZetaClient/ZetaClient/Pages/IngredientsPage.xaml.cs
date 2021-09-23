using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZetaClient.Entities;

namespace ZetaClient.pages
{
    /// <summary>
    /// Logique d'interaction pour IngredientsPage.xaml
    /// </summary>
    public partial class IngredientsPage : Page
    {
        private IEnumerable<Ingredient> _ingredients;

        public IngredientsPage()
        {
            InitializeComponent();
        }

        async void Page_Loaded(object sender, EventArgs e)
        {

        }
    }
}
