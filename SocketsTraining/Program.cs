using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Unicode;

byte[] bytes = new byte[256];

int port = 3245;
IPAddress IPAddress = IPAddress.Parse("192.168.0.105");
IPEndPoint endPoint = new IPEndPoint(IPAddress, port);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(endPoint);
socket.Listen();
socket.Accept();
socket.Receive(bytes);


while (!bytes.Any())
{
    //Console.WriteLine(socket.IsBound);
}

Console.WriteLine(Encoding.UTF8.GetString(bytes));

//Console.WriteLine(socket.Available);

//socket.Shutdown(SocketShutdown.Both);
//socket.Close();


