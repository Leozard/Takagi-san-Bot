using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace TakagisanBot.Moderation
{
    public class KickBanUser : ModuleBase<SocketCommandContext>
    {
        [Command("kick")]
        
        public async Task KickUserAsync(IGuildUser userKick = null, [Remainder] string reason = null)
        {
            var user = Context.Guild.GetUser(Context.User.Id);
            var userBot = Context.Guild.GetUser(Context.Client.CurrentUser.Id);

            var userKickHierarchy = (SocketGuildUser) userKick;

            if (Context.Guild.GetUser(Context.User.Id).GuildPermissions.KickMembers == false)
            {
                await ReplyAsync("I'm sorry but you don't have the permission to kick your friend.");
                return;
            }
                
            else if (Context.Guild.GetUser(Context.Client.CurrentUser.Id).GuildPermissions.KickMembers == false)
            {
                await ReplyAsync("I'm sorry but I don't have the permission to kick your friend.");
                return;
            }

            if (userKick == null)
                await ReplyAsync("Who am I supposed to kick?");
           
            else if (userKick == user)
                await ReplyAsync("Why are you trying to kick yourself?");

            else if (userKick == Context.Guild.Owner)
                await ReplyAsync("You can't kick the guild owner, silly ");
            
            else if (userKick == Context.Guild.GetUser(Context.Client.CurrentUser.Id))
                await ReplyAsync("I can't kick myself, silly.");

            else if(user.Hierarchy < userKickHierarchy.Hierarchy)
                await ReplyAsync("I'm sorry but you can't kick someone with a higher hierarchy than you.");

            else if (userBot.Hierarchy < userKickHierarchy.Hierarchy)
                await ReplyAsync("I'm sorry but I can't kick someone with a higher hierarchy than me.");

            else
            {
                await userKick.KickAsync(reason);

                await ReplyAsync($"I've kicked the user ``{userKick.Username}`` with the reason: {reason}");
            }   
            
        }
        

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public async Task BanUserAsync(IGuildUser userBan = null, [Remainder] string reason = null)
        {
            SocketGuildUser user = Context.Guild.GetUser(Context.User.Id);
            SocketGuildUser userBot = Context.Guild.GetUser(Context.Client.CurrentUser.Id);

            var userBanHierarchy = (SocketGuildUser) userBan;

            if (Context.Guild.GetUser(Context.User.Id).GuildPermissions.BanMembers == false)
            {
                await ReplyAsync("I'm sorry but you don't have the permission to ban your friend.");
                return;
            }

            else if (Context.Guild.GetUser(Context.Client.CurrentUser.Id).GuildPermissions.BanMembers == false)
            {
                await ReplyAsync("I'm sorry but I don't have the permission to ban your friend.");
                return;
            }

            if (Context.Message == null)
                await ReplyAsync("Who am I supposed to ban?");
            
            else if (userBan == user)
                await ReplyAsync("Why are you trying to ban yourself?");

            else if (userBan == Context.Guild.Owner)
                await ReplyAsync("You can't ban the guild owner, silly ");
            
            else if (userBan == Context.Guild.GetUser(Context.Client.CurrentUser.Id))
                await ReplyAsync("I can't ban myself, silly.");

            else if (user.Hierarchy < userBanHierarchy.Hierarchy)
                await ReplyAsync("I'm sorry but I can't ban someone with a higher hierarchy than you.");

            else if (userBot.Hierarchy < userBanHierarchy.Hierarchy)
                await ReplyAsync("I'm sorry but I can't ban someone with a higher hierarchy than me.");

            else 
            {
                await Context.Guild.AddBanAsync(userBan, 14, reason);

                await ReplyAsync($"I've banned the user ``{userBan.Username}`` with the reason: {reason}");
            }
        }
    }
}
