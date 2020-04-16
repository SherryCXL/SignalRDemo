using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ConsoleAppSignalR
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            GetConnection().Wait();
                
            Console.WriteLine("Hello World!");
        }

        public static async Task GetConnection()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub?token=123")
                .Build();
            
            await connection.StartAsync();
        }

    }
}
