using Discord.Commands;
using System.Threading.Tasks;

namespace TakagisanBot.Utility
{
    public class LMGTFY :ModuleBase<SocketCommandContext>
    {
        [Command("google")]

        public async Task LMGTFYAsync([Remainder] string search)
        {
            var url = System.Web.HttpUtility.UrlEncode(search);

            await ReplyAsync("<http://lmgtfy.com/?q=" + url + ">");

        }


    }
}
