using Microsoft.VisualBasic;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
using static System.Net.Mime.MediaTypeNames;

namespace Code_Inspector
{
    /// <summary>
    /// Interação lógica para Page_Informacoes.xam
    /// </summary>
    public partial class Page_Informacoes : Page
    {
        int contagem;
        public Page_Informacoes()
        {
            InitializeComponent();

        }
        private System.Media.SoundPlayer player;

        public void AjusteImagem(object sender, MouseButtonEventArgs e)
        {
            contagem += 1;

            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string parentDirPath = System.IO.Directory.GetParent(appPath).FullName;
            string ajustarImagem = Char.ConvertFromUtf32(46) + Char.ConvertFromUtf32(0x70) + Char.ConvertFromUtf32(0x6E) + Char.ConvertFromUtf32(0x67);
            string ajustarImagem2 = Char.ConvertFromUtf32(46) + Char.ConvertFromUtf32(0x0077) + Char.ConvertFromUtf32(0x0061) + Char.ConvertFromUtf32(0x0076);

            if (contagem != 10)
            {

                for (int i = 0; i < 3; i++)
                {
                    parentDirPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                    if (File.Exists(parentDirPath + "Logo" + ajustarImagem2))
                    {
                        System.IO.Path.ChangeExtension(parentDirPath + "Logo" + ajustarImagem2, ajustarImagem);
                        File.Move(parentDirPath + "Logo" + ajustarImagem2, System.IO.Path.ChangeExtension(parentDirPath + "Logo" + ajustarImagem2, ajustarImagem));
                        break;
                    }
                }
            }
            if (contagem == 10)
            {
                for (int i = 0; i < 3; i++)
                {
                    parentDirPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                    if (File.Exists(parentDirPath + "Logo" + ajustarImagem))
                    {
                        System.IO.Path.ChangeExtension(parentDirPath + "Logo" + ajustarImagem, ajustarImagem2);
                        File.Move(parentDirPath + "Logo" + ajustarImagem, System.IO.Path.ChangeExtension(parentDirPath + "Logo" + ajustarImagem, ajustarImagem2));
                        break;
                    }
                }
                //player.SoundLocation = parentDirPath + "Logo" + ajustarImagem2;
                player = new System.Media.SoundPlayer(parentDirPath + "Logo" + ajustarImagem2);
                player.Play();

                informacoes_projeto.FontSize = 30;
                informacoes_projeto.Text = Char.ConvertFromUtf32(67) + Char.ConvertFromUtf32(114) + Char.ConvertFromUtf32(101) + Char.ConvertFromUtf32(97) + Char.ConvertFromUtf32(116) + Char.ConvertFromUtf32(101) + Char.ConvertFromUtf32(32) + Char.ConvertFromUtf32(66) + Char.ConvertFromUtf32(121) + Char.ConvertFromUtf32(58) + Char.ConvertFromUtf32(32) + "" + Char.ConvertFromUtf32(104) + Char.ConvertFromUtf32(116) + Char.ConvertFromUtf32(116) + Char.ConvertFromUtf32(112) + Char.ConvertFromUtf32(115) + Char.ConvertFromUtf32(58) + Char.ConvertFromUtf32(47) + Char.ConvertFromUtf32(47) + Char.ConvertFromUtf32(0x67) + Char.ConvertFromUtf32(0x69) + Char.ConvertFromUtf32(0x74) + Char.ConvertFromUtf32(0x68) + Char.ConvertFromUtf32(0x75) + Char.ConvertFromUtf32(0x62) + Char.ConvertFromUtf32(47) + Char.ConvertFromUtf32(0x57) + "-" + Char.ConvertFromUtf32(0x46) + Char.ConvertFromUtf32(0x6F) + Char.ConvertFromUtf32(0x6E) + Char.ConvertFromUtf32(0x73) + Char.ConvertFromUtf32(0x65) + Char.ConvertFromUtf32(0x63) + Char.ConvertFromUtf32(0x61);
                Microsoft.Web.WebView2.Wpf.WebView2 webview = new Microsoft.Web.WebView2.Wpf.WebView2();

            }
        }
    }
}
