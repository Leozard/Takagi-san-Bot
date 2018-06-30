using Discord;
using Discord.Commands;
using Kitsu;
using Kitsu.Anime;
using System.Linq;
using System.Threading.Tasks;

namespace TakagisanBot.Utility
{
    public class KitsuAnime : ModuleBase<SocketCommandContext>
    {
        [Command("anime")]

        public async Task KitsuAnimeAsync ([Remainder] string animeSearch)
        {
            EmbedBuilder kitsuAnime = new EmbedBuilder();

            var episodeCount = "";
            var rating = "";
             
            try
            {
                var animes = await Anime.GetAnimeAsync(animeSearch);

                foreach (var ani in animes.Data)
                {
                    if (ani.Attributes.Titles.EnJp != "")
                    {
                        if (ani.Attributes.EpisodeCount == null)
                            episodeCount = "Unknown";

                        else
                            episodeCount = ani.Attributes.EpisodeCount.ToString();

                        if (ani.Attributes.AverageRating == null)
                            rating = "Unknown";

                        else
                            rating = ani.Attributes.AverageRating;

                        string animeStatus = char.ToUpper(ani.Attributes.Status.First()) + ani.Attributes.Status.Substring(1);

                        string animeType = char.ToUpper(ani.Attributes.Subtype.First()) + ani.Attributes.Subtype.Substring(1);

                        kitsuAnime
                            .WithTitle(ani.Attributes.Titles.EnJp)
                            .WithUrl("https://kitsu.io/anime/" + ani.Attributes.Slug)
                            .WithThumbnailUrl(ani.Attributes.PosterImage.Original)
                            .AddInlineField("Status:", animeStatus)
                            .AddInlineField("Episodes:", episodeCount)
                            .AddInlineField("Score:", rating)
                            .AddInlineField("Type:", animeType)
                            .WithDescription($"{ani.Attributes.Synopsis}")
                            .WithFooter("Kitsu.io", "https://pbs.twimg.com/profile_images/807964865511862278/pIYOVdsl_400x400.jpg");

                        await ReplyAsync("", false, kitsuAnime.Build());

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
