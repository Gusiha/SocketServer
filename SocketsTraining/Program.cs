using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Unicode;


string ipAddress = "10.102.3.185";
int port = 11000;
IPAddress IPAddress = IPAddress.Parse(ipAddress);
IPEndPoint endPoint = new IPEndPoint(IPAddress, port);
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(endPoint);

while (true)
{
    byte[] bytes = new byte[1024];
    string tempString = "";
    socket.Listen();
    Socket currentSocket = socket.Accept();

    Console.WriteLine("Connected to " + currentSocket.RemoteEndPoint);

    currentSocket.Receive(bytes);
    Console.WriteLine($"Message recieved from {currentSocket.RemoteEndPoint} : {Encoding.UTF8.GetString(bytes)}");

    tempString = Encoding.UTF8.GetString(bytes);


    var message = Environment.MachineName + " | " + tempString.ToUpper();
    bytes = Encoding.UTF8.GetBytes(message);
    Console.WriteLine("Data has been formatted : " + tempString.ToUpper());

    currentSocket.Send(bytes);
    Console.WriteLine("Data has been sent");
    currentSocket.Close();
    Console.WriteLine("Socket is closed");
}





//Console.WriteLine(socket.Available);

//socket.Shutdown(SocketShutdown.Both);
//socket.Close();


