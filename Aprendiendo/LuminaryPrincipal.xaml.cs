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
using Aprendiendo.luminary;
using LuminaryFramework;

namespace Aprendiendo
{
	public partial class LuminaryPrincipal
	{
        // Administrador del chat
        luminary.chat.Administrador administradorChat;

        ControlAdivina controlAdivina;
        ControlChat controlChat;
        ControlVocabulario controlVocabulario2;
        ControlInterpreteCliente controlInterpreteCliente;

        // En el caso de la AR es especial, los modulos corren aparte y usamos un administrador para estos
        AdministradorLuminaryInterpreteAR administradorInterpreteAR;

        Configuracion configuracion;

		public LuminaryPrincipal()
		{
			this.InitializeComponent();
            new LuminarySplash().ShowDialog();
            administradorChat = new luminary.chat.Administrador();
		}

        public void Vocabulario_Click(object sender, RoutedEventArgs e)
        {
            grillaDisplay.Children.RemoveAt(0);
            liberarMemoria();
            controlVocabulario2 = new ControlVocabulario();
            grillaDisplay.Children.Insert(0, controlVocabulario2);
        }

        public void Adivina_Click(object sender, RoutedEventArgs e)
        {
            grillaDisplay.Children.RemoveAt(0);
            liberarMemoria();
            controlAdivina = new ControlAdivina();
            grillaDisplay.Children.Insert(0, controlAdivina);
        }

        public void Chat_Click(object sender, RoutedEventArgs e)
        {
            grillaDisplay.Children.RemoveAt(0);
            liberarMemoria();
            controlChat = new ControlChat();
            controlChat.administradorChat = administradorChat;
            grillaDisplay.Children.Insert(0, controlChat);
        }

        public void Interprete_Click(object sender, RoutedEventArgs e)
        {
            grillaDisplay.Children.RemoveAt(0);
            liberarMemoria();
            controlInterpreteCliente = new ControlInterpreteCliente();
            grillaDisplay.Children.Insert(0, controlInterpreteCliente);

            administradorInterpreteAR = new AdministradorLuminaryInterpreteAR(controlInterpreteCliente);
            administradorInterpreteAR.administradorChat = administradorChat;

            //controlChat = new ControlChat();
            //controlChat.administradorChat = administradorChat;
            //grillaDisplay.Children.Insert(0, controlChat);
        }

        public void Configuracion_Click(object sender, RoutedEventArgs e)
        {
            configuracion = new Configuracion();
            configuracion.DataContext = administradorChat;
            configuracion.btnConectar.Click += Conectar_Click;
            configuracion.Show();
        }

        public void Conectar_Click(object sender, RoutedEventArgs e)
        {
            administradorChat.conectar();
        }

        private void liberarMemoria() {
            if (controlVocabulario2 != null) {
                //controlVocabulario2.modelo3D.cerrar();
                controlVocabulario2.modelo3D.Exit();
            }
            if (controlAdivina != null) {
                //controlAdivina.modelo3D.cerrar();
                controlAdivina.modelo3D.Exit();
            }
            if (controlChat != null) {
                //controlChat.modelo3D.cerrar();
                controlChat.modelo3D.Exit();
                //controlChat.modelo3D2.cerrar();
                controlChat.modelo3D2.Exit();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            liberarMemoria();
            Application.Current.Shutdown();
        }

	}
}