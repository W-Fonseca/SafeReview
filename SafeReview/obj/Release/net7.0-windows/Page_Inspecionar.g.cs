﻿#pragma checksum "..\..\..\Page_Inspecionar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D2593A44F6B7C686FD68E3B7C506491232BC5FEE"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Code_Inspector;
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


namespace Code_Inspector {
    
    
    /// <summary>
    /// Page_Inspecionar
    /// </summary>
    public partial class Page_Inspecionar : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Page_Inspecionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl Page_inspec;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Page_Inspecionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Local_Arquivo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Page_Inspecionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelecaoTipoRelease;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Page_Inspecionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectangle_status;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Page_Inspecionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBar;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Page_Inspecionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Iniciar;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Page_Inspecionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label StatusLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SafeReview;component/page_inspecionar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Page_Inspecionar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Page_inspec = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 2:
            this.Txt_Local_Arquivo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 19 "..\..\..\Page_Inspecionar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Selecionar_Arquivo);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SelecaoTipoRelease = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\Page_Inspecionar.xaml"
            this.SelecaoTipoRelease.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Item_selecionado);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rectangle_status = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 6:
            this.progressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 7:
            this.Iniciar = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Page_Inspecionar.xaml"
            this.Iniciar.Click += new System.Windows.RoutedEventHandler(this.Iniciar_Conferencia);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StatusLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

