using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Takagi_sanTakagisanBot_Bot.Fun
{
    public class Dice : ModuleBase<SocketCommandContext>
    {
        Random rnd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

        [Command("dice")]
        [Alias("die")]
      
        public async Task DiceAsync(int diceSides = 6, int diceNum = 1)
        {
            if (diceNum >= 1)
            {
                if (diceSides == 6)
                {

                    int diceResult = rnd.Next(6) + 1;

                    await ReplyAsync($"You rolled a {diceResult}");

                }

                else if (diceSides <= 2)
                {
                    await ReplyAsync("No no, a dice can't exist with less than 3 sides");
                }

                else
                {
                    Stack<string> diceStk = new Stack<string>();

                    for (int i = diceNum; i > 0; --i)
                    {
                        int diceResultInt = rnd.Next(diceSides) + 1;

                        diceStk.Push("" + diceResultInt);
                    }

                    if (diceStk.Count == 1)

                        await ReplyAsync($"You rolled a {String.Join(", ", diceStk)}");

                    else
                        await ReplyAsync($"You rolled the following numbers: {String.Join(", ", diceStk)}");
                }
            }

            else
                await ReplyAsync("Silly you, you can't roll a dice that doesn't exist");
        }
    }
    
}
