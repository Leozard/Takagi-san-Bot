using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace TakagisanBot.Info
{
    public class ServerInfo :ModuleBase<SocketCommandContext>
    {
        [Command("serverinfo")]

        public async Task ServerInfoAsync([Remainder] string placeholder = null )
        {
            EmbedBuilder serverInfoEmbed = new EmbedBuilder();

            serverInfoEmbed
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithTitle(Context.Guild.Name)
                .WithDescription($"**Owner:** {Context.Guild.Owner}\n**Date Created:** {Context.Guild.CreatedAt}\n**Verfication Level:** {Context.Guild.VerificationLevel}\n**Member Count:** {Context.Guild.MemberCount}\n**Role Count:** {Context.Guild.Roles.Count}\n**Region:** {Context.Guild.VoiceRegionId}");

            await ReplyAsync("", false, serverInfoEmbed.Build());
        }
    }
}
