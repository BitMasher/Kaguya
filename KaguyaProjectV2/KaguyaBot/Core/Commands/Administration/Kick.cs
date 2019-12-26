﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using KaguyaProjectV2.KaguyaBot.Core.Attributes;
using KaguyaProjectV2.KaguyaBot.Core.KaguyaEmbed;

namespace KaguyaProjectV2.KaguyaBot.Core.Commands.Administration
{
    public class Kick : ModuleBase<ShardedCommandContext>
    {
        [AdminCommand]
        [Command("Kick")]
        [Alias("k")]
        [Summary("Kicks a user, or a list of users, from the server.")]
        [Remarks("<user>\n<user> {...}")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [RequireBotPermission(GuildPermission.KickMembers)]
        public async Task KickUser(params SocketGuildUser[] users)
        {
            KaguyaEmbedBuilder embed = new KaguyaEmbedBuilder();
            var listUsers = new List<SocketGuildUser>(users);

            int i = 0;

            foreach (var user in listUsers)
            {
                try
                {
                    await user.KickAsync();
                    embed.Description += $"Successfully kicked `{user}`\n";
                    listUsers.Remove(user);
                }
                catch (Exception)
                {
                    embed.Description += $"Failed to kick `{user}`\n";
                }
            }

            if (embed.Description.Length > 2000)
            {
                string failString = "";

                if (listUsers.Count != 0)
                    failString = $"\nFailed to kick `{listUsers.Count}` users.";

                embed = new KaguyaEmbedBuilder
                {
                    Description = $"Successfully kicked `{i}` users.{failString}"
                };
            }

            await ReplyAsync(embed: embed.Build());
        }
    }
}
