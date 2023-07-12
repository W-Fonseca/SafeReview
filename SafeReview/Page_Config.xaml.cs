using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
using System.IO;

namespace SafeReview
{
    /// <summary>
    /// Interação lógica para Page_Config.xam
    /// </summary>
    public partial class Page_Config : Page
    {

        public Page_Config()
        {
            InitializeComponent();
        }
        private void Item_selecionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem != null)
            {
                string valor_selecionado = selectedItem.Content.ToString();
                SwitchLanguage((Window.GetWindow(comboBox)), valor_selecionado);
            }
        }

        public static void SwitchLanguage(Window window, string LanguageCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (LanguageCode)
            {
                case "English":
                    dictionary.Source = new Uri("..\\Dictionary_English.xaml", UriKind.Relative);
                    App.Languagem_Subpages("Dictionary_English.xaml");
                    MainWindow.language = "English";
                    break;
                case "Spanish":
                    dictionary.Source = new Uri("..\\Dictionary_Spanish.xaml", UriKind.Relative);
                    App.Languagem_Subpages("Dictionary_Spanish.xaml");
                    MainWindow.language = "Spanish";
                    break;
                case "Portuguese (Brasil)":
                    dictionary.Source = new Uri("..\\Dictionary_Portuguese_br.xaml", UriKind.Relative);
                    App.Languagem_Subpages("Dictionary_Portuguese_br.xaml");
                    MainWindow.language = "Portuguese (Brasil)";
                    break;
                default:
                    dictionary.Source = new Uri("..\\Dictionary_English.xaml", UriKind.Relative);
                    App.Languagem_Subpages("Dictionary_English.xaml");
                    MainWindow.language = "English";
                    break;
            }
            window.Resources.MergedDictionaries.Add(dictionary);
            MainWindow.dictionary = dictionary;





        }

        private void Press_Save(object sender, RoutedEventArgs e)
        {

            string configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;

            // Excluir o arquivo de configurações existente
            if (File.Exists(configFile))
            {
                File.Delete(configFile);
            }
            // Cria uma configuração
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Adiciona uma configuração personalizada
            config.AppSettings.Settings.Add("Language", MainWindow.language);

            // Salva as alterações no arquivo de configuração
            config.Save(ConfigurationSaveMode.Modified);

            // Recarrega as configurações
            //   ConfigurationManager.RefreshSection("appSettings");

            // Lê as configurações do arquivo
            //  string username = ConfigurationManager.AppSettings["Username"];
            //  string email = ConfigurationManager.AppSettings["Email"];

            // Exibe as configurações
            //  Console.WriteLine("Username: " + username);
            //  Console.WriteLine("Email: " + email);
        }
    }
}
