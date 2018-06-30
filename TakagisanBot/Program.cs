using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TakagisanBot
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;


        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string botToken = null;

            try
            {
                StreamReader file = new StreamReader("credentials.txt");
                Credentials data = JsonConvert.DeserializeObject<Credentials>(file.ReadToEnd());
                file.Close();

                botToken = data.SecretID;
                _client.Log += Log;

                await _client.SetGameAsync("");

                await RegisterCommandAsync();

                await _client.LoginAsync(TokenType.Bot, botToken);

                await _client.StartAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("U fuk");
                await Task.Delay(3000);
            }
            
            await Task.Delay(-1);

        }
        
        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

        }

        public async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot)
            {
                return;
            }

            int argPos = 0; //arguement position

            if (message.HasStringPrefix("--", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess)
                {
                    if (result.ErrorReason.Equals("User not found."))
                    {
                        await context.Channel.SendMessageAsync("I can't find the user you're looking for. Maybe you saw a ghost?");
                    }

                    Console.WriteLine(result.ErrorReason); //write error to console
                }
            }

            if (message.Content.Equals(@"\o\"))
            {
                var context = new SocketCommandContext(_client, message);

                await context.Channel.SendMessageAsync("/o/");
            }

            if (message.Content.Equals(@"/o/"))
            {
                var context = new SocketCommandContext(_client, message);

                await context.Channel.SendMessageAsync(@"\o\");
            }

            if (message.Content.Equals(@"\o/"))
            {
                var context = new SocketCommandContext(_client, message);

                await context.Channel.SendMessageAsync(@"\o/");
            }
        }

        public class Credentials
        {
            public string SecretID;
        }
    }    
}
