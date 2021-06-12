using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aprendiendo.luminary;
using Aprendiendo.luminary.chat;
using Aprendiendo.luminary.comun;
using Luminary_Chat_AR;

namespace Aprendiendo
{
    public class AdministradorAR
    {
        LuminaryChatAR luminaryChat;
    }

    public class AdministradorLuminaryInterpreteAR{
        LuminaryChatAR luminaryChatAR;

        ControlInterpreteCliente controlInterpreteCliente;
        
        private Administrador _administradorChat;
        public Administrador administradorChat
        {
            set
            {
                _administradorChat = value;
                if (_administradorChat.servidor != null)
                {
                    _administradorChat.servidor.LetraRecibida += new LetraRecibidaEventHandler(LetraRecibidaServidor);
                    IniciarServidor();
                }
                if (_administradorChat.cliente != null)
                {
                    _administradorChat.cliente.LetraRecibida += new LetraRecibidaEventHandler(LetraRecibidaCliente);
                }
            }
        }

        public AdministradorLuminaryInterpreteAR(ControlInterpreteCliente _controlInterpreteCliente) {
            controlInterpreteCliente = _controlInterpreteCliente;
            controlInterpreteCliente.textoAEnviar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(manejadorCambiaTexto);
        }

        public void IniciarServidor() {
            luminaryChatAR = new Luminary_Chat_AR.LuminaryChatAR();
            luminaryChatAR.Run();
        }

        public void manejadorCambiaTexto(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Console.WriteLine("Cambia el texto " + ((System.Windows.Controls.TextBox)e.OriginalSource).Text);
            _administradorChat.enviarMensaje(((System.Windows.Controls.TextBox)e.OriginalSource).Text);
            ((System.Windows.Controls.TextBox)e.OriginalSource).Text = "";
        }

        String textoRecibido = "";
        List<String> textoRecibidoArray = new List<String>();
        private void LetraRecibidaServidor(object sender, LetraRecibidaEventArgs e)
        {
            if (e.numeroAnimacion != null)
            {
                // modelo3D2._listaAnimacionesLetras.Add(e.numeroAnimacion);
                Console.WriteLine("ALGO ASI NO SE AUN " + e.letraRecibida);
                if (e.letraRecibida.CompareTo(" ") == 0)
                {// indica el termino de una palabra
                    Console.WriteLine("SON IGUALES");
                    if (textoRecibido.CompareTo("hola") == 0) {
                        luminaryChatAR._listaAnimacionesLetras.Add("hola");
                        textoRecibido = "";
                        textoRecibidoArray = new List<string>();
                    }else if (textoRecibido.CompareTo("como") == 0)
                    {
                        luminaryChatAR._listaAnimacionesLetras.Add("como");
                        textoRecibido = "";
                        textoRecibidoArray = new List<string>();
                    }
                    else if (textoRecibido.CompareTo("estas") == 0)
                    {
                        luminaryChatAR._listaAnimacionesLetras.Add("estas");
                        textoRecibido = "";
                        textoRecibidoArray = new List<string>();
                    }
                    else {
                        textoRecibido = "";
                        textoRecibidoArray = new List<string>();
                    }
                }
                else {
                    textoRecibido = textoRecibido + e.letraRecibida;
                    textoRecibidoArray.Add(e.letraRecibida);
                    Console.WriteLine("AUMENTO : " + textoRecibido);
                }
            }
            else
                Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION " + e.letraRecibida);
        }

        private void LetraRecibidaCliente(object sender, LetraRecibidaEventArgs e)
        {
            if (e.numeroAnimacion != null)
            {
                //modelo3D2._listaAnimacionesLetras.Add(e.numeroAnimacion);
                Console.WriteLine("ALGO ASI NO SE AUN");
            }
            else
                Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION CLIENTE " + e.letraRecibida);
        }
    }
}
