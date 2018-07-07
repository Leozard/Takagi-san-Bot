using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class RPS : ModuleBase<SocketCommandContext>
    {
        Random rnd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

        [Command("rps")]

        public async Task RPSAsync([Remainder] string rpsUser = null)
        {
            string[] rpsList = { "rock", "paper", "scissors" };
            int i = rnd.Next(3);

            string rpsBot = rpsList[i];

            if (rpsUser is null)
                await ReplyAsync("Are you waiting for me to go first? That's cheating!");

            else
            {
                if (rpsUser.Contains(" "))
                    rpsUser = rpsUser.Substring(0, rpsUser.IndexOf(" "));

                switch (rpsUser)
                {
                    case "rock":
                    case "r":
                        if (rpsBot == "rock")
                            await ReplyAsync("I chose ``rock``, it's a draw!");

                        else if (rpsBot == "paper")
                            await ReplyAsync("I chose ``paper``, you lose!");

                        else if (rpsBot == "scissors")
                            await ReplyAsync("I chose ``scissors``, you win!");
                        break;

                    case "paper":
                    case "p":
                        if (rpsBot == "rock")
                            await ReplyAsync("I chose ``rock``, you win!");

                        else if (rpsBot == "paper")
                            await ReplyAsync("I chose ``paper``, it's a draw!");

                        else if (rpsBot == "scissors")
                            await ReplyAsync("I chose ``scissors``, you lose!");
                        break;

                    case "scissors":
                    case "s":
                        if (rpsBot == "rock")
                            await ReplyAsync("I chose ``rock``, you lose!");

                        else if (rpsBot == "paper")
                            await ReplyAsync("I chose ``paper``, you win!");

                        else if (rpsBot == "scissors")
                            await ReplyAsync("I chose ``scissors``, it's a draw!");
                        break;

                    default:
                        await ReplyAsync("That's not one of the options, silly.");
                        break;
                }
            }
        }
    }
}
