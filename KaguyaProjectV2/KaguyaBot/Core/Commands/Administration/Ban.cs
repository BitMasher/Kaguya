﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using KaguyaProjectV2.KaguyaBot.Core.Attributes;
using KaguyaProjectV2.KaguyaBot.Core.KaguyaEmbed;
using KaguyaProjectV2.KaguyaBot.DataStorage.JsonStorage;
using System;
using System.Threading.Tasks;
using KaguyaProjectV2.KaguyaBot.Core.Services.ConsoleLogServices;

namespace KaguyaProjectV2.KaguyaBot.Core.Commands.Administration
{
    public class Ban : KaguyaBase
    {
        [AdminCommand]
        [Command("Ban")]
        [Alias("b")]
        [Summary("Permanently bans a user from the server.\n\n" +
                 "*Use the `massban` command to ban multiple users at once.*")]
        [Remarks("<user> [reason]")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanUser(SocketGuildUser user, [Remainder] string reason = null)
        {
            var embed = new KaguyaEmbedBuilder();
            reason ??= "<No reason provided>";

            try
            {
                await user.BanAsync(reason: reason);
                if (user.Id != 159985870458322944)
                    embed.Description = $"Successfully banned `{user}` with reason `{reason}`\n";
                else // Easter egg lol
                {
                    embed.Description = $"Successfully banned `{user}` with reason `{reason}`\n" +
                                        $"*Nice choice* <:Kaguya:581581938884608001> 👍";
                }
            }
            catch (Exception)
            {
                embed.Description = $"Failed to ban `{user}`\n";
            }

            await ReplyAsync(embed: embed.Build());
        }

        /// <summary>
        /// Method to "silently" ban a user. This method is only called by the WarnHandler class.
        /// </summary>
        /// <param name="user">The user to ban.</param>
        /// <param name="reason">The reason for banning the user.</param>
        /// <returns></returns>
        public async Task AutoBanUserAsync(SocketGuildUser user, string reason)
        {
            // Not try-catched as the exception is handled elsewhere.
            await user.BanAsync(0, reason);
            await ConsoleLogger.LogAsync($"User auto-banned. Guild: [Name: {user.Guild.Name} | ID: {user.Guild.Id}] " +
                                         $"User: [Name: {user} | ID: {user.Id}]", LogLvl.DEBUG);
        }
    }
}