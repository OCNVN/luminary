using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net;
using System.Windows;

namespace Luminary_Chat_AR.comunicacion
{
    public class Administrador : INotifyPropertyChanged
    {
        //Controladores que manejan los sockets para cliente o servidor
        public Servidor servidor;
        public Cliente cliente;

        private String _ipServidor;
        public String ipServidor
        {
            get { return _ipServidor; }
            set
            {
                _ipServidor = value;
                OnPropertyChanged("ipServidor");
            }
        }

        private String _puertoServidor;
        public String puertoServidor
        {
            get { return _puertoServidor; }
            set
            {
                _puertoServidor = value;
                OnPropertyChanged("puertoServidor");
            }
        }

        private Boolean _esServidor;
        public Boolean esServidor
        {
            get { return _esServidor; }
            set
            {
                _esServidor = value;
                if (value)
                    esCliente = false;
                OnPropertyChanged("esServidor");
            }
        }

        private Boolean _esCliente;
        public Boolean esCliente
        {
            get { return _esCliente; }
            set
            {
                _esCliente = value;
                if (value)
                    esServidor = false;
                OnPropertyChanged("esCliente");
            }
        }

        private Boolean _estaConectado;
        public Boolean estaConectado
        {
            get { return _estaConectado; }
            set
            {
                _estaConectado = value;
                OnPropertyChanged("estaConectado");
            }
        }

        /// <summary>
        /// Constructor pone por default la ip del servidor la del localhost
        /// el puerto 8000 y por default la propiedad "esServidor" en TRUE
        /// </summary>
        public Administrador()
        {
            this.esServidor = true;
            this.ipServidor = GetIP();
            this.puertoServidor = "8000";
            this.estaConectado = false;
        }

        public void enviarMensaje(String mensaje)
        {
            Console.WriteLine("ENVIANDO MIRA VE {0}", mensaje);
            if (servidor == null && cliente == null)
                conectar();

            if (servidor != null)
            {
                byte[] porDato = System.Text.Encoding.ASCII.GetBytes(mensaje.ToString());
                for (int i = 0; i < servidor.conteoClientes; i++)
                {
                    if (servidor.socketsClientes[i] != null)
                    {
                        if (servidor.socketsClientes[i].Connected)
                        {
                            servidor.socketsClientes[i].Send(porDato);
                        }
                    }
                }
            }
            else if (cliente != null)
            {
                try
                {
                    byte[] porDato = System.Text.Encoding.ASCII.GetBytes(mensaje.ToString());
                    if (cliente.socketCliente != null)
                    {
                        cliente.socketCliente.Send(porDato);
                    }
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }

        }

        public void desconectar()
        {
            servidor = null;
            cliente = null;
        }

        public void conectar()
        {
            if (esServidor)
                hacerServidor();
            else if (esCliente)
                hacerCliente();
        }

        private void hacerServidor()
        {
            cliente = null;
            try
            {
                int puerto = Convert.ToInt32(puertoServidor);
                servidor = new Servidor();

                servidor.socketPrincipal = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, puerto);
                servidor.socketPrincipal.Bind(ipLocal);
                servidor.socketPrincipal.Listen(4);
                servidor.socketPrincipal.BeginAccept(new AsyncCallback(servidor.OnClienteConectado), null);
                /*
                if(servidor.socketPrincipal.Connected){
                    Console.WriteLine("El servidor esta conectado !! ");
                    estaConectado = true;
                }else{
                    Console.WriteLine("El servidor no se pudo conectar !! ");
                    estaConectado = false;
                }
                */
                Console.WriteLine("El servidor esta conectado !! ");
                estaConectado = true;
                //servidor.LetraRecibida += new LetraRecibidaEventHandler(LetraRecibida);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                Console.WriteLine("El servidor no se pudo conectar !! ");
                estaConectado = false;
            }
        }

        private void hacerCliente()
        {
            servidor = null;
            try
            {
                IPAddress ip = IPAddress.Parse(ipServidor);
                int puerto = Convert.ToInt32(puertoServidor);
                IPEndPoint ipEnd = new IPEndPoint(ip, puerto);
                cliente = new Cliente();
                cliente.socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                cliente.socketCliente.Connect(ipEnd);
                if (cliente.socketCliente.Connected)
                    cliente.EsperarPorDatos();
                //cliente.LetraRecibida += new LetraRecibidaEventHandler(LetraRecibida);
                estaConectado = true;
            }
            catch (SocketException se)
            {
                string str;
                str = "\nConexion fallida, talves el servidor no esta corriendo?\n" + se.Message;
                MessageBox.Show(str);
                estaConectado = false;
            }
        }

        private String GetIP()
        {
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propiedadNombre)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedadNombre));
            }
        }
    }
}
