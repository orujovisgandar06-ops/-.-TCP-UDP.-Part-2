using System.Net;
using System.Net.Sockets;
using System.Text;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

int port = 5000;

using Socket clientSocket = new Socket(AddressFamily.InterNetwork,
                              SocketType.Stream,
                              ProtocolType.Tcp);

var Ipendpoint = new IPEndPoint(IPAddress.Loopback, port);
clientSocket.Connect(Ipendpoint);

while (true)
{
    Console.WriteLine("Введите сообщение: ");
    var message = Console.ReadLine();
    if (message == "") break;
    byte[] messageBytes = Encoding.UTF8.GetBytes(message + "\n");
    clientSocket.Send(messageBytes);
}
clientSocket.Shutdown(SocketShutdown.Send);
var buffer = new byte[1024];
int length = clientSocket.Receive(buffer);
string receivedMessage = Encoding.UTF8.GetString(buffer, 0, length);
Console.WriteLine($"Ответ: { receivedMessage } ");