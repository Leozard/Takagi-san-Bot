using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class FlipCoin : ModuleBase<SocketCommandContext>
    {
        Random rnd = new Random();


        [Command("flipcoin")]

        public async Task FlipCoinAsync([Remainder] string placeholder = null)
        {
            int coin = rnd.Next(101);

            if (coin % 2 == 0 && coin != 0)
            {
                await ReplyAsync("You got ``heads``, but you will never be ahead of me.");
            }

            else if (coin % 2 == 1 && coin != 0)
            {
                await ReplyAsync("You got ``tails``, like my tail that you always chase after.");
            }

            else if (coin == 0)
            {
                await ReplyAsync($"Oh, it landed on the center. Are you sure you didn't rig it, {Context.User.Mention}-kun?");
            }
        }
    }
}
