using Microsoft.Win32;
using SafeReview;
using SafeReview.Objetos_Blue_Prism;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
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

namespace Code_Inspector
{
    /// <summary>
    /// Interação lógica para Page_Inspecionar.xam
    /// </summary>
    public partial class Page_Inspecionar : Page
    {

        string arquivo_raiz;
        public object excel2;
        public static string RangeA1;
        public static ResourceDictionary DictionaryAtual;

        public Page_Inspecionar()
        {
            InitializeComponent();

            Atualizar_StatusLabel(null);
        }

        public void Atualizar_StatusLabel(string ComboBox_Item)
        {
            if (Txt_Local_Arquivo.Text == "")
            {
                //StatusLabel.Content = "Aguardando seleção de arquivo...";
                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel1");
                Iniciar.IsEnabled= false;
                rectangle_status.Fill = null;
            }
            else if (ComboBox_Item == "" || ComboBox_Item == null)
            {
                //StatusLabel.Content = "Aguardando seleção de Tipo de Release...";
                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel2"); ;
                Iniciar.IsEnabled = false;
                rectangle_status.Fill = null;
            }
            else if (ComboBox_Item == "Automation Anywhere" || ComboBox_Item == "UI Path")
            {
                //StatusLabel.Content = "Desculpas mas ainda não tenho suporte para esse tipo de release";
                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel3");
                Iniciar.IsEnabled = false;
                rectangle_status.Fill = null;
            }
            else 
            {
                //StatusLabel.Content = "Pronto para iniciar...";
                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel4");
                Iniciar.IsEnabled = true;
                rectangle_status.Fill = null;
            }
        }

        private void Selecionar_Arquivo(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog Arquivo = new Microsoft.Win32.OpenFileDialog();
            if (Arquivo.ShowDialog() == true)
            {
                string caminhoCompleto = Arquivo.FileName;
                string nomeArquivo = System.IO.Path.GetFileName(caminhoCompleto);
                string caminhoPasta = System.IO.Path.GetDirectoryName(caminhoCompleto);

                // Txt_Local_Arquivo.Text = caminhoCompleto;
                //Lbl_Nome_Arquivo.Content = nomeArquivo;
                //Lbl_Caminho_Pasta.Content = caminhoPasta;

                arquivo_raiz = caminhoCompleto;

                Txt_Local_Arquivo.Text = caminhoPasta +"\\"+ System.IO.Path.GetFileName(caminhoCompleto);
                Atualizar_StatusLabel(null);
            }
        }


        private void Item_selecionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = SelecaoTipoRelease.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string valor_selecionado = selectedItem.Content.ToString();
                Atualizar_StatusLabel(valor_selecionado);
            }
            
        }

        private async void Iniciar_Conferencia(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newResourceDictionary = new ResourceDictionary();
            newResourceDictionary.MergedDictionaries.Clear();

            switch (MainWindow.language)
            {
                case "English":
                    newResourceDictionary.Source = new Uri("..\\..\\Dictionary_English.xaml", UriKind.Relative);
                    break;
                case "Spanish":
                    newResourceDictionary.Source = new Uri("..\\..\\Dictionary_Spanish.xaml", UriKind.Relative);
                    break;
                case "Portuguese (Brasil)":
                    newResourceDictionary.Source = new Uri("..\\..\\Dictionary_Portuguese_br.xaml", UriKind.Relative);
                    break;
                default:
                    newResourceDictionary.Source = new Uri("..\\..\\Dictionary_English.xaml", UriKind.Relative);
                    break;
            }

            newResourceDictionary.MergedDictionaries.Add(newResourceDictionary);
            DictionaryAtual = newResourceDictionary;

            Log.Clear();

            Action<string> logAction = mensagem =>
            {
                Dispatcher.Invoke(() =>
                {
                    string texto = $"{DateTime.Now:HH:mm:ss} - {mensagem}";
                    Log.AppendText(texto + Environment.NewLine);
                    Log.ScrollToEnd();
                });
            };

            // Log inicial
            logAction(DictionaryAtual["msg_inicio_conferencia"].ToString());

            Log.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF091E35"));
            Log.BorderThickness = new Thickness(1);
            Log.BorderBrush = Brushes.White;

            rectangle_status.Fill = null;
            progressBar.Opacity = 1;
            Iniciar.IsEnabled = false;
            StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel5");

            vExcelv.Criar_Workbooks excel = new vExcelv.Criar_Workbooks();

            // Criando workbook
            logAction(DictionaryAtual["msg_criando_workbook"].ToString());
            excel.Criar_Workbook();

            string sheetName = FindResource("criar_cabecalho_Processo_title").ToString();

            // Criando worksheet (usando msg_criando_worksheet e msg_nome_worksheet)
            logAction(DictionaryAtual["msg_criando_worksheet"].ToString());
            logAction(string.Format(DictionaryAtual["msg_nome_worksheet"].ToString(), sheetName));
            excel.Criar_Woksheet(sheetName);

            // Criando cabeçalho
            logAction(DictionaryAtual["msg_criando_cabecalho"].ToString());
            excel.criar_cabecalho_Processo();

            try
            {
                logAction(DictionaryAtual["msg_iniciando_leitura"].ToString());

                await Task.Run(() => iniciar_Leitor_Release(excel, logAction));

                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel6");
                rectangle_status.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF06B025"));

                logAction(DictionaryAtual["msg_inspecao_sucesso"].ToString());
            }
            catch (Exception ex)
            {
                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel7");
                rectangle_status.Fill = new SolidColorBrush(Colors.Red);

                logAction($"Erro durante a inspeção: {ex.Message}");
            }

            logAction(DictionaryAtual["msg_exibindo_excel"].ToString());
            excel.Excel_Visible();

            progressBar.Opacity = 0;
            Iniciar.IsEnabled = true;

            string RangeA1 = excel.Read_Range(sheetName, "A1").ToString();

            // Aqui não tem chave no dicionário, vai direto:
            logAction($"Valor lido da célula A1: {RangeA1}");

            logAction(DictionaryAtual["msg_processo_finalizado"].ToString());
        }

        private void iniciar_Leitor_Release(vExcelv.Criar_Workbooks excel, Action<string> logAction)
        {
            Leitura_blue_prism_process.Leitor_Release(arquivo_raiz, excel, MainWindow.language, logAction);
        }

    }
}
