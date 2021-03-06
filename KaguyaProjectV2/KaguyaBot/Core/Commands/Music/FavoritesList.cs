﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Addons.Interactive;
using Discord.Commands;
using KaguyaProjectV2.KaguyaBot.Core.Attributes;
using KaguyaProjectV2.KaguyaBot.Core.KaguyaEmbed;
using KaguyaProjectV2.KaguyaBot.DataStorage.DbData.Models;
using KaguyaProjectV2.KaguyaBot.DataStorage.DbData.Queries;

namespace KaguyaProjectV2.KaguyaBot.Core.Commands.Music
{
    public class FavoritesList : KaguyaBase
    {
        [MusicCommand]
        [Command("FavoritesList")]
        [Alias("favls", "favlist", "favorites")]
        [Summary("Displays a list of all of your favorite tracks with their identifiers and names.")]
        [Remarks("")]
        public async Task Command()
        {
            const int PAGE_TRACK_COUNT = 25;

            Server server = await DatabaseQueries.GetOrCreateServerAsync(Context.Guild.Id);
            User user = await DatabaseQueries.GetOrCreateUserAsync(Context.User.Id);
            List<FavoriteTrack> favoriteTracks = await DatabaseQueries.GetAllForUserAsync<FavoriteTrack>(user.UserId);

            if (!favoriteTracks.Any())
            {
                await SendBasicErrorEmbedAsync($"You do not have any favorited tracks. Go out and " +
                                               $"get some with `{server.CommandPrefix}favorite`!");

                return;
            }

            double pageCountWithRemainder = (double) favoriteTracks.Count / PAGE_TRACK_COUNT;
            if ((pageCountWithRemainder - Math.Floor(pageCountWithRemainder)) > 0)
                pageCountWithRemainder = Math.Floor(pageCountWithRemainder) + 1;

            int pageCount = (int) pageCountWithRemainder;
            var pages = new PaginatedMessage.Page[pageCount];

            for (int i = 0; i < pageCount; i++)
            {
                var page = new PaginatedMessage.Page();
                var descSb = new StringBuilder();

                for (int j = 0; j < PAGE_TRACK_COUNT; j++)
                {
                    int trackIndex = j * (i + 1);

                    if (favoriteTracks.Count == trackIndex)
                        break;

                    FavoriteTrack track = favoriteTracks[trackIndex];
                    descSb.AppendLine($"`#{trackIndex + 1}.` `{track.TrackTitle}`");
                }

                page.Description = descSb.ToString();
                pages[i] = page;
            }

            var pager = new PaginatedMessage
            {
                Title = $"Favorite Tracks for {Context.User.Username}",
                Pages = pages,
                Color = KaguyaEmbedBuilder.LightBlueColor
            };

            if (pages.Length > 1)
            {
                await PagedReplyAsync(pager, new ReactionList
                {
                    First = true,
                    Last = true,
                    Forward = true,
                    Backward = true,
                    Jump = true
                });
            }
            else
            {
                await PagedReplyAsync(pager, new ReactionList
                {
                    Trash = true
                });
            }
        }
    }
}