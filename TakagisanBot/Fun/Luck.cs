using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class Luck : ModuleBase<SocketCommandContext>
    {
        [Command("luck")]

        public async Task LuckAsync([Remainder] string placeholder = null)
        {
            Random rnd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int luck = rnd.Next(101);

            if (luck == 0)
                await ReplyAsync($"Oh no, you have {luck}%. Stay safe {Context.User.Username}!");

            else if (luck >= 1 && luck <= 24)
                await ReplyAsync($"Your luck is {luck}%. You better be careful.");

            else if (luck >= 25 && luck <= 49)
                await ReplyAsync($"Your luck is {luck}%, which is below average...");

            else if (luck >= 50 && luck <= 74)
                await ReplyAsync($"Your luck is {luck}%, which is above average!");

            else if (luck >= 75 && luck <= 99)
                await ReplyAsync($"Your luck is {luck}%. You have excellent luck!");

            else
                await ReplyAsync($"Your luck is {luck}%, maybe you'll get a critical hit!");
        }
    }
}
