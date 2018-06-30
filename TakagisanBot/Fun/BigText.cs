using Discord.Commands;
using System.Threading.Tasks;

namespace TakagisanBot.Fun
{
    public class BigText : ModuleBase<SocketCommandContext>
    {
        string[] alpha =
        {
             "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        string[] beta =
        {
            ":regional_indicator_a:", ":regional_indicator_b:", ":regional_indicator_c:", ":regional_indicator_d:", ":regional_indicator_e:", ":regional_indicator_f:", ":regional_indicator_g:", ":regional_indicator_h:", ":regional_indicator_i:",
            ":regional_indicator_j:", ":regional_indicator_k:", ":regional_indicator_l:", ":regional_indicator_m:", ":regional_indicator_n:", ":regional_indicator_o:", ":regional_indicator_p:", ":regional_indicator_q:", ":regional_indicator_r:",
            ":regional_indicator_s:", ":regional_indicator_t:", ":regional_indicator_u:", ":regional_indicator_v:", ":regional_indicator_w:", ":regional_indicator_x:", ":regional_indicator_y:", ":regional_indicator_z:", ":zero:",
            ":one:", ":two:", ":three:", ":four:", ":five:", ":six:", ":seven:", ":eight:", ":nine:"
        };

        string outputText = "";


        [Command("bigtext")]

        public async Task BigTextAsync([Remainder] string inputText = null)
        {
            await BigTextCore(inputText);
        }


        [Command("bigtextd")]

        public async Task BigTextdAsync([Remainder] string inputText = null)
        {
            await Context.Message.DeleteAsync();

            await BigTextCore(inputText);
        }


        private async Task BigTextCore(string text)
        {
            string textlower = text.ToLower();

            foreach (char c in textlower)
            {
                for (int i = 0; i <= alpha.Length - 1; ++i)
                {
                    if (c.ToString() == alpha[i])
                    {
                        outputText += beta[i];
                        break;
                    }

                    else if (c.ToString() != alpha[i] && i == alpha.Length - 1)
                    {
                        outputText += c;
                    }
                }
            }

            await ReplyAsync(outputText);
        }
    }
}
