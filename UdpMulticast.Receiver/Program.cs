using System.Net.Sockets;
using System.Net;
using System.Text;

const int port = 12345;
const string multiCastAddress = "239.0.0.1";

using var udpClient = new UdpClient(port);
udpClient.JoinMulticastGroup(IPAddress.Parse(multiCastAddress));

var endPoint = new IPEndPoint(IPAddress.Any, port);

while (true)
{
    var receivedData = udpClient.Receive(ref endPoint);
    var message = Encoding.UTF8.GetString(receivedData);
    Console.WriteLine($"Received: {message}");
}