using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            var eb = new EmbedBuilder();
            eb.WithTitle("Available Commands");
            eb.AddField("`c <pair> <timeframe(s)> <indicators>`", "displays the price chart at this moment", false);
            eb.AddField("`alert set <pair> <price>`", "sets an alert at the requested price", false);
            eb.AddField("`alert list`", "displays a list of all alerts set", true);
            eb.AddField("`convert <price> <from> <to>`", "converts the requested price", false);
            eb.WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png");
            eb.WithColor(Color.Blue);

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("upgrade")]
        public async Task Upgrade(SocketGuildUser userName)
        {
            var user = Context.User as SocketGuildUser;
            var guest = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "guest");
            var puppy = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "whelp");
            var wolve = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "wolve");
            var alpha = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "alpha");

            if (userName.Roles.Contains(guest))
            {
                try
                {
                    var eb = new EmbedBuilder();
                    var channel = Context.Guild.Channels.FirstOrDefault(x => x.Id == 668972128036585482).Name;

                    eb.WithColor(Color.Blue);
                    eb.WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png");
                    eb.WithTitle("Congratulations, you've just obtained the whelp role!");
                    eb.WithDescription($"Complete following steps in order to go to #{channel};");

                    eb.AddField("\u200B", "\u200B", false);
                    eb.AddField("\u200B", "STEP 1: watch following videos; ", false);
                    eb.AddField("General Education", "100 series", true);
                    eb.AddField("Required Education", "200 series", true);
                    eb.AddField("Risk Management", "FRX445", true);
                    eb.AddField("\u200B", "\u200B", false);
                    eb.AddField("\u200B", "STEP 2: visit https://www.tradingview.com/markets/ and open the chart of any major currency pair", false);
                    eb.AddField("Draw the support - and resistance lines on the **1h** timeframe", "\u200B", true);
                    eb.AddField("Draw the up- and downtrends on the **1h** timeframe", "\u200B", true);
                    eb.AddField("\u200B", $"Send the chart in **#{channel}** by sending a screenshot generated in tradingview. To generate a screenshot of your chart, click the **camera** on the upper-right, next to Publish", false);
                    eb.AddField("\u200B", "\u200B", false);
                    eb.AddField("As soon as your chart has been reviewed, the process continues. I will be the one who messages you with your next exercice!", "\u200B", false);
                    eb.AddField("\u200B", "\u200B", false);

                    eb.WithFooter("Alpha Pips ©");
                    eb.WithCurrentTimestamp();

                    await userName.AddRoleAsync(puppy);
                    await userName.RemoveRoleAsync(guest);


                    await userName.SendMessageAsync("", false, eb.Build());
                    await Context.Channel.SendMessageAsync($"{userName} was upgraded to {puppy.Name}!");
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync($"{e.Message}!");
                }

            }

            if (userName.Roles.Contains(puppy))
            {
                try
                {
                    var emb = new EmbedBuilder();
                    var channel = Context.Guild.Channels.FirstOrDefault(x => x.Id == 668972128036585482).Name;

                    emb.WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png");
                    emb.WithTitle($"You just obtained the wolve role, welcome in #{channel}");
                    emb.WithDescription("This channel is where all the magic will happen!");
                    emb.AddField("\u200B", "We recommend using following tools;", false);
                    emb.AddField("Harmonics", "the tool included in your Platinum Package, visit https://harmonics.im", false);
                    emb.AddField("Steady •", "a tool by John Dollery and Starboi including copy-paste trades and education on swing-trading", true);
                    emb.AddField("Goldcup •", "a gold based tool including copy-paste (goldrush) and trade ideas (price trap)", true);
                    emb.AddField("Vibrata •", "a tool including copy-paste (london payout) and trade ideas (ECC-11)", true);
                    emb.AddField("• these tools are to be bought at https://im.academy/upgrade", "\u200B", false);
                    emb.AddField("\u200B", "We recommend following these educators;", false);
                    emb.AddField("Mourade Touzani", "Forex Basics, using the harmonic scanner", true);
                    emb.AddField("Antoon Coucke", "Forex Basics, educating swing trades", true);
                    emb.AddField("John Dollery", "Forex Advanced, educating steady trades", true);
                    emb.AddField("Starboi", "Forex Advanced, educating steady trades", true);
                    emb.AddField("Chris Derreck", "Forex Advanced, educating goldcup tool (price trap)", true);
                    emb.AddField("Luc Longmire", "Forex Advanced, educating goldcup tool (goldrush)", true);
                    emb.AddField("Dr. Kathy Kirkland", "Forex Advanced, educating vibrata tool", true);
                    emb.AddField("Kevin Serrano", "Forex Advanced, educating vibrata tool", true);
                    emb.AddField("Bas Kooijman •", "Forex Advanded, using the pivot scanner", true);
                    emb.AddField("• Bas' strategy is without stop-loss, please do not follow if your balance is below $1,000", "\u200B", false);
                    emb.AddField("\u200B", "type /help in #bot-commands to continue your journey!", false);
                    emb.AddField("\u200B", "\u200B", false);
                    emb.WithColor(Color.Blue);


                    emb.WithFooter("Alpha Pips ©");
                    emb.WithCurrentTimestamp();

                    await userName.AddRoleAsync(wolve);
                    await userName.RemoveRoleAsync(puppy);


                    await userName.SendMessageAsync("", false, emb.Build());
                    await Context.Channel.SendMessageAsync($"{userName} was upgraded to {wolve.Name}!");
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync($"{e.Message}!");
                }
            }

            if (userName.Roles.Contains(wolve))
            {
                await userName.AddRoleAsync(alpha);
                await userName.RemoveRoleAsync(wolve);

                await Context.Channel.SendMessageAsync($"{userName} was upgraded to {alpha.Name}!");

                DiscordSocketClient _client = new DiscordSocketClient();
                ulong id = 668915875881025548;
                var chnl = _client.GetChannel(id) as IMessageChannel;

                await chnl.SendMessageAsync("Announcement!");
            }

            //var role = Context.Guild.GetRole(Context.Message.Author.Id).Name;
            //await Context.Channel.SendMessageAsync(role);
        }

        [Command("trading")]
        public async Task Trading()
        {
            var eb = new EmbedBuilder();
            eb.WithTitle("We highly recommend to download following files;");
            eb.AddField("- Trading plan en - logbook", "https://bit.ly/2uPe49d", false);
            eb.AddField("- London Daybreak Strategy", "https://bit.ly/39QoN22", false);
            eb.AddField("- Price action candles", "https://bit.ly/328B0w8", false);
            eb.WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png");
            eb.WithColor(Color.Blue);

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("building")]
        public async Task Building()
        {
            var eb = new EmbedBuilder();
            eb.WithTitle("We highly recommend to download following files;");
            eb.AddField("- The IM Academy Presentation", "http://bit.ly/2P7syYF", false);
            eb.AddField("- Prospecting Register", "http://bit.ly/2V4spsU", false);
            eb.WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png");
            eb.WithColor(Color.Blue);

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("support")]
        public async Task Support()
        {
            var eb = new EmbedBuilder();
            eb.WithTitle("To get support of any kind, please use this command!")
            .AddField("\u200B", "`/ticket open <subject>` to get support from our team.", false).AddField("Replace **<subject>** with subject of the problem you're facing.", "\u200B", false)
            .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
            .WithColor(Color.Blue)
            .WithFooter(footer =>
             {
                 footer
                     .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
             });


            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("welcome")]
        public async Task Welcome()
        {
            var eb = new EmbedBuilder().WithTitle("Welcome wolve, to Alpha Pips' Discord!")
                .WithDescription("Please read following message **carefully** to continue;")
                .AddField("\u200B", "- This discord group is owned by Alpha Pips™' members and is intended for educational and informational purposes only.", false)
                .AddField("\u200B", "- You __**must**__ ***** change your discord username to your personal **name** and unique IM Academy® **ID**!\nExample: <@700369721337446414> \n\n*Desktop users, you can change this by rightclicking your name, change username. " +
                "\n\nPhone users, you must swipe left, click on your name and choose manage user.* \n\n***** *If you don't have your unique ID included in your username, you'll be __removed__ from our discord server*.", false)
                .AddField("\u200B", "- You will get access to different channels as your knowledge grows, make sure to read the pinned messages in all channels! :pushpin:", false)
                .AddField("\u200B", "- ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!", false)
                .AddField("\u200B", "**If you have read everything, click :white_check_mark: below!** ", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/700743273089859595.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("builder")]
        public async Task Builder()
        {
            var eb = new EmbedBuilder().WithTitle("Hi there wolve, would you like to become **2&FREE or above**?")
                .WithDescription("This rank will give you access to our <#700724119410573352> channel, " +
                "where you will learn how you become an **__I__ndependent __B__usinnes __O__wner**")
                
                .AddField("\u200B", "*To obtain the role, click on :construction_worker: below!*", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/707976352241942539.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("overview")]
        public async Task Overview()
        {
            var eb = new EmbedBuilder().WithTitle("Welcome wolve, here you'll find the weekly schedule!")
                .WithDescription("This overview is getting updated every sunday, make sure to keep an eye on it!")
                .AddField("\u200B", "**Monday 20th of April**", false)
                .AddField("\u200B", "- 8pm; IBO training call with Geoffrey \n - 9pm; IBO training call with Special Guest", false)
                .AddField("\u200B", "test", false);

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("phaseone")]
        public async Task PhaseOne()
        {
            var eb = new EmbedBuilder().WithTitle("Welcome to Phase 1, wolve! \nThis is where your journey starts :wolf:")
                .WithDescription("It's a pleasure to have you on board! \n\n It's our mission to help and guide you throughout your process! Let's create something big together and make your dreams come true!")
                .AddField("\u200B", "**:chart_with_upwards_trend:  STEP 1** \n Download following apps; ", false)
                .AddField("\u200B", "- MetaTrader 4 \n - Investing \n - MyFxBook \n - TradingView", true)
                .AddField("\u200B", "- Zoom \n - IM Acedemy \n - GoLive IM \n - Stinu", true)
                .AddField("\u200B", "*Or visit <#701213241426182175> to get all download links!*", false)
                .AddField("\u200B", "**:chart_with_upwards_trend:  STEP 2** \n\n - Watch all videos of 100 and 200 series \n - Watch video 445 - risk management planning", false)
                .AddField("\u200B", "**:chart_with_upwards_trend:  STEP 3** \n Make a chart setup of any currency pair by using: \n\n  - Support- and resistance zones \n  - Up- and down trends", false)
                .AddField("\u200B", "*Make sure you only use your **demo account** whilst trading in Phase 1!*")

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/700743273089859595.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("phasetwo")]
        public async Task PhaseTwo()
        {
            var eb = new EmbedBuilder().WithTitle("Welcome to Phase 2, wolve! Are you hungry? \nThis is where the magic begins :wolf: ")
                .WithDescription("Let's introduce you to some of our weapons :crossed_swords: and powerful live sessions :man_technologist:, so let's eat! :cut_of_meat:")
                .AddField("\u200B", "As you are willing to become an alpha wolve, we need to practice hunting our knowledge. You should have a look at <#705802289071521893> as this channel contains our recommened Basic GoLive Educators!", false)
                .AddField("\u200B", "Since the powerful Harmonic Scanner is included in your package, we highly recommend <#701527227774533663> to get started. You'll find interesting info about all other strategies in the category【 Strategies 】!", false)
                .AddField("\u200B", "Once you get comfortable with the markets, make sure to talk to your coach __**before**__ entering the markets on a live account.", false)
                .AddField("\u200B", "*Do you see yourself as a profitable hunter? \nDo you simply not want to stop learning?* \n\nSend us **three** setups you've made yourself and become an alpha wolve in <#700372776590114897> :wolf:")
                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/700743273089859595.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("phasethree")]
        public async Task PhaseThree()
        {
            var eb = new EmbedBuilder().WithTitle("Welcome to Phase 3, wolve! \nReady to become an independent trader? :wolf: ")
                .WithDescription("We are helping each other by sharing our setups, don't hesitate to do so!")
                .AddField("\u200B", "**:chart_with_upwards_trend:  STEP 1** \nMake sure you've watched **all** videos of all series! ", false)
                .AddField("\u200B", "**:chart_with_upwards_trend:  STEP 2** \nFollow those educators who fit your strategy and stick with them to master it! \n\nSome recommended educators are;", false)
                .AddField("\u200B", "- John Dollery \n- Lex Waves \n- Chris Derrick \n- Oran Wright \n- ...", true)
                .AddField("\u200B", "- Man-ny Quinones \n- Mike Miles \n- Rok Kumer \n- Kevin Mukoma \n- ...", true)
                .AddField("\u200B", "*Feel free to ask **any** question, You don't make mistakes, you either learn or gain!* \n\n**May the charts be with you** :pray:", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/700743273089859595.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("commands")]
        public async Task CommandList()
        {
            var eb = new EmbedBuilder().WithTitle("You have access to following commands! ")
                .WithDescription("These commands will be useful to use in the chats, make sure to check them out!")
                .AddField("`/nick <name>`", "Use this command to easily change your username to your **name + ID**", true)
                .AddField("`/crypto`", "Reminds you of where and when our crypto call takes place!", true)
                .AddField("\u200B", "For the builders, these will be handy!", false)
                .AddField("`/tradelog`", "Gives you a trading plan and - logbook!", true)
                .AddField("`/presentation`", "For the builders to present!", true)
                .AddField("\u200B", "Use the following to get the download link of the particular app for either Android or iOS.", false)
                .AddField("`/tradingview` \n`/myfxbfook` \n`/golive`", "\u200B", true)
                .AddField("`/zoom` \n`/mt4` \n`/imacademy`", "\u200B", true)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/700743273089859595.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("harmonics")]
        public async Task Harmonics()
        {
            var eb = new EmbedBuilder().WithTitle("Harmonic Scanner ")
                .WithDescription("An algorithm, **included in your package** that combines patterns and math to find high probability trade ideas in the forex markets.")
                .WithUrl("https://harmonics.im/#")
                .AddField("This strategy is a flagship strategy created by IM Academy's CEO, Chr    istopher Terry. It brings you multiple timeframe ideas including entry point, take profits and stop loss!", "\u200B", false)
                .AddField("\u200B", "**Trading Style :** \n- Active trading tool \n- Intraday \n- Daily trade ideas \n- 19 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \nGoLive educators \n  - [Mourade Touzani](https://golive.im/channels/dutchchannel1) \n  - [Christopher Derrick](https://golive.im/channels/livemarket)" +
                    "\n  - [Man-ny Quinones](https://golive.im/channels/livemarketchannel24) \n*Make sure to have a look at manny's [website](https://www.educatormannyq.com/)!*" +
                    "\n\n Alpha Pips educators \n- **Anthony Paris** \n\n*Make sure to keep an eye on <#701835658943135814> for these sessions!*", false)
                .AddField("\u200B", "**More GoLive educators :** \n- [Videsh Adimoolah](https://golive.im/channels/livemarketchannel13) \n- [Jean-Marc Leonce](https://golive.im/channels/livemarketchannel9) \n- [Ray Robinson](https://golive.im/channels/livemarketchannel26)", false)
                .AddField("\u200B", "**Languages :** \nDutch, English & Spanish", false)
                .AddField("\u200B", "**Useful links :** \n [Harmonic Scanner](https://harmonics.im/#) \n\n [Harmonics' piptalk](https://www.im.center/client/clubs/4) " +
                    "\n [Manny's piptalk](https://www.im.center/client/clubs/23) \n [Mourade's piptalk](https://www.im.center/client/clubs/58)", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/705392281380716676.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("vibrata")]
        public async Task Vibrata()
        {
            var eb = new EmbedBuilder().WithTitle("Vibrata")
                .WithDescription("Formerly known as Web Analyzer; \n a software that gives you an all in one solution allowing you to feel comfortable with your trades.")
                .WithUrl("https://vibrata.im/web/")
                .AddField("This strategy truly has something for everybody and every preference! It includes different strategies for all trading styles, built for all experience levels.", "\u200B", false)

                .AddField("\u200B", "**Trading Style :** \n\n There are __3 different tiers__ you can choose from based on your trading style: " +
                    "\n - No analysis trade is set up for you \n(copy and paste expert trade ideas) \n - Little to no analysis to confirm your entry " +
                    "\n - Confirm your own analysis based on a set of rules using one of our amazing strategies \n\n- Active trading tool \n- Scalping, Intraday and Swing \n- Daily trade ideas \n- 44 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \nGoLive educators \n- [Dr. Kathy Kirkland](https://golive.im/channels/livemarketchannel17) (ECC11)\n- [Balé Granville](https://golive.im/channels/webchannel1) " +
                    "\n- [Andrej Stjepcevic](https://golive.im/channels/slovenianCroatianchannel1) (4 rules) \n\nAlpha Pips educators \n- **Thaisy Minnaert** (MM strategy) \n\n*Make sure to keep an eye on <#701835658943135814> for these sessions!*", false)
                .AddField("\u200B", "**More GoLive educators :** \n- [Lee Allen](https://golive.im/channels/webchannel4) \n- [Sherrif Adeyemi](https://golive.im/channels/webchannel6) \n- [Kevin Serrano](https://golive.im/channels/livemarketchannel36)", false)
                .AddField("\u200B", "**Languages :** \nDutch, English, Spanish & Slovene", false)
                .AddField("\u200B", "**Useful links :** \n [Vibrata](https://vibrata.im/web/) \n\n [Vibrata's piptalk](https://www.im.center/client/clubs/22) " +
                    "\n [Andrej's piptalk](https://www.im.center/client/clubs/84) \n [Balé's piptalk](https://www.im.center/client/clubs/47)", false)
                .AddField("\u200B", "How to get the vibrata tool? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- Check __Web Analyzer__ \n- Scroll down and click __Order Now__", false)
                .AddField("This is an extra tool for your platinum package or included in your elite package!", "\u200B", false)
                .AddField("\u200B", "How to insert more (copy-paste) add-ons? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- We recommend **London Payout** and **Index Infusion**\n- Check __your choice(s)__ \n- Scroll down and click __Order Now__", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/705400392619524107.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("goldcup")]
        public async Task Goldcup()
        {
            var eb = new EmbedBuilder().WithTitle("Goldcup")
                .WithDescription("Simplicity and quality over quantity trades giving you full entry, stop loss and take profit parameters. " +
                    "Multiple strategies that all correlate with one another to provide high probability trade ideas. ")
                .WithUrl("https://goldcup.im/")
                .AddField("Along with the web version it includes an iPhone & Android app where you subscribe to desired push notifications. Customize your notifications by selecting which strategies, pairs and new alerts you would like to receive!", "\u200B", false)
                .AddField("\u200B", "**Trading Style :** \n- Active trading tool \n- Copy-paste trade ideas \n- Intraday \n- Daily trade ideas \n- 10 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \nGoLive educators  \n  - [Christopher Derrick](https://golive.im/channels/livemarket) \n - [Luc Longmire](https://golive.im/channels/cryptochannel5)" +
                    "\n  - [Kimberly Torres](https://golive.im/channels/livemarketchannel47) \n\n*Every Tuesday to Thursday at __1 PM UTC__, Kimberly and Luc are **trading live**!*" +
                    "\n\n Alpha Pips educators \n- **Anthony Paris** (Pricetrap Strategy) \n\n*Make sure to keep an eye on <#701835658943135814> for these sessions!*", false)
                .AddField("\u200B", "**More GoLive educators :** \n- [Lisaldo Tavarez](https://golive.im/channels/livemarketchannel19) \n- [Jesus Nuñez](https://golive.im/channels/livemarketchannel29) \n- [Dillano Binda](https://golive.im/channels/livemarketchannel23)", false)
                .AddField("\u200B", "**Languages :** \nDutch, English & Spanish", false)
                .AddField("\u200B", "**Useful links :** \n [Goldcup](https://goldcup.im/) \n [Goldcup's piptalk](https://www.im.center/client/clubs/1)", false)
                .AddField("\u200B", "How to get the goldcup tool? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- Check __Goldcup__ \n- Scroll down and click __Order Now__", false)
                .AddField("\u200B", "How to insert more add-ons? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- We recommend **Pricetrap** (trade ideas) and **US30** (live trading sessions) \n- Check __your choice(s)__ \n- Scroll down and click __Order Now__", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/706609834677633085.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("levels")]
        public async Task Levels()
        {
            var eb = new EmbedBuilder().WithTitle("Levels")
                .WithDescription("An algorithm that identifies entry points, stop loss and take profits one level at a time in the markets. " +
                    "It helps you to identify zones by providing the entry and exits and educates you why we are taking the setups in the markets.")
                .WithUrl("https://levels.im/")
                .AddField("Allows you to mark up the chart directly on the platform to confirm the trades based on the strategies taught with it.", "\u200B", false)
                .AddField("\u200B", "**Trading Style :** \n- Active trading tool \n- Copy-paste trade ideas \n- Intraday and Swing \n- Daily trade ideas \n- 3 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \n- [Oran Wright](https://golive.im/channels/livemarketchannel15)", false)
                .AddField("\u200B", "**Languages :** \nEnglish", false)
                .AddField("\u200B", "**Useful links :** \n [Levels](https://levels.im/) \n [Oran's piptalk](https://www.im.center/client/clubs/6)", false)
                .AddField("\u200B", "How to get the levels tool? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- Check __Levels__ \n- Scroll down and click __Order Now__", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/706616885847916564.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("pivots")]
        public async Task Pivots()
        {
            var eb = new EmbedBuilder().WithTitle("Pivots")
                .WithDescription("An algorithm taking the guess work out of finding your stop loss and take profit, which makes it easy for a brand new learner to understand!")
                .WithUrl("https://pivots.im/chart")
                .AddField("It finds reversal zones on every time frame allowing you to fit your trading style of scalping, intraday or swing trading.", "\u200B", false)
                .AddField("\u200B", "**Trading Style :** \n- Active trading tool \n- Intraday \n- Daily trade ideas \n- 15 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \n- [Lee Allen](https://golive.im/channels/webchannel4) \n- [Nancy Sosa](https://golive.im/channels/spanishchannel27) \n- [Bas Kooijman](https://golive.im/channels/dutchchannel2) " +
                    "\n\n*Bas is **trading live** every day at london opening!*", false)
                .AddField("\u200B", "**Languages :** \nDutch, English & Spanish", false)
                .AddField("\u200B", "**Useful links :** \n [Pivots](https://pivots.im/chart) \n [Pivots' piptalk](https://www.im.center/client/clubs/7) \n [Nancy's piptalk](https://www.im.center/client/clubs/26)" +
                    "\n [Lee's piptalk](https://www.im.center/client/clubs/36) \n [Bas' piptalk](https://www.im.center/client/clubs/68)", false)
                .AddField("\u200B", "How to get the pivots tool? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- Check __Pivots__ \n- Scroll down and click __Order Now__", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/706837394028232754.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("steady")]
        public async Task Steady()
        {
            var eb = new EmbedBuilder().WithTitle("Steady")
                .WithDescription("A strategy providing you quality swing trades with risk to reward calculated for you. You are able to learn this strategy by watching golive sessions.  The trade idea full parameters and long term trades allow you to set the trades and forget about them. ")
                .WithUrl("https://steady.im/web/")
                .AddField("\u200B", "**Trading Style :** \n- Copy-paste trade ideas \n- Swing \n- Weekly trade ideas \n- 6 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \n- [John Dollery](https://golive.im/channels/livemarketchannel43) \n- [Starboi](https://golive.im/channels/livemarketchannel42) " +
                    "\n- [Mauricio Ceballos](https://golive.im/channels/livemarketchannel52) \n- [Arelis](https://golive.im/channels/spanishchannel37)", false)
                .AddField("\u200B", "**Languages :** \nEnglish & Spanish", false)
                .AddField("\u200B", "**Useful links :** \n [Steady](https://steady.im/web/) \n [Steady's piptalk](https://www.im.center/client/clubs/9)", false)
                .AddField("\u200B", "How to get the steady tool? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- Check __Steady__ \n- Scroll down and click __Order Now__", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/705400029510369360.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("delorean")]
        public async Task Delorean()
        {
            var eb = new EmbedBuilder().WithTitle("Delorean")
                .WithDescription("An algorithm taking the guess work out of finding your stop loss and take profit, it will show you hundreds of possibilities each day allowing you to curate a strategy specific to your own style!" +
                    "The strategy includes following features; integrated charts, alert panel, session timer and copy paste ideas from the educators.")
                .WithUrl("https://delorean.im/")
                .AddField("You can start using this tool and learn the strategy behind it by watching the recorded sessions of the GoLive educators Patrick and Tyrone. We recommended checking out the Bootcamp Sessions!", "\u200B", false)
                .AddField("\u200B", "**Trading Style :** \n- Active trading tool \n- Copy-paste trade ideas (shadow) \n- Scalping, Intraday and Swing \n- Daily trade ideas \n- Weekly copy-paste ideas \n- 18 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \n- [Tyrone Foster](https://golive.im/channels/livemarketchannel18) \n- [Abel Melendez](https://golive.im/channels/livemarketchannel45) \n *Every thursday and friday at __11 AM UTC__, Abel is **trading live**!*" +
                    "\n\n- [Patrick Kenney](https://golive.im/channels/webchannel3) \n*Every tuesday to thursday at __1 PM UTC__, Patrick is **trading live**!*", false)
                .AddField("\u200B", "**Languages :** \nEnglish", false)
                .AddField("\u200B", "**Useful links :** \n [Delorean](https://delorean.im/) \n [Delorean's piptalk](https://www.im.center/client/clubs/8)", false)
                .AddField("\u200B", "How to get the delorean tool? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- Check __Delorean__ \n- Scroll down and click __Order Now__", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/705399642506002462.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("bounceback")]
        public async Task BounceBack()
        {
            var eb = new EmbedBuilder().WithTitle("Bounceback")
                .WithDescription("An algorithm giving you quality and precision while identifying entry points within the markets. It gives you quality over quantity setups. " +
                    "GoLive sessions teaching you how to maximize the strategy. Sends you notifications to piptalk when there is a new trade idea found. You also receive trade ideas from experts.")
                .WithUrl("http://bounceback.im/web/")
                .AddField("\u200B", "**Trading Style :** \n- Active trading tool \n- Copy-paste trade ideas (sniper) \n- Intraday and Swing \n- Daily trade ideas \n- 4 hours of education each week", false)
                .AddField("\u200B", "**Recommended educators:** \n- [Stevenson Lindor](https://golive.im/channels/livemarketchannel37) \n- [Zachary Hogan](https://golive.im/channels/livemarketchannel44) " +
                    "\n- [Jordan Morgan](https://golive.im/channels/livemarketchannel44) \n- [Mike Navarette](https://golive.im/channels/spanishchannel5)", false)
                .AddField("\u200B", "**Languages :** \nEnglish & Spanish", false)
                .AddField("\u200B", "**Useful links :** \n[Bounceback](http://bounceback.im/web/) \n\n[Bounceback's piptalk](https://www.im.center/client/clubs/2) " +
                    "\n[Mike's piptalk](https://www.im.center/client/clubs/18) \n[Stenvenson's piptalk](https://www.im.center/client/clubs/48)", false)
                .AddField("\u200B", "How to get the bounceback tool? \n- Go to your [shopping cart](https://im.academy/upgrade) \n- Check __Bounceback__ \n- Scroll down and click __Order Now__", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/706854507648385106.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("basic")]
        public async Task Basic()
        {
            var eb = new EmbedBuilder().WithTitle("Basic Educators")
                .WithDescription("After you've finished **Phase 1** we highly recommend following one of these educators on GoLive. " +
                    "Not only are they going to expand your knowledge, they could really become your mentors and lift your skillset to the next level!")
                .AddField("\u200B", ":flag_gb: **English educators: ** \n\n:desktop:  **[Man-ny Quinones](https://golive.im/channels/livemarketchannel24) :** \nMake sure you've seen the following videos: \n- [What is Forex?](https://golive.im/previous/video/8335368/200391793) \n- **all** bootcamps (1 to 8) \n\n*They can be found in his **favorite sessions** on GoLive or on his [website](https://www.educatormannyq.com/golive)*!", false)
                .AddField("\u200B", ":desktop:  **[Joshua Walls](https://golive.im/channels/livemarketchannel10) :** \nMake sure you've seen all his **favorite sessions**!", false)
                .AddField("\u200B", ":desktop:  **[Abel Melendez (aka Mr. Sauce)](https://golive.im/channels/livemarketchannel21)**", false)
                .AddField("\u200B", "\u200B", false)
                .AddField("\u200B", ":flag_fr: **Pour les francophones: **\n\n:desktop:  **[Mourade Touzani](https://golive.im/channels/frenchchannel3)** \n\nSessions recommandées par Mourade: \n - [Dimanche: special débutants](https://golive.im/previous/video/8527220/204413012)  \n- [Intermédiaire: outils vs price action](https://golive.im/previous/video/8527220/204648774)", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/707586677081767967.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("piptalk")]
        public async Task Piptalk()
        {
            var eb = new EmbedBuilder().WithTitle("Piptalk's Ideas ")
                .WithDescription("These are our recommended channels to follow on our beloved piptalk!")
                .WithUrl("https://www.im.center/client/clubs/122")
                .AddField("\u200B", "They will provide you with trade ideas and with educational chart ideas. You should also learn from them on GoLive sessions to know more about their strategy!" +
                "\n\nYou have to check **yourself** before entering a setup, this will improve your skill as well! **Do not** follow them **all**, choose an educator or strategy you like and try to master that skill.", false)
                .AddField("\u200B", "**Recommended Piptalk's:**", false)
                .AddField("\u200B", "[Mourade Montana](https://www.im.center/client/clubs/58)\n- Trade Ideas \n- English, Dutch & French" +
                    "\n\n[Kevin Mukoma](https://www.im.center/client/clubs/66) \n- Chart Ideas \n- English & French" +
                    "\n\n[Stevenson Lindor](https://www.im.center/client/clubs/48) \n- Chart Ideas \n- English " +
                    "\n\n[Václav Svoboda](https://www.im.center/client/clubs/138) \n- Chart & Trade Ideas \n- English & Czech \n- **Not on GoLive**", true)
                .AddField("\u200B", "[Anastasiia Demishkevych](https://www.im.center/client/clubs/112)\n- Trade Ideas \n- English & Polish" +
                    "\n\n[Saïd Ben Thami](https://www.im.center/client/clubs/110) \n- Trade Ideas \n- French \n- **Indices only**" +
                    "\n\n[Alex Prg](https://www.im.center/client/clubs/152) \n- Trade Ideas \n- French \n- **Not on GoLive**", true)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/705869447545487521.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("drive")]
        public async Task Drive()
        {
            var eb = new EmbedBuilder().WithTitle("Welcome to our drive-feed!")
                .WithDescription("In this channel you'll receive updates when a new document or video is available. Whether you are building or trading, our drive will bring you to the next level!")
                .AddField("\u200B", "The link to our drive can be found [here](https://drive.google.com/drive/folders/18LP-utOmTSYOTjt9HyZwz218rEp8ceTZ?usp=sharing)!", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/710464998601785396.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("Mindset")]
        public async Task Mindset()
        {
            var eb = new EmbedBuilder().WithTitle("Welcome to our Mindset-feed!")
                .WithDescription("In this channel you'll find everything about Mindset. We will share E-Books, Mindset video’s and so much more. Whether you are trading or building, Mindset is a key to your success in every aspect of your life!!")

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/710464998601785396.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("tradeideas")]
        public async Task TradeIdeas()
        {
            var eb = new EmbedBuilder().WithTitle("Hi there wolve, text comes here ")
                .WithDescription("This rank will give you access to our <#707991320173477928> channel.")
                
                .AddField("\u200B", "*To obtain the role, click on :alpha: below!*", false)

                .WithImageUrl("https://amerofinanciero.com/wp-content/uploads/2019/11/thumb600_IMG_20191007_165757.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/707976352241942539.png?v=1")
                .WithColor(Color.Blue)
                .WithFooter(footer =>
                {
                    footer
                        .WithText("IM Mastery Academy® | Alpha Pips™ \n\n ⚠️ Trading involves risk, past profits do not guarantee future results and we are not financial advisors!");
                });

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }
    }

}
