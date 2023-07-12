using SafeReview.Objetos_Blue_Prism;
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

namespace Code_Inspector
{
    /// <summary>
    /// Interação lógica para Page_ODI.xam
    /// </summary>
    public partial class Page_ODI : Page
    {
        string arquivo_raiz;
        public Page_ODI()
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

                Txt_Local_Arquivo.Text = caminhoPasta + "\\" + System.IO.Path.GetFileName(caminhoCompleto);
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
            rectangle_status.Fill = null;
            progressBar.Opacity = 1;
            Iniciar.IsEnabled = false;
           // StatusLabel.Content = "Load ODI...";
            StatusLabel.Content = FindResource("ODI_Csharp_StatusLabel1");
            vExcelv.Criar_Workbooks excel = new vExcelv.Criar_Workbooks();
            excel.Criar_Workbook();
            excel.Criar_Woksheet("Preview_IT");
            excel.criar_implamentation_Tracker();
            try
            {
                await Task.Run(() => iniciar_Leitor_Release(excel));
                //await Task.Run(iniciar_Leitor_Release);
                //SafeReview.Objetos_Blue_Prism.Implentation_Tracker.Leitura_objetos_Tracker(arquivo_raiz);
                //StatusLabel.Content = "ODI Concluida";
                StatusLabel.Content = FindResource("ODI_Csharp_StatusLabel2");
                rectangle_status.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF06B025"));
            }
            catch
            {
                // StatusLabel.Content = "Erro ao gerar ODI, arquivo com erro ou corrompido";
                StatusLabel.Content = FindResource("ODI_Csharp_StatusLabel3");
                rectangle_status.Fill = new SolidColorBrush(Colors.Red);
            }
            excel.Excel_Visible();
            //vExcelv.retorno_application excel = new vExcelv.retorno_application();
            //SafeReview.Objetos_Blue_Prism.vExcelv.Criar_Workbooks.retorno_application;
            progressBar.Opacity = 0;
            Iniciar.IsEnabled = true;
        }
        private void iniciar_Leitor_Release(vExcelv.Criar_Workbooks excel)
        {
           Implentation_Tracker.Leitura_objetos_Tracker(arquivo_raiz, excel);
        }

    }
}
