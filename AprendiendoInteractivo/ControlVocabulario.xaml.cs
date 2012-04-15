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
using Aprendiendo.luminary;
using Aprendiendo.controles.teclado;

namespace Aprendiendo
{
    /// <summary>
    /// Interaction logic for ControlVocabulario.xaml
    /// </summary>
    public partial class ControlVocabulario : UserControl
    {
        Vocabulario vocabulario;
        public ControlVocabulario()
        {
            InitializeComponent();
            vocabulario = new Vocabulario();
            //txtIngresar.DataContext = vocabulario;
            //imageSenas.DataContext = vocabulario;
            //vocabulario.CambioLetra += new CambioLetraEventHandler(CambioLaLetra);
        }

        private void btnTraducir_Click(object sender, RoutedEventArgs e)
        {
            //vocabulario.traducir();
            Console.WriteLine("TEXTO " + vocabulario.textoFrase);

            RoutedEventArgs ea = new RoutedEventArgs();
            ea.RoutedEvent = TraducirEvent;
            RaiseEvent(ea);
        }

        private void btnTeclado_Click(object sender, RoutedEventArgs e)
        {
            //vocabulario.textoFrase += ((Teclado)sender).letraActualOprimida;
            String nuevoTexto = txtIngresar.Text + ((Teclado)sender).letraActualOprimida;
            txtIngresar.Text = nuevoTexto;
            //juego.enviarLetra(((Teclado)sender).letraActualOprimida);
        }

        //private void CambioLaLetra(object sender, EventArgs e)
        //{
        //    Console.WriteLine("DICE QUE CAMBIA DESDE EL EVENTO MIRA VE "+((Vocabulario) sender).imageRef);
        //}

        // Eventos del control

        public static RoutedEvent TraducirEvent =
            EventManager.RegisterRoutedEvent("Traducir", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(ControlVocabulario));

        public event RoutedEventHandler Traducir{
            add { AddHandler(TraducirEvent, value); }
            remove { RemoveHandler(TraducirEvent, value); }
        }
    }
}
