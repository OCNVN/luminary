﻿#pragma checksum "..\..\ControlVocabulario.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C50810A8F5A235BD8C6E6760B1EB35B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Aprendiendo.controles.teclado;
using Aprendiendo.luminary;
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
    /// ControlVocabulario
    /// </summary>
    public partial class ControlVocabulario : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 54 "..\..\ControlVocabulario.xaml"
        internal Aprendiendo.controles.teclado.Teclado teclado;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\ControlVocabulario.xaml"
        internal System.Windows.Controls.Image imageSenas;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\ControlVocabulario.xaml"
        internal System.Windows.Controls.TextBox txtIngresar;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\ControlVocabulario.xaml"
        internal System.Windows.Controls.Button btnTraducir;
        
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
            System.Uri resourceLocater = new System.Uri("/Aprendiendo;component/controlvocabulario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ControlVocabulario.xaml"
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
            this.teclado = ((Aprendiendo.controles.teclado.Teclado)(target));
            return;
            case 2:
            this.imageSenas = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.txtIngresar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnTraducir = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\ControlVocabulario.xaml"
            this.btnTraducir.Click += new System.Windows.RoutedEventHandler(this.btnTraducir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}