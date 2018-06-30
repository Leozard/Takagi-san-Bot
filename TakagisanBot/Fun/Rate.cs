using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class Rate : ModuleBase<SocketCommandContext>
    {
        Random rnd = new Random();


        [Command("rate")]

        public async Task RateAsync([Remainder] string rate)
        {
            int rating = rate.GetHashCode();

            if (rate.ToLower() == "takagi" || rate.ToLower() == "takagi-san" || rate == $"<@{Context.Client.CurrentUser.Id}>")
                await ReplyAsync("I'd rate myself an 11/10, *teehee*!");

            else if (rate == $"<@{Context.Guild.GetUser(Context.User.Id).Id}>")
                await ReplyAsync("I'd rate you a 10/10!");

            else
            {
                foreach (var user in Context.Guild.Users)
                {
                    if ($"<@{user.Id.ToString()}>" == rate)
                    {
                        rate = user.Username;
                        break;
                    }
                }
                await ReplyAsync($"I'd give {rate} a {(rating*10 & 0x7fffffff) % 11}/10!");
            }
        }
    }
}
