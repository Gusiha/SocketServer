using System.Net;
using System.Net.Sockets;

int port = 9005;
IPAddress IPAddress = IPAddress.Parse("192.168.0.102");
IPEndPoint endPoint = new IPEndPoint(IPAddress, port);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(endPoint);
socket.Connect(endPoint);
socket.Listen();

Console.WriteLine(socket.Available);

socket.Shutdown(SocketShutdown.Both);
socket.Close();


