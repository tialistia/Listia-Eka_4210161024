using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPServer
{


    public static void Main()
    {

        byte[] data = new byte[1024];
        IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9050);
        UdpClient newsock = new UdpClient(ip);

        Console.WriteLine("Menunggu Client...");

        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        data = newsock.Receive(ref sender);

        Console.WriteLine("pesan diterima dari {0}:", sender.ToString());
        Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

        string welcome = "Selamat datang di server";
        data = Encoding.ASCII.GetBytes(welcome);
        newsock.Send(data, data.Length, sender);

        while (true)
        {


            data = newsock.Receive(ref sender);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
            newsock.Send(data, data.Length, sender);

        }

    }

}