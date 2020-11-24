using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPMorsekodeReceiver
{
    class Program
    {
        private const int Port = 7008;
        //private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.104.115");
        static void Main()
        {
            using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string translate = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives {0} bytes from {1} port {2}", datagramReceived.Length,
                        remoteEndPoint.Address, remoteEndPoint.Port);
                    Console.WriteLine("Translation {0}", translate);
                }
            }
        }
    }
}
