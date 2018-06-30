using Discord;
using Discord.Commands;
using Kitsu;
using Kitsu.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TakagisanBot.Utility
{
    public class KitsuManga : ModuleBase<SocketCommandContext>
    {
        [Command("manga")]

        public async Task KitsuMangaAsync([Remainder] string mangaSearch)
        {
            EmbedBuilder kitsuMangaEmbed = new EmbedBuilder();

            var chapterCount = "";
            string rating = "";

            try
            {
                var mangas = await Manga.GetMangaAsync(mangaSearch);

                foreach(var manga in mangas.Data)
                {
                    if (manga.Attributes.Titles.EnJp != "")
                    {                       
                        if (manga.Attributes.ChapterCount == null)
                            chapterCount = "Unknown";

                        else
                            chapterCount = manga.Attributes.ChapterCount.ToString();

                        if (manga.Attributes.AverageRating == null)
                            rating = "Unknown";

                        else
                            rating = manga.Attributes.AverageRating;

                        string mangaStatus = char.ToUpper(manga.Attributes.Status.First()) + manga.Attributes.Status.Substring(1);

                        string mangaType = char.ToUpper(manga.Attributes.Subtype.First()) + manga.Attributes.Subtype.Substring(1);

                        kitsuMangaEmbed
                            .WithTitle(manga.Attributes.Titles.EnJp)
                            .WithUrl("https://kitsu.io/manga/" + manga.Attributes.Slug)
                            .WithThumbnailUrl(manga.Attributes.PosterImage.Original)
                            .AddInlineField("Status:", mangaStatus)
                            .AddInlineField("Chapters:", chapterCount)
                            .AddInlineField("Rating:", rating)
                            .AddInlineField("Type:", mangaType)
                            .WithDescription($"{manga.Attributes.Synopsis}")
                            .WithFooter("Kitsu.io", "https://pbs.twimg.com/profile_images/807964865511862278/pIYOVdsl_400x400.jpg");

                        await ReplyAsync("", false, kitsuMangaEmbed.Build());

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
