using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
using Code_Inspector;

namespace SafeReview
{
    /// <summary>
    /// Interação lógica para Page_Grafico_Detail.xam
    /// </summary>
    public partial class Page_Grafico_Detail : Page
    {
        public Page_Grafico_Detail()
        {
            InitializeComponent();
            Basic_Column();
        }

        public static string GraficoClicado;
        public SeriesCollection SeriesCollection_BasicColumn { get; set; }
        public string[] BasicColumnLabels { get; set; }
        private void Basic_Column()
        {
            List<string[]> Categoria_tipo = new List<string[]>();


           var grupos = GraficoClicado == "PRO"
           ?Page_Grafico.TabelaProcesso.AsEnumerable()
                .GroupBy(row => new { Categoria = row.Field<string>("Categoria"), Tipo = row.Field<string>("Tipo_Erro") })
                .Select(group => new { Categoria = group.Key.Categoria, Tipo = group.Key.Tipo, Quantidade = group.Count() })
                .ToList()
           : Page_Grafico.TabelaObjeto.AsEnumerable()
                .GroupBy(row => new { Categoria = row.Field<string>("Categoria"), Tipo = row.Field<string>("Tipo_Erro") })
                .Select(group => new { Categoria = group.Key.Categoria, Tipo = group.Key.Tipo, Quantidade = group.Count() })
                .ToList();
            

            if (Page_Grafico.TabelaProcesso.Rows.Count > 0 && Page_Grafico.TabelaObjeto.Rows.Count > 0)
            {
                SeriesCollection_BasicColumn = new SeriesCollection();

                var categorias = grupos.Select(g => g.Categoria).Distinct().ToList();
                var tipos = grupos.Select(g => g.Tipo).Distinct().ToList();             

                foreach (var categoria in categorias)
                {
                    var grupoCategoria = grupos.Where(g => g.Categoria == categoria).ToList();

                    foreach (var tipo in tipos)
                    {
                        var quantidade = grupoCategoria.FirstOrDefault(g => g.Tipo == tipo)?.Quantidade ?? 0;

                        if (quantidade > 0)
                        {
                            
                            SeriesCollection_BasicColumn.Add(new ColumnSeries
                            {
                                Title = categoria + " - " + tipo,
                              //  LabelPoint = chartPoint => categoria + " - " + tipo,
                             //   LabelsPosition = BarLabelPosition.Merged,
                                Values = new ChartValues<ObservableValue> { new ObservableValue(quantidade) },
                                DataLabels = true,
                                Foreground = new SolidColorBrush(Colors.White)
                            });

                        }
                    }
                }                
                DataContext = this;
                if (GraficoClicado == "PRO") { 
                BasicColumnLabels = new[] { "Processo" };
                }
                else
                {
                    BasicColumnLabels = new[] { "Objeto" };
                }
                //CartesianChart.MinValue = -10;
            }
        }

        private void Atualizar(object sender, RoutedEventArgs e)
        {
            Basic_Column();
        }
    }
}
