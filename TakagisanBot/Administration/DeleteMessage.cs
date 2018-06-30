using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace TakagisanBot.Moderation
{
    [Group("clear")]

    public class DeleteMessage : ModuleBase<SocketCommandContext>
    {

        [Command]
        [RequireUserPermission(Discord.GuildPermission.ManageMessages)]
        [RequireBotPermission(Discord.GuildPermission.ManageMessages)]  

        public async Task DeleteMessageAsync(int deleteNum = 1)
        {
            var items = await Context.Channel.GetMessagesAsync(deleteNum + 1).Flatten();
            await Context.Channel.DeleteMessagesAsync(items);
            await Task.Delay(0);
        }

        
        [Command("all")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        [RequireBotPermission(Discord.GuildPermission.ManageMessages)]

        public async Task DeleteAllAsync()
        {
            var items = await Context.Channel.GetMessagesAsync(100).Flatten();
            await Context.Channel.DeleteMessagesAsync(items);
            await Task.Delay(0);
        }

    }
}
