using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;

namespace SafeReview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void Languagem_Subpages(string language)
        {
            // Carrega o novo ResourceDictionary
            ResourceDictionary newResourceDictionary = new ResourceDictionary();
            newResourceDictionary.Source = new Uri(language, UriKind.Relative);

            // Acessa o ResourceDictionary atual do aplicativo
            ResourceDictionary appResources = Application.Current.Resources;

            // Remove todos os dicionários de recursos mesclados anteriormente
            appResources.MergedDictionaries.Clear();

            // Adiciona o novo ResourceDictionary
            appResources.MergedDictionaries.Add(newResourceDictionary);

        }
    }
}
