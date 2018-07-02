using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TakagisanBot.Info
{
    public class BotInfo : ModuleBase<SocketCommandContext>
    {

        [Command("botinfo")]

        public async Task BotInfoAsync([Remainder] string placeholder = null)
        {
            EmbedBuilder botInfoEmbed = new EmbedBuilder();

            var uptime = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();

            botInfoEmbed
                .WithTitle($"{Context.Client.CurrentUser.Username}\t#{Context.Client.CurrentUser.Discriminator}")
                .WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl())
                .WithDescription($"Created by Leozard\non {Context.Client.CurrentUser.CreatedAt}\n\nA simple bot created using c# and the Discord.net library.\nYou can report any bugs or spelling/grammatical errors by mentioning my creator!\n\nUptime: {uptime}")
                .WithFooter("Takagi-san Bot", Context.Client.CurrentUser.GetAvatarUrl())
                .WithColor(0xff00ff);

            await ReplyAsync("", false, botInfoEmbed.Build());
        }


        [Command("ping")]

        public async Task PingAsync([Remainder] string placeholder = null)
        {
            await ReplyAsync($"*Teehee* ok! ({Context.Client.Latency}ms)");
        }
        
        
        [Command("uptime")]

        public async Task UptimeAsync([Remainder] string placeholder = null)   
        {
            var uptime = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();

            await ReplyAsync($"Uptime: {uptime}");
        }

        [Command("invite")]

        public async Task InviteAsync()
        {
            EmbedBuilder inviteEmbed = new EmbedBuilder();

            inviteEmbed
                .WithDescription("[Click here to invite me to your server!](https://discordapp.com/oauth2/authorize?client_id=436460683022827520&scope=bot&permissions=469888087)")
                .WithFooter("Takagi-san Bot", Context.Client.CurrentUser.GetAvatarUrl())
                .WithColor(0xff00ff);

            await ReplyAsync("", false, inviteEmbed.Build());
        }
    }
}
