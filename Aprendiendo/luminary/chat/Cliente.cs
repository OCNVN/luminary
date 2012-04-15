using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Aprendiendo.luminary.chat
{
    public class Cliente
    {
        public event LetraRecibidaEventHandler LetraRecibida;

        byte[] bufferDatos = new byte[10];
        IAsyncResult resultado;
        public AsyncCallback pfnCallback;
        public Socket socketCliente;

        private String _letraLLega;
        public String letraLLega {
            get { return _letraLLega; }
            set { _letraLLega = value; }
        }

        public void EsperarPorDatos()
        {
            try
            {
                if (pfnCallback == null)
                    pfnCallback = new AsyncCallback(OnDatoRecibido);
                PaqueteSocket paquete = new PaqueteSocket();
                paquete.esteSocket = socketCliente;

                resultado = socketCliente.BeginReceive(paquete.bufferDatos,
                    0, paquete.bufferDatos.Length,
                    SocketFlags.None,
                    pfnCallback,
                    paquete);

            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        public void OnDatoRecibido(IAsyncResult asyn)
        {
            try
            {
                PaqueteSocket paquete = (PaqueteSocket)asyn.AsyncState;
                int iRx = paquete.esteSocket.EndReceive(asyn);
                char[] caracteres = new char[iRx];
                Decoder d = Encoding.UTF8.GetDecoder();
                int longitudCar = d.GetChars(paquete.bufferDatos, 0, iRx, caracteres, 0);
                String szDato = new String(caracteres);
                letraLLega = new String(caracteres);
                // Creo los argumentos que se pasan cuando se lanza el evento LetraRecibida
                Console.WriteLine("RECIBI POR EL SOCKET {0}", letraLLega);
                LetraRecibidaEventArgs letraRecibidaEventArgs = new LetraRecibidaEventArgs();
                letraRecibidaEventArgs.letraRecibida = letraLLega;
                int numeroAnimacion;
                if (VariablesConfiguracion.letrasNumeros.TryGetValue(letraLLega, out numeroAnimacion))
                    letraRecibidaEventArgs.numeroAnimacion = numeroAnimacion;
                else
                    Console.WriteLine("NO SE PUEDE ENCONTRAR LA ANIMACION " + letraLLega);

                LetraRecibida(this, letraRecibidaEventArgs);
                EsperarPorDatos();
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
            public Socket esteSocket;
            public byte[] bufferDatos = new byte[1];
        }
    }
}
