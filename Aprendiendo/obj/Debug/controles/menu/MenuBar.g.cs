#pragma checksum "..\..\..\..\controles\menu\MenuBar.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CD08D02B644FF4A24052E7784AA6F8A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// MenuBar
    /// </summary>
    public partial class MenuBar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\controles\menu\MenuBar.xaml"
        internal Aprendiendo.MenuBar UserControl;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\..\controles\menu\MenuBar.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\..\controles\menu\MenuBar.xaml"
        internal System.Windows.Controls.Button btnVocabulario;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\..\..\controles\menu\MenuBar.xaml"
        internal System.Windows.Controls.Button btnAdivina;
        
        #line default
        #line hidden
        
        
        #line 253 "..\..\..\..\controles\menu\MenuBar.xaml"
        internal System.Windows.Controls.Button btnChat;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\..\controles\menu\MenuBar.xaml"
        internal System.Windows.Controls.Button btnConfiguracion;
        
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
            System.Uri resourceLocater = new System.Uri("/Aprendiendo;component/controles/menu/menubar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\controles\menu\MenuBar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserControl = ((Aprendiendo.MenuBar)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btnVocabulario = ((System.Windows.Controls.Button)(target));
            
            #line 251 "..\..\..\..\controles\menu\MenuBar.xaml"
            this.btnVocabulario.Click += new System.Windows.RoutedEventHandler(this.HandlerComun);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAdivina = ((System.Windows.Controls.Button)(target));
            
            #line 252 "..\..\..\..\controles\menu\MenuBar.xaml"
            this.btnAdivina.Click += new System.Windows.RoutedEventHandler(this.HandlerComun);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnChat = ((System.Windows.Controls.Button)(target));
            
            #line 253 "..\..\..\..\controles\menu\MenuBar.xaml"
            this.btnChat.Click += new System.Windows.RoutedEventHandler(this.HandlerComun);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnConfiguracion = ((System.Windows.Controls.Button)(target));
            
            #line 254 "..\..\..\..\controles\menu\MenuBar.xaml"
            this.btnConfiguracion.Click += new System.Windows.RoutedEventHandler(this.HandlerComun);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
