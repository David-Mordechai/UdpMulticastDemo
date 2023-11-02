using System.Net.Sockets;
using System.Net;
using System.Text;

const int port = 12345;
const string multiCastAddress = "239.0.0.1";

using var udpClient = new UdpClient();
udpClient.JoinMulticastGroup(IPAddress.Parse(multiCastAddress), 50);
var endPoint = new IPEndPoint(IPAddress.Parse(multiCastAddress), port);

while (true)
{
    const string message = "Hello from sender";
    var data = Encoding.UTF8.GetBytes(message);
    udpClient.Send(data, data.Length, endPoint);
    Console.WriteLine($"Sent: {message}");
    Thread.Sleep(1000); // Send a message every second
}