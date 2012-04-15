using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Net.Sockets;
using Aprendiendo.luminary;
using Aprendiendo.luminary.chat;
using Aprendiendo.luminary.comun;
using Aprendiendo.controles.teclado;
using System.ComponentModel;

namespace Aprendiendo
{
	/// <summary>
	/// Interaction logic for ControlChat.xaml
	/// </summary>
	public partial class ControlChat : UserControl
	{
        private Administrador _administradorChat;
        public Administrador administradorChat {
            set { 
                _administradorChat = value;
                if (_administradorChat.servidor != null)
                    _administradorChat.servidor.LetraRecibida += new LetraRecibidaEventHandler(LetraRecibidaServidor);
                if (_administradorChat.cliente != null)
                    _administradorChat.cliente.LetraRecibida += new LetraRecibidaEventHandler(LetraRecibidaCliente);
                // Para que las grillas modales se activen o desactiven dependiendo de de
                // si el administrador esta conectado o no
                yoConectadoModal.DataContext = value;
                elOtroConectadoModal.DataContext = value;
                DataContext = value;
            }
        }
        
		public ControlChat()
		{
			this.InitializeComponent();

            controles3D.DataContext = modelo3D;
            controles3D1.DataContext = modelo3D2;
		}
        
        private void btnTeclado_Click(object sender, RoutedEventArgs e)
        {
            _administradorChat.enviarMensaje(((Teclado)sender).letraActualOprimida);
            int numeroAnimacion;
            if (VariablesConfiguracion.letrasNumeros.TryGetValue(((Teclado)sender).letraActualOprimida, out numeroAnimacion))
                modelo3D._listaAnimacionesLetras.Add(numeroAnimacion);
            else
                Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION " + ((Teclado)sender).letraActualOprimida);
        }
        
        #region Notificacion de cambio de propiedades para data binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propiedadNombre)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedadNombre));
            }
        }
        #endregion


        private void LetraRecibidaServidor(object sender, LetraRecibidaEventArgs e)
        {
            if ( e.numeroAnimacion != null )
                modelo3D2._listaAnimacionesLetras.Add(e.numeroAnimacion);
            else
                Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION " + e.letraRecibida);
        }

        private void LetraRecibidaCliente(object sender, LetraRecibidaEventArgs e)
        {
            if ( e.numeroAnimacion != null )
                modelo3D2._listaAnimacionesLetras.Add(e.numeroAnimacion);
            else
                Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION CLIENTE " + e.letraRecibida);
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            Frase procesaFrase = new Frase(txtMensaje.Text);
            System.Collections.Generic.List<String> senalesLetraRutas = new System.Collections.Generic.List<String>();
            int indice = 0;

            for (int i = 0; i < procesaFrase.palabras.Length; i++)
            {
                int numeroAnimacion;
                VariablesConfiguracion.letrasNumeros.TryGetValue(
                    procesaFrase.palabras[i].palabra,
                    out numeroAnimacion);
                Console.WriteLine("Probanle la palabra {0} = {1} ",
                    procesaFrase.palabras[i].palabra, numeroAnimacion);
                if (numeroAnimacion == 0)
                {
                    for (int j = 0; j < procesaFrase.palabras[i].letras.Length; j++)
                    {
                        int numeroAnimacionLetra;
                        if (VariablesConfiguracion.letrasNumeros.TryGetValue(procesaFrase.palabras[i].letras[j].caracter + "", out numeroAnimacionLetra))
                        {
                            modelo3D._listaAnimacionesLetras.Add(numeroAnimacionLetra);
                            _administradorChat.enviarMensaje(procesaFrase.palabras[i].letras[j].caracter + "");
                            //modelo3D2._listaAnimacionesLetras.Add(numeroAnimacion);
                        }
                    }
                }
                else
                {
                    modelo3D._listaAnimacionesLetras.Add(numeroAnimacion);
                    _administradorChat.enviarMensaje(procesaFrase.palabras[i].palabra + "");
                }
            }
            //animar();
            //Console.WriteLine("EXISTEN {0} LETRAS ", senalesImagenesRutas.Count);





            //String mensaje = txtMensaje.Text;
            //char [] arrayMensajeChar = mensaje.ToCharArray();
            //for (int i = 0; i < arrayMensajeChar.Length; i++) {
            //    int numeroAnimacion;
            //    if (VariablesConfiguracion.letrasNumeros.TryGetValue(arrayMensajeChar[i] + "", out numeroAnimacion))
            //    {
            //        modelo3D._listaAnimacionesLetras.Add(numeroAnimacion);
            //        _administradorChat.enviarMensaje(arrayMensajeChar[i] + "");
            //        //modelo3D2._listaAnimacionesLetras.Add(numeroAnimacion);
            //    }
            //    else
            //        Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION " + ((Teclado)sender).letraActualOprimida);
            //}
        }
	}
}