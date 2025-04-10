﻿using Microsoft.Win32;
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

            rectangle_status.Fill = null;
            progressBar.Opacity = 1;
            Iniciar.IsEnabled = false;
            //StatusLabel.Content = "Inspecionando...";
            StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel5");
            vExcelv.Criar_Workbooks excel = new vExcelv.Criar_Workbooks();
            excel.Criar_Workbook();
            //excel.Criar_Woksheet("Conferencia_Processo");
            excel.Criar_Woksheet(FindResource("criar_cabecalho_Processo_title").ToString());
            excel.criar_cabecalho_Processo();
            try
            {
                await Task.Run(()=>iniciar_Leitor_Release(excel));
                //StatusLabel.Content = "Inspeção Concluida";
                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel6");
                rectangle_status.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF06B025"));


            }

            catch
            {
                //StatusLabel.Content = "Erro na Inspeção, arquivo com erro ou corrompido";
                StatusLabel.Content = FindResource("inspecionar_Csharp_StatusLabel7");
                rectangle_status.Fill = new SolidColorBrush(Colors.Red);
            }
            excel.Excel_Visible();
            progressBar.Opacity = 0;
            Iniciar.IsEnabled = true;
            RangeA1 = excel.Read_Range(FindResource("criar_cabecalho_Processo_title").ToString(),"A1").ToString();
        }

        private void iniciar_Leitor_Release(vExcelv.Criar_Workbooks excel)
        {
            Leitura_blue_prism_process.Leitor_Release(arquivo_raiz,excel, MainWindow.language);
        }
    }
}
