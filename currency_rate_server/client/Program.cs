using System;
using System.Net.Sockets;
using System.Text;

class CurrencyClient
{
    static void Main()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        TcpClient client = new TcpClient("127.0.0.1", 5050);
        NetworkStream stream = client.GetStream();

        string loginData = $"{username}:{password}";
        byte[] loginBytes = Encoding.UTF8.GetBytes(loginData);
        stream.Write(loginBytes, 0, loginBytes.Length);

        byte[] authBuffer = new byte[1024];
        int authBytesRead = stream.Read(authBuffer, 0, authBuffer.Length);
        string authResponse = Encoding.UTF8.GetString(authBuffer, 0, authBytesRead);
        Console.WriteLine($"Auth response: {authResponse}");

        if (authResponse != "Authentication successful.")
        {
            Console.WriteLine("Access denied.");
            client.Close();
            return;
        }

        while (true)
        {
            Console.Write("Enter two currencies (e.g. USD/EUR) or 'q' to quit: ");
            string request = Console.ReadLine();

            if (request.ToLower() == "q") break;

            byte[] data = Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Response: {response}");
        }

        client.Close();
    }
}
