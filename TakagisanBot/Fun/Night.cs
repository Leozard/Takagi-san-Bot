using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class Night : ModuleBase<SocketCommandContext>
    {
        [Command("night")]
        [Alias("oyasumi")]

        public async Task NightAsync()
        {
            string[] nightArray =
            {
                "Oyasumi,",
                "Sweet dreams,",
                "See ya,",
                "Good night",
                "Have a good rest"
            };

            Random r = new Random();
            int i = r.Next(nightArray.Length);

            await ReplyAsync($"{nightArray[i]} {Context.User.Username}!");
        }
    }
}
