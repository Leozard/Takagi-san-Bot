using Discord;
using Discord.Commands;
using Kitsu;
using Kitsu.Character;
using System.Threading.Tasks;

namespace TakagisanBot.Utility
{
    public class KitsuCharacter : ModuleBase<SocketCommandContext>
    {
        [Command("character")]
        [Alias("char")]

        public async Task KitsuCharacterAsync([Remainder] string charSearch)
        {
            EmbedBuilder kitsuCharEmbed = new EmbedBuilder();

            try
            {
                var characters = await Character.GetCharacterAsync(charSearch);

                foreach (var character in characters.Data)
                {
                    if (character.Attributes.Name != "")
                    {
                        kitsuCharEmbed
                            .WithTitle(character.Attributes.Name)
                            .WithImageUrl(character.Attributes.Image.Original);

                        await ReplyAsync("", false, kitsuCharEmbed);
                        break;
                    }
                }
            }

            catch (NoDataFoundException e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}
