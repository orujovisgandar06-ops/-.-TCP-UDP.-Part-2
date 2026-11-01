using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 5000;

using Socket tcpsocket = new Socket(AddressFamily.InterNetwork,
                              SocketType.Stream,
                              ProtocolType.Tcp);

IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port);

tcpsocket.Bind(endPoint);

tcpsocket.Listen(10);

var clientSocket = tcpsocket.Accept();


string allMessages = "";
var buffer = new byte[1024];
int length;

while ((length = clientSocket.Receive(buffer)) > 0)
{
    string message = Encoding.UTF8.GetString(buffer, 0, length);
    Console.WriteLine(message);
    allMessages += message;
}

byte[] messageBytes = Encoding.UTF8.GetBytes(allMessages);
clientSocket.Send(messageBytes);
clientSocket.Close();