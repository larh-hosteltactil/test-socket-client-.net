using System.Net.Sockets;
using System.Net;
using System.Text;

namespace testSocketConsolaCliente
{
    public class Cliente
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket s_Server;
        Socket s_Client;

        public Cliente(string ip, int port)
        {
            Console.WriteLine("========= INICIANDO SERVER CLIENTE");
            host = Dns.GetHostByName(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr, port);

            s_Client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            s_Client.Connect(endPoint);
            Console.WriteLine("========= INICIANDO CLIENTE CONECTADO");
        }

        public void Receive()
        {
            byte[] bufffer = new byte[8192];
            string msj;
            int bytesReceived = s_Client.Receive(bufffer);
            msj = Encoding.ASCII.GetString(bufffer, 0, bytesReceived);
            Console.WriteLine("========= MSJ RECIBIDO " + msj);
        }

        public void Send(string msj)
        {
            var message = Encoding.ASCII.GetBytes(msj);
            s_Client.Send(message);
            Console.WriteLine("========= MSJ SEND " + msj);
        }
    }
}
