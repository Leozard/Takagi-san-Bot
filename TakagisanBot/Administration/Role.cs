using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace TakagisanBot.Moderation
{
    public class Role : ModuleBase<SocketCommandContext>
    {
        [Command("createrole")]

        public async Task CreateRoleAsync([Remainder] string rolename)
        {
            await Context.Guild.CreateRoleAsync(rolename);

            await ReplyAsync($"Role ``{rolename}`` is successfully created!");
        }


        [Command("setrole")]

        public async Task SetRoleAsync(IGuildUser user, [Remainder] SocketRole role)
        {
            await user.AddRoleAsync(role);
        }

        [Command("rolelist")]

        public async Task RoleListAsync()
        {
            ArrayList roleList = new ArrayList();

            foreach(var role in Context.Guild.Roles)
            {
                roleList.Add(role);
            }

            await ReplyAsync($"``{String.Join("`` | ``", roleList.ToArray())}``");
        }
    }
}
