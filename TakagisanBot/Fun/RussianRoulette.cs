using Discord.Addons.Interactive;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class RussianRoulette : ModuleBase<SocketCommandContext>
    {
        [Command("rr", RunMode = RunMode.Async)]

        public async Task SuicideIsBadForYourHealth()
        {
            Random r = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

            int chamber = r.Next(6);
            int bullet = r.Next(6);

            await ReplyAsync("*Inserting bullet*");

            await Task.Delay(500);

            var countdown = await ReplyAsync("3");
            await Task.Delay(400);
            await countdown.ModifyAsync(x => { x.Content = "2"; });
            await Task.Delay(400);
            await countdown.ModifyAsync(x => { x.Content = "1"; });
            await Task.Delay(400);
            await countdown.ModifyAsync(x => { x.Content = "<:gun2:464088571586805770> <:bang:464081874063458315>"; });
            await Task.Delay(500);

            if (chamber == bullet)
            {
                await ReplyAsync("You shot yourself! You lose!");
            }

            else
            {
                await ReplyAsync("You survived! You win!");
            }
        }
    }
}
