using Code_Inspector;
using SafeReview.Objetos_Blue_Prism;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace SafeReview
{
    public partial class MainWindow : Window
    {
        public static string language;
        public static ResourceDictionary dictionary;
        public MainWindow()
        {

            InitializeComponent();
            string Language = ConfigurationManager.AppSettings["Language"];
            Page_Config.SwitchLanguage(this, Language);
            language = Language;
        }

        private void Click_Mover_Janela(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is FrameworkElement element)
            {
                // encontra a Row do elemento
                int row = Grid.GetRow(element);

                Grid grid = element.Parent as Grid;

                if (grid != null)
                {

                    // encontra todos os elementos da Row e escurece a cor de fundo
                    foreach (UIElement child in grid.Children)
                    {
                        if (Grid.GetRow(child) == row && child is Rectangle rectangle)
                        {
                            rectangle.Opacity = 0.1;
                            Main.Opacity = 1;

                        }
                    }//Wn_Scroll
                }
            }
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is FrameworkElement element)
            {
                // encontra a Row do elemento
                int row = Grid.GetRow(element);

                Grid grid = element.Parent as Grid;

                if (grid != null)
                {

                    // encontra todos os elementos da Row e escurece a cor de fundo
                    foreach (UIElement child in grid.Children)
                    {
                        if (Grid.GetRow(child) == row && child is Rectangle rectangle)
                        {
                            rectangle.Opacity = 0;
                            Main.Opacity = 1;

                        }
                    }//Wn_Scroll
                }
            }
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is FrameworkElement element)
            {
                // encontra a Row do elemento
                int row = Grid.GetRow(element);

                Grid grid = element.Parent as Grid;

                if (grid != null)
                {

                    // encontra todos os elementos da Row e escurece a cor de fundo
                    foreach (UIElement child in grid.Children)
                    {
                        if (Grid.GetRow(child) == row)
                        {
                            child.Opacity = 1;
                            Main.Opacity= 1;
                        }


                    }//Wn_Scroll
                }
            }
        }
        
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is FrameworkElement element)
            {
                // encontra a Row do elemento
                int row = Grid.GetRow(element);

                Grid grid = element.Parent as Grid;

                if (grid != null)
                {

                    // encontra todos os elementos da Row e escurece a cor de fundo
                    foreach (UIElement child in grid.Children)
                    {
                        if (Grid.GetRow(child) == row )
                        {
                            child.Opacity = 0.6;
                            Main.Opacity = 1;
                        }
                    }//Wn_Scroll
                }
            }
        }
            private void Minimize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                //Borda.Margin = new Thickness(0, -10, 0, 0);
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                //Borda.Margin = new Thickness(0, 0, 0, 0);

            }
        }

        private void Close_Window(object sender, MouseButtonEventArgs e)
        {
            Close();
            Page_Informacoes pageInformacoes = new Page_Informacoes();
            pageInformacoes.AjusteImagem(sender, e);

        }

        private void CLB_Informacoes(object sender, MouseButtonEventArgs e)
        {   //CLB = Click left button
            if (Main.Content is Page_Informacoes)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_Informacoes();
        }

        private void CLB_FeedBack(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content is Page_FeedBack)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_FeedBack();
        }

        private void CLB_Documentacao(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content is Page_Documentacao)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_Documentacao();
        }

        private void CLB_ODI(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content is Page_ODI)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_ODI();
        }

        private void CLB_Grafico(object sender, MouseButtonEventArgs e)
        {
            if (Page_Grafico.TabelaProcesso.Rows.Count > 0 || Page_Grafico.TabelaObjeto.Rows.Count > 0)
            { 
                if (Main.Content is Page_Grafico)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_Grafico();
            }
            else
            {
                if (Main.Content is Page_Grafico_Null)
                {
                    return;
                }
                else
                {
                    Main.NavigationService.RemoveBackEntry();
                }
                Main.Content = new Page_Grafico_Null();
            }
        }

        private void CLB_Inspecionar(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content is Page_Inspecionar)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_Inspecionar();
        }
        private void CLB_Config(object sender, MouseButtonEventArgs e)
        {
            if (Main.Content is Page_Config)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_Config();
        }

        public void CLB_Grafico_Detail()
        {
            if (Main.Content is Page_Grafico_Detail)
            {
                return;
            }
            else
            {
                Main.NavigationService.RemoveBackEntry();
            }
            Main.Content = new Page_Grafico_Detail();
        }

        public static void Chamar_CLB_Grafico_Detail(MainWindow mainWindow)
        {
            mainWindow.CLB_Grafico_Detail();
        }
    }
}
