using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace TakagisanBot.Info
{

    public class Help : ModuleBase<SocketCommandContext>
    {
        string[] funCommands = { "bigtext", "dice", "flipcoin", "hello", "luck", "rate", "rps", "say", "sayto" };
        string[] infoCommands = { "avatar", "botinfo", "help", "info", "ping", "role", "serverinfo", "uptime" };
        string[] administrationCommands = { "ban", "clear", "createrole", "kick", "setrole" };
        string[] utilityCommands = { "anime", "character", "manga", "pokemon", "youtube" };

        [Command("help")]

        public async Task HelpAsync([Remainder] string helpcommand = null)
        {
            if(Context.Channel.Name == "general")
            {
                await ReplyAsync("Don't use this command in genaral chat, silly.");
            }

            else if (helpcommand == null)
            {
                EmbedBuilder helpEmbed = new EmbedBuilder()
                    .AddField("Fun", $"{string.Join(" | ", funCommands)}")
                    .AddField("Info", $"{string.Join(" | ", infoCommands)}")
                    .AddField("Moderation", $"{string.Join(" | ", administrationCommands)}")
                    .AddField("Utility", $"{string.Join(" | ", utilityCommands)}");

                await ReplyAsync($"The prefix for my commands is ``--``. Use ``--help [command]`` to find out more about a command.", false, helpEmbed.Build());
            }

            else if (helpcommand != null)
            {
                switch (helpcommand)
                {
                    //Administration Commands

                    case "ban":
                        await ReplyAsync("Bans a naughty user\n```Usage: --ban [user]```");
                        break;

                    case "clear":
                        break;

                    case "kick":
                        await ReplyAsync("Kicks a naughty user\n```Usage: --kick [user]```");
                        break;

                    //Fun Commmands

                    case "dice":
                        await ReplyAsync("I'll roll some dices for you. They may or may not be rigged!\n```Alias: die\n\nUsage: --dice / --dice [number of sides] [number of dices]\n\nNotes: If no parameters are given, a standard dice with 6 sides will be rolled.```");
                        break;

                    case "flipcoin":
                        await ReplyAsync("I'll flip a coin for you. You will get heads or tails, or you might get something different!\n```Usage: --flipcoin```");
                        break;
                        
                    case "hello":
                        await ReplyAsync("Greet me or other users with this!\n```Alias: hi\n\nUsage: --hello [user]```");
                        break;

                    case "luck":
                        await ReplyAsync("I'll predict how lucky you are today!\n```Usage: --luck```");
                        break;

                    case "rate":
                        await ReplyAsync("I'll rate something or someone.\n```Usage: --rate [what/who to rate]```");
                        break;

                    case "rps":
                        await ReplyAsync("Play rock-paper-scissors with me! ```Usage: --rps [rock/paper/scissors]```");
                        break;

                    case "say":
                        await ReplyAsync("Make me say something!\n```Usage: --say [sentence]```");
                        break;

                    case "sayto":
                        await ReplyAsync("Tell someone a message!\n```Usage: --sayto [user] [message]```");
                        break;

                    //Info Commands

                    case "avatar":
                        await ReplyAsync("I wonder what's the real face behind that avatar.\n```Alias: ava\n\nUsage: --avatar / --avatar [user]");
                        break;

                    case "botinfo":
                        await ReplyAsync("I'll show you a bit about myself.\n```Usage: --botinfo```");
                        break;

                    case "help":
                        await ReplyAsync("You can see all things that I can do. You can also specify which command you're interested in by adding it as a parameter.```Usage: --help / --help [command]```");
                        break;

                    case "ping":
                        await ReplyAsync("Checks my latency to the server.```Usage: --ping```");
                        break;

                    case "serverinfo":
                        await ReplyAsync("I'll show you the information about this guild.\n```Usage: --serverinfo```");
                        break;

                    case "uptime":
                        await ReplyAsync("How long have I been awake?\n```Usage: --uptime``");
                        break;

                    case "info":
                        await ReplyAsync("I'll show you a bit about yourself, or a friend if you can tell me his name.\n```Usage: --userinfo / --userinfo [user]");
                        break;

                    case "role":
                        await ReplyAsync("I'll list all the roles user has.\n```Usage: --userroles / --userroles [user]```");
                        break;

                    //Bot Control

                    case "setgame":
                        await ReplyAsync("Changes the game I'm playing. Only Nishikata-kun can use this!");
                        break;

                    case "shutdown":
                        await ReplyAsync("Make's me go to bed. Only Nishikata-kun can use this!");
                        break;

                    case "status":
                        await ReplyAsync("Changes my status. Only Nishikata-kun can use this!");
                        break;

                    //Utility

                    case "anime":
                        await ReplyAsync("Look up information about an anime!\n```Usage: --anime [anime name]```");
                        break;

                    case "character":
                        await ReplyAsync("Look for an image of your waifu!\n```Alias: char\n\nUsage: --character [character name]```");
                        break;

                    case "manga":
                        await ReplyAsync("Look up informaton about a manga!\n```Usage: --manga [manga name]```");
                        break;
                                            
                    default:
                        await ReplyAsync("I'm sorry, but that command doesn't exist on my database. I thought you were better than that.");
                        break;
                }
            }

        }


    }
}
