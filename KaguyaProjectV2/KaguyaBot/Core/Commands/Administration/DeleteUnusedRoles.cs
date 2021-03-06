﻿using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using KaguyaProjectV2.KaguyaBot.Core.Attributes;
using KaguyaProjectV2.KaguyaBot.Core.Global;
using KaguyaProjectV2.KaguyaBot.Core.KaguyaEmbed;
using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using KaguyaProjectV2.KaguyaBot.Core.Extensions;

namespace KaguyaProjectV2.KaguyaBot.Core.Commands.Administration
{
    public class DeleteUnusedRoles : KaguyaBase
    {
        [DangerousCommand]
        [PremiumUserCommand]
        [AdminCommand]
        [Command("DeleteUnusedRoles")]
        [Summary("Deletes all roles in the current server " +
                 "that are not currently tied to any users. If " +
                 "a role exists but no users have it, it will be " +
                 "deleted.")]
        [Remarks("")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.ManageRoles)]
        [RequireBotPermission(GuildPermission.AddReactions)]
        public async Task DeleteRoles()
        {
            KaguyaEmbedBuilder embed;

            var confirmEmbed = new KaguyaEmbedBuilder
            {
                Description = $"{Context.User.Username}, are you sure you " +
                              $"wish to preform this action?"
            };

            confirmEmbed.SetColor(EmbedColor.VIOLET);

            var timeoutEmbed = new KaguyaEmbedBuilder
            {
                Description = "Timeout reached - reactions disabled. No action will be taken."
            };

            timeoutEmbed.SetColor(EmbedColor.RED);

            await InlineReactionReplyAsync(new ReactionCallbackData("", confirmEmbed.Build(), true, true, TimeSpan.FromSeconds(60))
                                           .WithCallback(GlobalProperties.CheckMarkEmoji(), async (c, r) =>
                                           {
                                               int i = 0;
                                               int j = 0;
                                               string failString = "";

                                               foreach (SocketRole role in Context.Guild.Roles.Where(x =>
                                                   !x.Members.Any() && x.Name.ToLower() != "kaguya-mute"))
                                               {
                                                   try
                                                   {
                                                       await role.DeleteAsync();
                                                       i++;
                                                   }
                                                   catch (Exception)
                                                   {
                                                       j++;
                                                   }
                                               }

                                               if (j != 0)
                                               {
                                                   failString = $"However, I failed to delete `{j}` roles. These roles are likely " +
                                                                "managed by integrations, therefore they cannot be deleted. \n" +
                                                                "*Hint: Is my role at the top of the hierarchy?*";
                                               }

                                               if (i == 0 && j == 0)
                                               {
                                                   embed = new KaguyaEmbedBuilder
                                                   {
                                                       Description = "Actually, there weren't any roles to delete - no action has been taken."
                                                   };

                                                   await ReplyAsync(embed: embed.Build());
                                               }

                                               else
                                               {
                                                   embed = new KaguyaEmbedBuilder
                                                   {
                                                       Description = $"Successfully deleted `{i}` roles. {failString}"
                                                   };

                                                   await ReplyAsync(embed: embed.Build());
                                               }
                                           })
                                           .WithCallback(new Emoji("⛔"), async (c, r) =>
                                           {
                                               embed = new KaguyaEmbedBuilder
                                               {
                                                   Description = $"Okay, no action will be taken."
                                               };

                                               await ReplyAsync(embed: embed.Build());
                                           }));
        }
    }
}