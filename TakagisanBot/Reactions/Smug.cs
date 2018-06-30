using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TakagisanBot.Reactions
{
    public class Smug : ModuleBase<SocketCommandContext>
    {
        Random rnd = new Random();

        [Command("smug")]

        public async Task SmugAsync(IGuildUser user = null)
        {
            string[] smugPics = { "https://kayo.moe/eTGwV3ec.png",
                                  "https://kayo.moe/Dy98rAmK.png",
                                  "https://kayo.moe/Vks6doJY.png" };

            int i = rnd.Next(smugPics.Length);

            string smugText = "";

            EmbedBuilder smugEmbed = new EmbedBuilder();

            if (user is null)
                smugText = $"{Context.User.Mention} is feeling smug.";

            else if (user != null)
                smugText = $"{Context.User.Mention} is feeling smug towards {user.Mention}.";


            smugEmbed
                .WithDescription(smugText + " <:TakagiSmug:453559461684969494>")
                .WithImageUrl(smugPics[i])
                .WithColor(Color.Red);

            await ReplyAsync("", false, smugEmbed.Build());
        }
    }
}
