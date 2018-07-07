using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace TakagisanBot.Games
{
    public class SlotMachine : ModuleBase<SocketCommandContext>
    {
        [Command("slot", RunMode = RunMode.Async)]

        public async Task Slot()
        {
            string[] slotIcons =
            {
                ":tada:",
                ":heart:",
                ":izakaya_lantern:",
                ":sunny:",
                ":turkey:",
                ":christmas_tree:"
            };

            Random num = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int icon1 = num.Next(slotIcons.Length);
            int icon2 = num.Next(slotIcons.Length);
            int icon3 = num.Next(slotIcons.Length);

            string result;

            if ((slotIcons[icon1] == slotIcons[icon2]) && (slotIcons[icon2] == slotIcons[icon3]))
            {
                result = "You won!";
            }
            else
            {
                result = "You lost!";
            }

            var mes = await ReplyAsync(
                $" ---- **SLOTS** -----\n\n" +
                $"\t{slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}\n\n" +
                $"**>** {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}\n\n" +
                $"\t{slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}");

            await Task.Delay(600);

            await mes.ModifyAsync(x => 
            {
                x.Content =
                $" ---- **SLOTS** -----\n\n" +
                $"\t{slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}\n\n" +
                $"**>** {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}\n\n" +
                $"\t{slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}";
            });

            await Task.Delay(600);

            await mes.ModifyAsync(x =>
            {
                x.Content =
                $" ---- **SLOTS** -----\n\n" +
                $"\t{slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}\n\n" +
                $"**>** {slotIcons[icon1]} - {slotIcons[icon2]} - {slotIcons[icon3]}\n\n" +
                $"\t{slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]} - {slotIcons[num.Next(slotIcons.Length)]}";
            });

            await ReplyAsync(result);
        }
    }
}
