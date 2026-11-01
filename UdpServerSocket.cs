using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 5001;

using Socket udpsocket = new Socket(AddressFamily.InterNetwork,
                              SocketType.Dgram,
                              ProtocolType.Udp);

IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port);

udpsocket.Bind(endPoint);

var buffer = new byte[1024];
EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

int length = udpsocket.ReceiveFrom(buffer, ref clientEndPoint);
string message = Encoding.UTF8.GetString(buffer, 0, length);
Console.WriteLine(message);

udpsocket.SendTo(buffer, length, SocketFlags.None, clientEndPoint);