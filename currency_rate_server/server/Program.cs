using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

class CurrencyServer
{
    static Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
    {
        {"USD/EUR", 0.93m},
        {"EUR/USD", 1.08m},
        {"USD/UAH", 39.50m},
        {"UAH/USD", 0.025m},
        {"USD/RUB", 89.00m},
        {"RUB/USD", 0.011m}
    };

    static Dictionary<string, string> validUsers = new Dictionary<string, string>
    {
        {"user1", "password123"},
        {"admin", "securepass"},
        {"guest", "guestpass"}
    };

    static int maxClients = 3;
    static HashSet<string> activeClients = new HashSet<string>();

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5050);
        server.Start();
        Console.WriteLine("Server started...");

        while (true)
        {
            if (activeClients.Count >= maxClients)
            {
                Console.WriteLine("Server is at maximum capacity.");
                TcpClient tempClient = server.AcceptTcpClient();
                NetworkStream tempStream = tempClient.GetStream();
                byte[] limitMessage = Encoding.UTF8.GetBytes("Server is under maximum load. Try again later.");
                tempStream.Write(limitMessage, 0, limitMessage.Length);
                tempClient.Close();
                continue;
            }

            TcpClient client = server.AcceptTcpClient();
            string clientIP = client.Client.RemoteEndPoint.ToString();

            Console.WriteLine($"Client {clientIP} connected.");
            activeClients.Add(clientIP);

            NetworkStream stream = client.GetStream();

            byte[] loginBuffer = new byte[1024];
            int loginBytesRead = stream.Read(loginBuffer, 0, loginBuffer.Length);
            string loginData = Encoding.UTF8.GetString(loginBuffer, 0, loginBytesRead).Trim();
            string[] credentials = loginData.Split(':');

            if (credentials.Length < 2 || !validUsers.ContainsKey(credentials[0]) || validUsers[credentials[0]] != credentials[1])
            {
                byte[] authFailedMessage = Encoding.UTF8.GetBytes("Invalid username or password.");
                stream.Write(authFailedMessage, 0, authFailedMessage.Length);
                client.Close();
                activeClients.Remove(clientIP);
                continue;
            }

            byte[] authSuccessMessage = Encoding.UTF8.GetBytes("Authentication successful.");
            stream.Write(authSuccessMessage, 0, authSuccessMessage.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            string response = exchangeRates.ContainsKey(request) ? exchangeRates[request].ToString() : "not found";

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);

            Console.WriteLine($"Client {clientIP}\nRequest: {request}\nResponse: {response}");

            client.Close();
            activeClients.Remove(clientIP);
        }
    }
}
