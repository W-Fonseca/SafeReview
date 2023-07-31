using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using SafeReview;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Code_Inspector
{
    /// <summary>
    /// Interação lógica para Page_Grafico.xam
    /// </summary>
    public partial class Page_Grafico : System.Windows.Controls.Page
    {
        public Page_Grafico()
        {
            InitializeComponent();
            GraficosOBJ();
            GraficosPRO();
            Basic_Column();
        }
        public static System.Data.DataTable TabelaObjeto = new System.Data.DataTable { Columns = { { "Tipo_Erro", typeof(string) }, { "Categoria", typeof(string) } } };
        public static System.Data.DataTable TabelaProcesso = new System.Data.DataTable { Columns = { { "Tipo_Erro", typeof(string) }, { "Categoria", typeof(string) } } };
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }
        public SeriesCollection SeriesCollection_BasicColumn { get; set; }
        public string[] BasicColumnLabels { get; set; }
        public void GraficosOBJ()
        {
            var grupos = TabelaObjeto.AsEnumerable()
                     .GroupBy(row => row.Field<string>("Categoria"))
                     .Select(group => new { Tipo = group.Key, Quantidade = group.Count() });
            SeriesCollection = new SeriesCollection();
            int cont_cor = 1;
            foreach (var grupo in grupos)
            {
                cont_cor++;
                SeriesCollection.Add(new PieSeries
                {
                    Title = grupo.Tipo,
                   // Fill = new SolidColorBrush(Color.FromRgb((byte)(31 + cont_cor), (byte)(70 + cont_cor * 10), (byte)(80 +cont_cor * 10))),
                    Values = new ChartValues<ObservableValue> { new ObservableValue(grupo.Quantidade) }, // Ajuste para usar a quantidade do grupo
                    DataLabels = true
                });
            }


            DataContext = this;
                SizeChanged += MainWindow_SizeChanged;
        }

        public void GraficosPRO()
        {
            var grupos = TabelaProcesso.AsEnumerable()
                .GroupBy(row => row.Field<string>("Categoria"))
                .Select(group => new { Tipo = group.Key, Quantidade = group.Count() });

            SeriesCollection2 = new SeriesCollection();
            int cont_cor = 1;
            foreach (var grupo in grupos)
            {
                cont_cor++;
                SeriesCollection2.Add(new PieSeries
                {
                    Title = grupo.Tipo,
                   // Fill = new SolidColorBrush(Color.FromRgb(4,(byte)(60 + cont_cor * 10),(byte)(50 + cont_cor * 10))),
                    Values = new ChartValues<ObservableValue> { new ObservableValue(grupo.Quantidade)},
                    DataLabels = true
                });
            }
        DataContext = this;
        }
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double minSize = Math.Min(ActualWidth, ActualHeight);
            double innerRadius = minSize / 20; // Ajuste o valor 0.2 para controlar a proporção do buraco no meio
            double innerRadius2 = minSize / 10;
               
            Grafico.InnerRadius = innerRadius;
            Grafico2.InnerRadius = innerRadius;
        }
        private void Basic_Column()
        {
            var grupoObjeto = TabelaObjeto.AsEnumerable()
                    .GroupBy(row => row.Field<string>("Tipo_Erro"))
                    .Select(group => new { Tipo = group.Key, Quantidade = group.Count() });

            var grupoProcesso = TabelaProcesso.AsEnumerable()
                    .GroupBy(row => row.Field<string>("Tipo_Erro"))
                    .Select(group => new { Tipo = group.Key, Quantidade = group.Count() });

            if (TabelaProcesso.Rows.Count > 0 && TabelaObjeto.Rows.Count > 0)
            {

                SeriesCollection_BasicColumn = new SeriesCollection
{
                new ColumnSeries
                {
                    Title = "Objeto",
                    Fill = new SolidColorBrush(Color.FromRgb(90, 203, 227)),
                    Values = new ChartValues<ObservableValue> { new ObservableValue(grupoObjeto.FirstOrDefault(item => item.Tipo == "Notification")?.Quantidade ?? 0), new ObservableValue(grupoObjeto.FirstOrDefault(item => item.Tipo == "Error")?.Quantidade ?? 0), new ObservableValue(grupoObjeto.FirstOrDefault(item => item.Tipo == "Alert")?.Quantidade ?? 0) }
                }
                };


                SeriesCollection_BasicColumn.Add(new ColumnSeries
                {
                    Title = "Processo",
                    Fill = new SolidColorBrush(Color.FromRgb(106, 195, 153)), // Azul padrão
                    Values = new ChartValues<ObservableValue> { new ObservableValue(grupoProcesso.FirstOrDefault(item => item.Tipo == "Notification")?.Quantidade ?? 0), new ObservableValue(grupoProcesso.FirstOrDefault(item => item.Tipo == "Error")?.Quantidade ?? 0), new ObservableValue(grupoProcesso.FirstOrDefault(item => item.Tipo == "Alert")?.Quantidade ?? 0) }
                });

                BasicColumnLabels = new[] { "Notification", "Error","Alert"};
                DataContext = this;
            }
        }

        private void teste_Click(object sender, RoutedEventArgs e)
        {
            GraficosOBJ();
            GraficosPRO();
            Basic_Column();
        }

        private void Grafico2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                Page_Grafico_Detail.GraficoClicado = "PRO";
                mainWindow.CLB_Grafico_Detail();
            }
        }

        private void Grafico3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                Page_Grafico_Detail.GraficoClicado = "OBJ";
                mainWindow.CLB_Grafico_Detail();
            }
        }
    }
}

