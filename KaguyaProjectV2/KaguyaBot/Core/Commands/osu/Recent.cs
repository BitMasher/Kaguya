﻿using Discord.Commands;
using KaguyaProjectV2.KaguyaBot.Core.Attributes;
using KaguyaProjectV2.KaguyaBot.Core.KaguyaEmbed;
using KaguyaProjectV2.KaguyaBot.Core.Osu.Builders;
using KaguyaProjectV2.KaguyaBot.Core.Osu.Models;
using KaguyaProjectV2.KaguyaBot.DataStorage.DbData.Queries;
using System;
using System.Threading.Tasks;

namespace KaguyaProjectV2.KaguyaBot.Core.Commands.osu
{
    public class OsuRecent : ModuleBase<ShardedCommandContext>
    {
        public KaguyaEmbedBuilder embed = new KaguyaEmbedBuilder();

        [OsuCommand]
        [Command("osurecent")]
        [Summary("Osu Recent Summary?")]
        [Remarks("<username or ID>\nSomeUser\nSome user with spaces")]
        public async Task OsuRecentCommand([Remainder]string player = null)
        {
            OsuUserModel userProfileObject = null;
            if (player != null)
                userProfileObject = new OsuUserBuilder(player).Execute();
            
            if (userProfileObject == null)
            {
                userProfileObject = new OsuUserBuilder((await UserQueries.GetOrCreateUser(Context.User.Id)).OsuId.ToString()).Execute();
                if (player == "0")
                {
                    embed.WithTitle($"osu! Recent");
                    embed.WithDescription($"**{Context.User.Mention} Failed to acquire username! Please specify a player or set your osu! username with `{(await ServerQueries.GetOrCreateServerAsync(Context.Guild.Id)).CommandPrefix}osuset`!**");
                    await ReplyAsync(embed: embed.Build());
                    return;
                }
            }

            //Getting recent object.
            var playerRecentObjectList = new OsuRecentBuilder(userProfileObject.user_id.ToString()).Execute();

            if (playerRecentObjectList.Count == 0)
            {
                embed.WithAuthor(author =>
                {
                    author
                        .WithName("" + userProfileObject.username + " hasn't got any recent plays")
                        .WithIconUrl("https://a.ppy.sh/" + userProfileObject.user_id);
                });
            }
            else
            {
                //Author
                embed.WithAuthor(author =>
                {
                    author
                        .WithName($"Most Recent osu! Standard Play for " + userProfileObject.username)
                        .WithIconUrl("https://a.ppy.sh/" + userProfileObject.user_id);
                });

                //Description
                DateTime date = new DateTime();
                foreach (var playerRecentObject in playerRecentObjectList)
                {
                    embed.Description += $"▸ **{playerRecentObject.rankemote}{playerRecentObject.string_mods}** ▸ **[{playerRecentObject.beatmap.title} [{playerRecentObject.beatmap.version}]](https://osu.ppy.sh/b/{playerRecentObject.beatmap_id})** by **{playerRecentObject.beatmap.artist}**\n" +
                        $"▸ **☆{playerRecentObject.beatmap.difficultyrating.ToString("F")}** ▸ **{playerRecentObject.accuracy.ToString("F")}%**\n" +
                        $"▸ **Combo:** `{playerRecentObject.maxcombo.ToString("N0")}x / {playerRecentObject.beatmap.max_combo.ToString("N0")}x`\n" +
                        $"▸ [300 / 100 / 50 / X]: `[{playerRecentObject.count300} / {playerRecentObject.count100} / {playerRecentObject.count50} / {playerRecentObject.countmiss}]`\n" +
                        $"▸ **Map Completion:** `{Math.Round(playerRecentObject.completion, 2)}%`\n" +
                        $"▸ **Full Combo Percentage:** `{(((double)playerRecentObject.maxcombo / (double)playerRecentObject.beatmap.max_combo) * 100).ToString("N2")}%`\n";

                    if (playerRecentObject == playerRecentObjectList[playerRecentObjectList.Count - 1])
                        embed.Description += $"▸ **PP for FC**: `{playerRecentObject.fullcombopp.ToString("N0")}pp`";
                    else
                        embed.Description += $"▸ **PP for FC**: `{playerRecentObject.fullcombopp.ToString("N0")}pp`\n";

                    date = playerRecentObject.date;
                }

                //Footer
                var difference = DateTime.UtcNow - date;

                if (playerRecentObjectList.Count > 1)
                    embed.WithFooter($"{userProfileObject.username} performed this plays {(int)difference.TotalHours} hours {difference.Minutes} minutes and {difference.Seconds} seconds ago.");
                else
                    embed.WithFooter($"{userProfileObject.username} performed this play {(int)difference.TotalHours} hours {difference.Minutes} minutes and {difference.Seconds} seconds ago.");
            }

            await ReplyAsync(embed: embed.Build());
        }
    }
}
