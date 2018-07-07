using Discord.Commands;
using System.Threading.Tasks;

namespace TakagisanBot.Utility
{
    public class ReverseText : ModuleBase<SocketCommandContext>
    {
        [Command("reverse")]

        public async Task ReverseTextAsync([Remainder] string text)
        {
            char[] c = new char[text.Length];
            int i = 0;
            string outtext = null;

            foreach(char v in text)
            {
                c[i] = v;
                ++i;
            }

            for(int o = text.Length - 1; o >= 0 ; --o)
            {
                outtext += c[o];
            }

            await ReplyAsync(outtext);
        }
    }
}
