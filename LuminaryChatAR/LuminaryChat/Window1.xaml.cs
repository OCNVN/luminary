using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Luminary_Chat_AR.comunicacion;

namespace LuminaryChat
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Administrador administradorConexion;

        public Window1()
        {
            InitializeComponent();
            administradorConexion = new Administrador();
        }

        private void textoATransmitir_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(((TextBox)e.Source).Text);
        }
    }
}
