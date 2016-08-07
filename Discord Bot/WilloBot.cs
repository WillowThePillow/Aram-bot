using System;
using Discord;
using GiphyDotNet;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedditSharp;
using Newtonsoft;
using GiphyDotNet.Manager;
using GiphyDotNet.Model.GiphyImage;
using GiphyDotNet.Model.GiphyRandomImage;
using GiphyDotNet.Model.Parameters;
using GiphyDotNet.Model.Web;
using GiphyDotNet.Model.Results;
using GiphyDotNet.Tools;
/*Some guy : 211075529384656896
Poro : 211075661383729152
Shopkeeper : 211165716152451073
OCE : 211089510400786432
NA : 211089348496457729
LAN : 211089454738178049
@everyone : 211066369347813376
Bot Commander : 211177718111404032
Euw : 211089181277945856
Aethex : 150300454708838401
Potential mo : 211224177426825216
lookingforparty : 211927102172168192
Eune : 211089199439282176
Moderator : 211103176978464768
BR : 211089444311269376
looking-for-party : 211409465059049473
mod_chat : 211126235550580738
announcements : 211076361098362880
offtopic : 211075244608323584
secret_talky-talk_place : 211224141703938049
botland : 211166088224964610
league_news : 211075328339083265
general : 211066369347813376
suggestions : 211076846450638848
rules_n_info : 211072942023376896
music_n_images : 211136622853488643 */
namespace Discord_Bot
{
    public class WilloBot
    {
        private Reddit redbot;
        private DiscordClient bot;
        bool spamg = false;
        int spam = 100;
        int msgs = 0;
        
        //When Created
        public WilloBot()
        {
            redbot = new Reddit();
            bot = new DiscordClient();
            bot.MessageReceived += async (s, e) =>
            {
                await Bot_MessageReceived(s, e);
            };
            bot.Connect("vilimonas@gmail.com", "katoks0308");
            bot.LoggedIn += Bot_LoggedIn;
            bot.Wait();
            
           
        }

        private void Bot_LoggedIn(object sender, EventArgs e)
        {
            bot.SetGame("Willo Memes 16.08.02");
            
        }



        //Msg received
        public async Task Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;
            
            if (e.Message.Text.Contains("8ball,"))
            {
                Console.WriteLine(e.Message.User.Name + " used 8ball");
                Random rnd = new Random();
                string ballq = " **I wouldn't count on that**";
                int ball = rnd.Next(6);
                if (ball == 1)
                {
                    ballq = " **No**";
                }
                if (ball == 2)
                {
                    ballq = " **Yes**";
                }
                if (ball == 3)
                {
                    ballq = " **Maybe**";
                }
                if (ball == 4)
                {
                    ballq = " **idk**";
                }
                if (ball == 5)
                {
                    ballq = " **Most definetly**";
                }
                await e.Channel.SendMessage(e.User.Mention + " The question was: *" + e.Message.Text + "*");
                await e.Channel.SendMessage("The answer is, " + ballq);
            }


            if (e.Message.Text == "!info")

            {
                var aram = e.Server.Name;
                foreach (Role r in e.Server.Roles)
                {
                    Console.WriteLine($"{r.Name} : {r.Id}");
                }
                foreach (Channel c in e.Server.TextChannels)
                {
                    Console.WriteLine($"{c.Name} : {c.Id}");
                }
                Console.WriteLine(e.Message.User.Name + " used info");
                await e.Channel.SendMessage("I'm aram bot version **" + bot.CurrentGame + "**");
                await  e.Channel.SendMessage("There are currently **" + e.Channel.Users.Count() + "** people in this hell hole.");
                await e.Channel.SendMessage("*Bot guy - out*");

            }
            ////////REDDIT TEST/////////////
            if (e.Message.Text.Contains("!Reddit:"))
            {
                Console.WriteLine(e.Message.User.Name + " used Reddit:");
                string reddit = e.Message.Text.Split(':')[1];
                await e.Channel.SendMessage("https://www.reddit.com/r/" + reddit);
            }
            if (e.Message.Text.Contains("Giphy:"))
            {

            }

            //GAME TEST ///////////////////////////////////

            //////////// GAME MAKERS
            if (e.Message.Text.Contains("!lfp"))
            {
                Console.WriteLine(e.Message.User.Name + " used !lfp");
                var lfp = e.Server.GetRole(211927102172168192);
                if (e.User.HasRole(lfp))
                {
                    await e.User.RemoveRoles(lfp);
                    await e.Channel.SendMessage(e.User.Mention + "You are **no longer** looking for a party");
                }else
                {
                    await e.User.AddRoles(lfp);
                    await e.Channel.SendMessage(e.User.Mention + "You are now **looking** for a party");


                }

            }

        }
        }
    }
    