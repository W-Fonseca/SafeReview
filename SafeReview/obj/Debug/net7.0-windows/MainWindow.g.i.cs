﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05AF95C1F8F15B5E22C81C38E68624EACDD33E91"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using SafeReview;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SafeReview {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Borda;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Main;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SafeReview;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\MainWindow.xaml"
            ((SafeReview.MainWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Click_Mover_Janela);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Borda = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            
            #line 35 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseEnter);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseLeave);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Minimize);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 36 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseEnter);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseLeave);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Minimize);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 40 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseEnter);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseLeave);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Maximize);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 41 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseEnter);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseLeave);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Maximize);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 45 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Close_Window);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 46 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseEnter);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 47 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseEnter);
            
            #line default
            #line hidden
            
            #line 47 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 92 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 92 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 92 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Inspecionar);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 93 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 93 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 93 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Grafico);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 94 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 94 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 94 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_ODI);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 95 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 95 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 95 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Documentacao);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 96 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 96 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 96 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_FeedBack);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 97 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 97 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 97 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Informacoes);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 98 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 98 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 98 "..\..\..\MainWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Config);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 134 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Inspecionar);
            
            #line default
            #line hidden
            
            #line 134 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 134 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 135 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 135 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 135 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Inspecionar);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 146 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 146 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 147 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 147 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 147 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Grafico);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 158 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 158 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 159 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 159 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 159 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_ODI);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 170 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 170 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 171 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 171 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 171 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Documentacao);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 182 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 182 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 183 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 183 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 183 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_FeedBack);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 194 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 194 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 194 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Inspecionar);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 195 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 195 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 195 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Inspecionar);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 201 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 201 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 201 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Grafico);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 202 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 202 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 202 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Grafico);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 208 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 208 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 208 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_ODI);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 209 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 209 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 209 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_ODI);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 215 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 215 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 215 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Documentacao);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 216 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 216 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 216 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Documentacao);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 222 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 222 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 222 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_FeedBack);
            
            #line default
            #line hidden
            return;
            case 36:
            
            #line 223 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_FeedBack);
            
            #line default
            #line hidden
            
            #line 223 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 223 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 37:
            
            #line 230 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 230 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 230 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Informacoes);
            
            #line default
            #line hidden
            return;
            case 38:
            
            #line 231 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 231 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 231 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Informacoes);
            
            #line default
            #line hidden
            return;
            case 39:
            
            #line 233 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 233 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 40:
            
            #line 234 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 234 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 234 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Informacoes);
            
            #line default
            #line hidden
            return;
            case 41:
            
            #line 245 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 245 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 245 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Config);
            
            #line default
            #line hidden
            return;
            case 42:
            
            #line 246 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 246 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 246 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Config);
            
            #line default
            #line hidden
            return;
            case 43:
            
            #line 248 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 248 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 248 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Config);
            
            #line default
            #line hidden
            return;
            case 44:
            
            #line 249 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 249 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.OnMouseLeave);
            
            #line default
            #line hidden
            
            #line 249 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CLB_Config);
            
            #line default
            #line hidden
            return;
            case 45:
            this.Main = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

