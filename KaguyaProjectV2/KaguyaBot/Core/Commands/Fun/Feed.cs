﻿using Discord.Commands;
using Discord.WebSocket;
using Humanizer;
using KaguyaProjectV2.KaguyaBot.Core.Attributes;
using KaguyaProjectV2.KaguyaBot.Core.Global;
using KaguyaProjectV2.KaguyaBot.Core.KaguyaEmbed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NekosSharp;

namespace KaguyaProjectV2.KaguyaBot.Core.Commands.Fun
{
    public class Feed : KaguyaBase
    {
        [FunCommand]
        [Command("Feed")]
        [Summary("Feed somebody, or multiple people!")]
        [Remarks("<user> {...}")]
        public async Task Command(params SocketGuildUser[] users)
        {
            Request feedGif = await ConfigProperties.NekoClient.Action_v3.FeedGif();

            if (users.Length == 1)
            {
                var embed = new KaguyaEmbedBuilder
                {
                    Title = $"Feed | {Centvrio.Emoji.FoodPrepared.Pancakes}",
                    Description = $"{Context.User.Mention} fed {users[0].Mention}!",
                    ImageUrl = feedGif.ImageUrl
                };

                await ReplyAsync(embed: embed.Build());

                return;
            }
            else
            {
                var names = new List<string>();
                users.ToList().ForEach(x => names.Add(x.Mention));

                if (names.Count == 0)
                    names.Add("the air");

                var embed = new KaguyaEmbedBuilder
                {
                    Title = $"Feed | {Centvrio.Emoji.FoodPrepared.Pancakes}",
                    Description = $"{Context.User.Mention} fed {names.Humanize()}!",
                    ImageUrl = feedGif.ImageUrl
                };

                await ReplyAsync(embed: embed.Build());
            }
        }
    }
}