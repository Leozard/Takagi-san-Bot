using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace TakagisanBot.Info
{
    public class UserInfo : ModuleBase<SocketCommandContext>
    {
        [Command("info")]

        public async Task UserInfoAsync([Remainder] IGuildUser username = null)
        {
            EmbedBuilder userInfoEmbed = new EmbedBuilder();
            
            string accType = null;
            string userPlaying = null;

            if (username == null)
                username = Context.Guild.GetUser(Context.User.Id);

            var UserRole = (SocketGuildUser) username;
            var roleColour = Color.Default;

            foreach (SocketRole role in UserRole.Roles)
            {
                if (role.Name != "@everyone" || role.Color.ToString() != "#0")
                {
                    roleColour = role.Color;
                    break;
                }
                    
            }

            if (username.IsBot == true)
                accType = "Bot Account";
            else
                accType = "User Account";

            if (username.Game != null)
                userPlaying = $"**Playing:** {username.Game.ToString()}\n";

            userInfoEmbed
                .WithThumbnailUrl(username.GetAvatarUrl())
                .WithTitle($"{username.Username} #{username.Discriminator}")
                .WithDescription($"\n**Status:** {username.Status.ToString()}\n{userPlaying}**Date Created:** {username.CreatedAt}\n**Join Date:** {username.JoinedAt}")
                .WithColor(roleColour)
                .WithFooter(accType);

            await ReplyAsync("", false, userInfoEmbed.Build());
        }


        [Command("avatar")]
        [Alias("ava")]

        public async Task GetAvatarAsync(IGuildUser username = null, [Remainder] string input = null)
        {
            if (username == null)
                username = Context.Guild.GetUser(Context.User.Id);

            EmbedBuilder avatarEmbed = new EmbedBuilder();
            ushort size = 0;

            switch (input)
            {
                case "small":
                    size = 128;
                    break;
                case "big":
                    size = 512;
                    break;
                default:
                    size = 256;
                    break;
            }

            avatarEmbed
                   .WithTitle($"{username.Username}\t#{username.Discriminator}")
                   .WithDescription($"[Direct Link]({username.GetAvatarUrl(ImageFormat.Auto, size)})")
                   .WithImageUrl(username.GetAvatarUrl(ImageFormat.Auto, size));

            await ReplyAsync("", false, avatarEmbed.Build());
        }


        [Command("role")]

        public async Task UserRolesAsync([Remainder] IGuildUser userRole = null)
        {
            if (userRole == null)
                userRole = Context.Guild.GetUser(Context.User.Id);

            ArrayList roleArray = new ArrayList();

            var userSearch = (SocketGuildUser) userRole;

            foreach (var role in userSearch.Roles)
            {
                if (role.Name != "@everyone")
                    roleArray.Add(role.Name);
            }

            if (roleArray.Count == 0)
                await ReplyAsync($"{userRole.Username} has no roles. Maybe you should give him/her some.");

            else if (roleArray.Count == 1)
                await ReplyAsync($"{userRole.Username} has the role ``{roleArray[0]}``");

            else
                await ReplyAsync($"{userRole.Username} has the following roles: ``{String.Join("`` | ``", roleArray.ToArray())}``");

        }
    }
}

