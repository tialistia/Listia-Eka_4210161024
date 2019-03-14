using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UdpClientSample
{
    public static void Main()
    {
        byte[] data = new byte[1024];
        string input, stringData;
        UdpClient server = new UdpClient("192.168.43.181", 9050);

        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        string welcome = "Hallo";
        data = Encoding.ASCII.GetBytes(welcome);
        server.Send(data, data.Length);

        data = server.Receive(ref sender);

        Console.WriteLine("pesan diterima dari {0}:", sender.ToString());
        stringData = Encoding.ASCII.GetString(data, 0, data.Length);


        while (true)
        {
            input = Console.ReadLine();
            if (input == "exit")
                break;

            server.Send(Encoding.ASCII.GetBytes(input), input.Length);
            data = server.Receive(ref sender);
            stringData = Encoding.ASCII.GetString(data, 0, data.Length);

        }
        Console.WriteLine("Stopping client");
        server.Close();
    }
}

