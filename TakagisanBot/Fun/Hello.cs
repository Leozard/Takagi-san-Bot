using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class Hello : ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        [Alias("hi", "ohayo")]
        
        public async Task GreetAsync(IGuildUser targetUser = null)
        {
            if (targetUser == null || targetUser == Context.Guild.GetUser(Context.Client.CurrentUser.Id))
            {
                String[] greetings =
                {
                    $"Hello there {Context.User.Username}-chan.",
                    $"Lovely weather isn't it, {Context.User.Username}.",
                    $"Oh I didn't see you there, {Context.User.Username}.",
                    $"Yahallo, {Context.User.Username}!",
                    $"It's been a while huh, {Context.User.Username}."
                };

                Random rnd = new Random();
                int greet = rnd.Next(greetings.Length);

                await ReplyAsync(greetings[greet]);
            }

            else if (targetUser == Context.User)
            {
                await ReplyAsync("Why are you greeting yourself, silly?");
            }

            else
                foreach (SocketGuildUser userSearch in Context.Guild.Users)
                {
                    if (userSearch == targetUser)
                    {                        
                        await ReplyAsync($"{userSearch.Username}, {Context.User.Username} says hi!");
                        break;
                    }
                }
        }
    }
}
