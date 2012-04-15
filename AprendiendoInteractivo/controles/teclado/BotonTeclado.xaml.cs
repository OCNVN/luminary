using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Aprendiendo.controles.teclado
{
	public partial class BotonTeclado
	{
		public BotonTeclado()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}

        public static readonly DependencyProperty textoDependency =
            DependencyProperty.Register("texto", typeof(String), typeof(BotonTeclado),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(cambia)));

        public String texto {
            get { return (String)GetValue(textoDependency); }
            set { SetValue(textoDependency, value); }
        }

        public static void cambia(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            (sender as BotonTeclado).updateTexto(args.NewValue.ToString());
        }

        public void updateTexto(String texto) {
            boton.Content = texto;
        }
	}
}