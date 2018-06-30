using Discord.Commands;
using System.Threading.Tasks;
using YoutubeSearch;

namespace TakagisanBot.Utility
{
    public class Youtube : ModuleBase<SocketCommandContext>
    {
        [Command("yt")]
        [Alias("youtube")]

        public async Task YoutubeAsync([Remainder] string querystring)
        {
            // Number of result pages
            int querypages = 1;

            ////////////////////////////////
            // Starting searchquery
            ////////////////////////////////

            var items = new VideoSearch();
            

            foreach (var item in items.SearchQuery(querystring, querypages))
            {
                await ReplyAsync(item.Url);

                break;
            
            }
            
        }
    }
}
