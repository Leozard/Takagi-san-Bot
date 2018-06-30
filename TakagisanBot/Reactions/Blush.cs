using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TakagisanBot.Reactions
{
    public class Blush : ModuleBase<SocketCommandContext>
    {
        Random rnd = new Random();

        [Command("blush")]

        public async Task BlushAsync(IGuildUser user = null)
        {
            string[] blushPics = { "https://kayo.moe/2E3ZygsH.png",
                                   "https://kayo.moe/bJBQlKlW.png",
                                   "https://kayo.moe/VJHU9vfm.png" };

            int i = rnd.Next(blushPics.Length);

            EmbedBuilder blushEmbed = new EmbedBuilder();

            string blushText = "";

            if (user is null)
                blushText = $"{Context.User.Username} is blushing.";

            else if (user != null)
                blushText = $"{user.Username} made {Context.User.Username} blush.";

            blushEmbed
                .WithDescription(blushText)
                .WithImageUrl(blushPics[i])
                .WithColor(0xF9CCCA);

            await ReplyAsync("", false, blushEmbed.Build());
        }
    }
}
