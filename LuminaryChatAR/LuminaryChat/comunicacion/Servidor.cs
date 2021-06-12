using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace LuminaryChat.comunicacion
{
    /// <summary>
    /// Objeto para establecer el manejador evento que se lanzara cuando una letra
    /// llegue de determinado cliente
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="ea"></param>
    public delegate void LetraRecibidaEventHandler(object sender, LetraRecibidaEventArgs ea);

    /// <summary>
    /// Argumentos para cuando se recibe una letra a travez de la red
    /// </summary>
    public class LetraRecibidaEventArgs : EventArgs
    {
        private String _letraRecibida;
        public String letraRecibida
        {
            get { return _letraRecibida; }
            set { _letraRecibida = value; }
        }

        private int _numeroAnimacion;
        public int numeroAnimacion
        {
            get { return _numeroAnimacion; }
            set { _numeroAnimacion = value; }
        }

        public LetraRecibidaEventArgs()
            : base()
        {

        }
    }

    public class Servidor
    {
        public event LetraRecibidaEventHandler LetraRecibida;

        private const int NUM_MAX_CLI = 10;

        public AsyncCallback pfnWorkerCallback;
        public Socket socketPrincipal;
        public Socket[] socketsClientes = new Socket[NUM_MAX_CLI];
        public int conteoClientes = 0;

        private String _letraLLega;
        /// <summary>
        /// Almacena la letra recibida atravez de la red
        /// </summary>
        public String letraLLega
        {
            get { return _letraLLega; }
            set { _letraLLega = value; }
        }

        /// <summary>
        /// Evento asincrono que se lanza cuando un cliente se conecta
        /// al servidor, prepara al socket del cliente conectado para 
        /// que empieze a esperar por datos 
        /// </summary>
        /// <param name="asyn"></param>
        public void OnClienteConectado(IAsyncResult asyn)
        {
            try
            {
                socketsClientes[conteoClientes] = socketPrincipal.EndAccept(asyn);
                EsperarPorDatos(socketsClientes[conteoClientes]);
                ++conteoClientes;
                Console.WriteLine("CLIENTES CONECTADOS " + conteoClientes);

                socketPrincipal.BeginAccept(new AsyncCallback(OnClienteConectado), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        /// <summary>
        /// Establece la llamada asincrona para empezar a esperar por datos 
        /// Que lleguen de determinado cliente
        /// </summary>
        /// <param name="socket">El socket por el que se va a escuchar por 
        /// datos que este envie
        /// </param>
        public void EsperarPorDatos(Socket socket)
        {
            try
            {
                if (pfnWorkerCallback == null)
                    pfnWorkerCallback = new AsyncCallback(OnDatoRecibido);
                PaqueteSocket paquete = new PaqueteSocket();
                paquete.socketActual = socket;

                socket.BeginReceive(paquete.bufferDatos,
                    0,
                    paquete.bufferDatos.Length,
                    SocketFlags.None,
                    pfnWorkerCallback,
                    paquete);
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        /// <summary>
        /// Evento que se lanza cuando un dato es recibido de determinado cliente
        /// </summary>
        /// <param name="asyn"></param>
        public void OnDatoRecibido(IAsyncResult asyn)
        {
            try
            {
                PaqueteSocket datosSocket = (PaqueteSocket)asyn.AsyncState;
                int iRx = 0;
                iRx = datosSocket.socketActual.EndReceive(asyn);
                char[] caracteres = new char[iRx];
                Decoder d = Encoding.UTF8.GetDecoder();
                int longitudChar = d.GetChars(datosSocket.bufferDatos, 0, iRx, caracteres, 0);
                String szDato = new String(caracteres);
                letraLLega = new String(caracteres);
                Console.WriteLine("RECIBI LA LETRA " + letraLLega);
                // Creo los argumentos que se pasan cuando se lanza el evento LetraRecibida
                LetraRecibidaEventArgs letraRecibidaEventArgs = new LetraRecibidaEventArgs();
                letraRecibidaEventArgs.letraRecibida = letraLLega;
                int numeroAnimacion;
                if (VariablesConfiguracion.letrasNumeros.TryGetValue(letraLLega, out numeroAnimacion))
                    letraRecibidaEventArgs.numeroAnimacion = numeroAnimacion;
                else
                    Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION " + letraLLega);
                if (this == null || letraRecibidaEventArgs == null)
                    Console.WriteLine("PORQUE MIERCOLES ES NULL THIS: " + this + ", args: " + letraRecibidaEventArgs);
                LetraRecibida(this, letraRecibidaEventArgs);
                EsperarPorDatos(datosSocket.socketActual);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        public class PaqueteSocket
        {
            public Socket socketActual;
            public byte[] bufferDatos = new byte[1];
        }
    }
}
