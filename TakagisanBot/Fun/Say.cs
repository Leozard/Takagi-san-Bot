using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class Say : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        [RequireBotPermission(GuildPermission.ManageMessages)]

        public async Task SayAsync([Remainder] string saywords)
        {
            await Context.Message.DeleteAsync();
            await Task.Delay(0);

            await ReplyAsync(saywords);                        
        }


        [Command("sayto")]
        [RequireBotPermission(GuildPermission.ManageMessages)]

        public async Task SayToAsync( SocketGuildUser sayMention, [Remainder] string saywords)
        {
            await Context.Message.DeleteAsync();
            await Task.Delay(0);

            await ReplyAsync($"{sayMention.Mention} {saywords}");
        }
    }
}
