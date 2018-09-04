using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Penguu
{
    class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            var client = new DiscordSocketClient();
            client.Log += Log;

            client.MessageReceived += MessageReceived;

            string token = "NDg2Mzk5MDAyNTkwNDQ1NTY4.Dm-iHg.JgYbltZghGCkRXxrbxS-s5WlHqw";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            // Block the task until the program is closed
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
        }
    }
}
