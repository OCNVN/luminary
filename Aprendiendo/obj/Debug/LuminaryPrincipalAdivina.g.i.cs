﻿#pragma checksum "..\..\LuminaryPrincipalAdivina.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "126F8813D3B2C8B8FEE70E43E6342444"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Aprendiendo;
using Aprendiendo.controles.teclado;
using Aprendiendo.luminary;
using AvalonDock;
using LuminaryFramework;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Aprendiendo {
    
    
    /// <summary>
    /// LuminaryPrincipalInteractivo
    /// </summary>
    public partial class LuminaryPrincipalAdivina : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\LuminaryPrincipalAdivina.xaml"
        internal Aprendiendo.LuminaryPrincipalInteractivo Window2;
        
        #line default
        #line hidden
        
        
        #line 518 "..\..\LuminaryPrincipalAdivina.xaml"
        internal System.Windows.Controls.Grid grillaPrincipal;
        
        #line default
        #line hidden
        
        
        #line 541 "..\..\LuminaryPrincipalAdivina.xaml"
        internal AvalonDock.DockablePane dockablePane;
        
        #line default
        #line hidden
        
        
        #line 543 "..\..\LuminaryPrincipalAdivina.xaml"
        internal LuminaryFramework.Luminary modelo3D;
        
        #line default
        #line hidden
        
        
        #line 546 "..\..\LuminaryPrincipalAdivina.xaml"
        internal Aprendiendo.Controles3D controles3D;
        
        #line default
        #line hidden
        
        
        #line 551 "..\..\LuminaryPrincipalAdivina.xaml"
        internal System.Windows.Controls.Label lblAdivina;
        
        #line default
        #line hidden
        
        
        #line 552 "..\..\LuminaryPrincipalAdivina.xaml"
        internal System.Windows.Controls.Image imagenAdivina;
        
        #line default
        #line hidden
        
        
        #line 553 "..\..\LuminaryPrincipalAdivina.xaml"
        internal Aprendiendo.controles.teclado.Teclado teclado;
        
        #line default
        #line hidden
        
        
        #line 561 "..\..\LuminaryPrincipalAdivina.xaml"
        internal System.Windows.Controls.Button btnNuevaPalabra;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Aprendiendo;component/luminaryprincipaladivina.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LuminaryPrincipalAdivina.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window2 = ((Aprendiendo.LuminaryPrincipalInteractivo)(target));
            return;
            case 2:
            this.grillaPrincipal = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.dockablePane = ((AvalonDock.DockablePane)(target));
            return;
            case 4:
            this.modelo3D = ((LuminaryFramework.Luminary)(target));
            return;
            case 5:
            this.controles3D = ((Aprendiendo.Controles3D)(target));
            return;
            case 6:
            this.lblAdivina = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.imagenAdivina = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.teclado = ((Aprendiendo.controles.teclado.Teclado)(target));
            return;
            case 9:
            this.btnNuevaPalabra = ((System.Windows.Controls.Button)(target));
            
            #line 561 "..\..\LuminaryPrincipalAdivina.xaml"
            this.btnNuevaPalabra.Click += new System.Windows.RoutedEventHandler(this.btnNuevaPalabra_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
