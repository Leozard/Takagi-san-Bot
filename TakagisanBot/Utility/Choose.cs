using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace TakagisanBot.Utility
{
    public class Choose : ModuleBase<SocketCommandContext>
    {
        [Command("choose")]

        public async Task ChooseAsync([Remainder] string choices)
        {
            string[] choicesArray = choices.Split(";", StringSplitOptions.RemoveEmptyEntries);

            Random r = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int choose = r.Next(choicesArray.Length);

            await ReplyAsync($"I choose... {choicesArray[choose].TrimStart(' ').TrimEnd(' ')}!");

        }
    }
}
