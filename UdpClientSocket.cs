using System.Net;
using System.Net.Sockets;
using System.Text;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

int port = 5001;

using Socket clientSocket = new Socket(AddressFamily.InterNetwork,
                              SocketType.Dgram,
                              ProtocolType.Udp);

var serverEndPoint = new IPEndPoint(IPAddress.Loopback, port);

Console.WriteLine("Введите сообщение: ");
var message = Console.ReadLine();
byte[] messageBytes = Encoding.UTF8.GetBytes(message);

clientSocket.SendTo(messageBytes, serverEndPoint);

var buffer = new byte[1024];
EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
int length = clientSocket.ReceiveFrom(buffer, ref endPoint);
string receivedMessage = Encoding.UTF8.GetString(buffer, 0, length);
Console.WriteLine($"Ответ: {receivedMessage}");