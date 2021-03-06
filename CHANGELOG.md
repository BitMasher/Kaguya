### Version 3.2.1
- Solved issue with $profile deadlocking the client, thus causing long wait times / crashes of shards.
- Removed unnecessary typing state with $stats

### Version 3.2
- Updated framework to .NET 5.
- Updated language version to C# 9.0
- Updated README.md to include instructions for developing Kaguya yourself.
- Logtype "MogLog" no longer exists. Replaced by individual logtypes for mutes, unmutes, shadowban, unshadowban, warn, and unwarn.
    - All of these logtypes are premium only.
- $shadowban and $unshadowban have been rewritten to be more efficient.
- Re-designed the formatting of log messages to take up much less space. *Please let me know if you like / dislike it!!*
- Fixed typo where antiraid DM's had incorrect grammar for the punishment.
- Fixed bug where, in some circumstances, antiraid log messages would be duplicated.
- Fixed a bug where users DM'd with an antiraid DM notification would not be called by their proper name.
- The ability for a deleted message's old contents to be archived is now a premium-only feature.
- The ability for an updated message's old + new contents to be archived is now a premium-only feature.
- When using logs from "$log filteredphrases", archival of the user's full message is now a premium-only feature.
- $shadowban & $unshadowban now will accept a reason parameter at the end, if desired for logging purposes.
- If a user is muted despite the user already having an existing mute (*with a duration*), that duration will be overwritten with whatever new duration was provided.
- Unmute, shadowban, unshadowban, and unwarn now all accept a 'reason' as a parameter. This can be saved for logging purposes (again, premium only).

### Version 3.1.1
- Fixed bug with antiraid where users would not be actioned or logged properly.
- **Re-introduced bug** where sometimes there are duplicate anti-raid log messages.

### Version 3.1
- Fixed bug where antiraid could log messages multiple times if lots of users are being actioned.
- Drastically improved speed of KaguyaWebData api response.
- Drastically improved speed of $stats.

### Version 3.0.3
- $osurecent now displays the correct time for when the play was made.
- $osutop now displays the correct time for when the play was made.
- $osurecent has been rewritten with new information and a new format.

### Version 3.0.2
- Fixes bug with Kaguya API where top.gg voters would not be given their rewards.

### Version 3.0.1
- Patches unhandled exception in StatsUpdater.cs

### Version 3.0
- Kaguya will now read from a configuration file if program arguments are not being used on launch.
- Refactored ConfigModel to inherit from new IBotConfig
- Kaguya now has a working pipeline on a Linux server.
- Fixed a bug where some commands would trigger an endless "Kaguya is typing..." state.
- External dependencies are copied in the Main() method, no longer required by the pipeline.
- osu dependency (Oppai.dll) updated to accurately reflect performance values of scores.
- Better overall cross-platform support (filepathing, to be specific).
- Music commands are re-enabled

### Version 2.16.2
- Updated total shards to 5.
- Changes needed for Windows -> Linux migration.

### Version 2.16.1
- Updated total shards to 3 (was 4).
- Now logging _client.ShardDisconnected exception types as well as the message.

### Version 2.16
- (Owner Only) Added $resetgame, $setgame
- (Owner Only) $advertisestream now takes in just a username, not a whole URL.
- $help no longer shows 1/10 pages in the footer (the 10th page is hidden, now shows 1/9).
- Added $changelog (shows what's new in the most recent version. See more with the command's arguments!)
- Fixed bug where sometimes a command would be displayed twice in the $help command list.

### Version 2.15.1
Developer Changes:
- Added additional logging for OwnerGiveawayMessageUpdaterService.
- Fixed issue where the OwnerGiveawayMessageUpdaterService would not remove a giveaway if it had been deleted before the time had expired.
- Massive code cleanup and reformatting
User Changes:
- Fixed a bug where $log antiraids would not work but $log antiraid would. Correct usage is $log antiraids, as shown in $logs.
- Fixed a bug with the $fish level-up notification service where either:
    - Fish level up notifications would not get sent at all
    - The fish level up notification would be sent, but the "value increase display" would show the same values for both the 'to' and 'from' values.
- Fixed a typo with the syntax in $kick
- Reminders will no longer have their text altered in some cases.
- Updated $kick and $ban help commands to also suggest $masskick and $massban respectively for kicking or banning multiple users at once.

### Version 2.15
- Attempted to fix issue with random TimeoutExceptions being thrown in OwnerGiveawayMessageUpdaterService.cs (fatal error)
- Added $ardm - Anti-raid direct message configuration. Allows server administrators to configure a message that will be sent 
    to all users actioned by the Kaguya Anti-Raid Service for their server. Use $h ardm for more information.

### Version 2.14.3
- $userblacklist is now marked as OwnerOnly (...oops!)

### Version 2.14.2
- Added the ability to disable individual commands (only at compile-time).
- Added some more helpful information to the bottom of the $help command.
- Disabled a majority of the music commands, as they are erroring out without helpful information.

### Version 2.14.1
- Reverted implementation of $poker. It's too buggy to be in production.

### Version 2.14
- The $clear response message was displaying +1 message cleared than the user requested. Ex: $c 4 -> "You cleared 5 messages". This has been fixed.
- The users count in $stats (for both total count and per-shard counts) were inconsistent with what was shown in the GameRotationService.
- Created a new $poker game - Play Texas Hold'em against Kaguya!

### Version 2.13.1
- Fixed a bug where users would not be reminded to $vote for Kaguya on the first day of each month.

### Version 2.13
- $deleteunusedroles no longer sends an unnecessary notification about the confirmation message's reactions. The admin has 60s to make a decision.
- $deleteunusedroles now ignores the "kaguya-mute" role.
- Added $deletetrack - removes tracks from the music queue.
- Added $delfav - removes tracks from your $favls list.
- Cleared up some ambiguous (technical) error messages with some of the music commands.
- Added more specific/helpful command responses for different types of unhandled command errors.
    - Example: Passing in the wrong amount of arguments into a command.

### Version 2.12.4
- Fixed annoying error message with $clear (it would display itself nearly every time.) This will now only display if the user attempts to delete messages older than 14 days.
- Fixes a bug with the Kaguya Premium automated role handler where the bot would hard crash if the user wasn't in the server.

### Version 2.12.3
- Fixes a bug where Kaguya Premium servers could not use basic administration tools (mute, ban, unmute, shadowban, etc.) if any of the following applied to the server:
    - Invalid ModLog channel
    - Unset ModLog channel
        - (ModLog = $log modlog <channel>)

### Version 2.12.2
- Kaguya will now auto-eject from Discord Servers who do not give her permission to send messages.
- Attempts to fix an issue with some servers being unable to $mute or $unmute users.

### Version 2.12.1
- Reimplements Kaguya Premium expiration notification service.

### Version 2.12
- $osutop now no longer requires the number of plays to be passed into the command.
    - Example: $osutop <player> now works. Previously you had to specify a playcount to display like so: $osutop <num> <player>
- The profile picture shown from $profile is now more precisely and more consistently centered and sized.
- Added $favoritetrack - Users can "favorite" the currently playing song in a playlist.
- Added $favoriteslist - Users can see all of the tracks they have favorited via this command.
- Added $playfavorite - Users can play songs from their favorites playlist via this command.
- Altered command error messages to be a little more helpful.
- $nsfw now will only invoke if the user has recently voted on top.gg, but there is no longer an image limit. Premium users still have unlimited NSFW access with tags.
- Added $premium
- Some commands now require a recent upvote in order to use them.

### Version 2.11
- Added $masskick
- Added $massban

### Version 2.10
- Added functionality for owner points/exp giveaways (reaction-based).
- Reworded some of the values in $myfish to more clearly state what each value actually modifies.
- Removed the tax mechanic from the fishing game altogether.
- Fixed some wording in the $fish and $sellfish responses. Improves user experience and clarity on how many points they got/have now.
- Removed $buybait - it now simply costs you points each time you fish, instead of having to take the extra step of buying bait!
- Fish luck increases (and other bonuses) now only change every time you level up your fishing level, instead of scaling with your fishing exp directly.

### Version 2.9.3
- Both custom Discord emotes and standard emojis are now supported as reaction role icons.

### Version 2.9.2
- Changed the way servers and users are determined to be premium. 
    This fixes a bug where servers that had multiple keys redeemed in them would not have their time stack. 
    Users also could not stack Kaguya Premium time properly. This was because a user was determined to be premium 
    based on the Key's expiration date. If you redeemed 2 30-day keys at the same time, they would expire at the same time. 
    Now each user and server has a premium expiration time that will stack for each key redeemed 
    instead of the times being tied to the keys themselves.

### Version 2.9.1
- Changed some commands and responses to mention users (not ping them) instead of having user data written as plain text.
- Fixed formatting of some error responses.

### Version 2.9
- Rewrote lots of inconsistent wording of the Kaguya premium subscription.
- Enhanced $checkexpiration

### Version 2.8.1
- Updated the algorithm for $pgen (owner only)

### Version 2.8
- Fixed a bug where '$h inrole' would throw an error.
- Fixed a bug where the "dev invite" for Kaguya was not assigned to the correct link (owner only).
- New command: $coinflip - flip a coin!
- Users may now give their $daily loot to someone else by mentioning them or typing their name.
- $loop now has an alias of 'repeat'
- $loop will now place the looped song(s) directly after the currently playing track instead of at the end of the queue.
- Removed extra line ("Track Name") in $loop response. It was a duplicate of the "Title" line.
- $h crr has been updated to be a little more readable.

### Version 2.7.5
- Fixed an issue with $rlog VoiceChannelConnections where the command would not execute.

### Version 2.7.4
- Fixed a bug where the expiration date when using $redeem on a Premium Key would be incorrect.
- Adjusted the ratelimit so that it works better with the actual Discord rate limit.
- Ensured that a user who is spamming commands will not be ratelimited multiple times for a single "spam offence".
- Premium subscribers now gain access to unlimited role rewards.
- $addpoints command has been created. Owner only.

### Version 2.7.3
- Fixed a bug where commands with reactions attached to them would not execute.

### Version 2.7.2
- Updated the Discord.NET Library to the development build which solves the "Server requested a reconnect" issue. This issue effected each shard independently and would cancel any active music players and leave them in a broken state. This issue would occur once every hour on average, per shard.

### Version 2.7.1
- Updated Victoria (music service). Hopefully will be more stable/have bugs fixed.

### Version 2.7
- New feature: Reaction Roles.
- Create a reaction role through the $createreactionrole [crr] command!
    - Please inform @Stage of any bugs you encounter with this feature if you find some.

### Version 2.6.6
- Fixed a bug with the antiraid service where, if the antiraid service attempted to action a user that was no longer in the server, the bot would crash.

### Version 2.6.5
- Fixed a bug with $recent not showing the proper time for when the play was performed.

### Version 2.6.4
- Fixed a bug with $stats that would prevent it from executing. The speed of this command has also increased as some data is now cached.
- Added owner only $advertisestream command.

### Version 2.6.3
- Fixed a bug with $h tg where the help command could not be displayed.
- Fixed a bug where interactive reactions would not work.

### Version 2.6.2
- Fixed a bug with $fr where phrases wouldn't be removed.
- Fixed a bug with $dice where losers would still be given points as if they had won.

### Version 2.6.1
- Removed discriminators from all public leaderboards in an effort to protect the privacy of users.

### Version 2.6
- New command: $weekly - Receive weekly bonus points! (Premium only)
- Fixed a bug where the wrong cooldown was displayed when trying to use NSFW images.
- Updated cooldown message for $dailyloot.
- Reversed some changes relating to fish bait cost % increases. I did some math and on average, this should result in very balanced fish bait costs/values for fish.

### Version 2.5.2
- Forces the database query for $sellfish to be synchronous, hopefully fixing the existing bug where sometimes a user's fish can be sold yet the points aren't added.

### Version 2.5.1
- Attempted to fix the bug with $sf all where points would sometimes not be added to the user's account.
- When catching a new fish, the untaxed fish value is now shown with a proper label.

### Version 2.5
- $flb now shows how many total fish the top 10 users have caught.
- Reduced the amount of fish EXP players earn when catching a giant squid or big kahuna.
- Fixed an issue where there was a very very small chance to roll for a bait stolen event when the player should have earned a "devils hole pupfish" event.
- Increased the rate at which Triggerfish, Red Drum, Large Salmon, Large Bass, Catfish, Small Salmon, Small Bass, Pinfish, and Seaweed are caught by 3%.
- The chance to catch a Giant Sea Bass is now 3.5% (was 2%)
- The chance to catch a Smalltooth Sawfish is now 2.5% (was 2%)
- The chance to catch an Orante Sleeper Ray is now 0.45% (was 0.2%)
- The chance to catch a Giant Squid is now 0.2% (was 0.15%)
- Reduced the rate of the Bait Stolen fishing event by 3%.
- The base points value of the Giant Squid is now 20,000 (was 25,000)
- Reworked the $fish and $sellfish tax system. Now, all fish are taxed by 40% of their catch price, assuming you are level 0. As you rank up your fishing level, your "fish tax reduction %", seen via $myfish, displays how much % off of the 40% tax you have. So if you have 50% tax reduction, your fish will only be taxed for 20% of their sale price. If you have the max value, 100% off, your fish will no longer be taxed at all.
- The max amount of $fishbait cost increase has been set to 600% (was 1150%)
- The rate at which a user's bait cost will increase has been slowed down by 50%, meaning it will now take twice as many levels to reach the same bait cost % increase.
- The rate at which a user's base fish value will go up has been slowed down by 20%. 

### Version 2.4.4
- Fixed a bug with $help where it would error on use for all users.

### Version 2.4.3
- Fixed a bug where Kaguya Premium users could not play the $dice game.

### Version 2.4.2
- $ban now only allows users to ban one user at a time, but now provides support for ban reasons.
- $kick now only allows users to kick one user at a time, but now provides support for kick reasons.
- Possibly fixed a bug where users who sold multiple fish at once wouldn't receive their payout. This *might* have been due to too many concurrent database connections being made at once. This patch attempts to fix this.

### Version 2.4.1
- Fixed a small text error with $dice.

### Version 2.4
- Axed "Kaguya Supporter" system - everything now falls under one subscription: "Kaguya Premium".
    - Kaguya Premium works the same as normal, but now all Kaguya Supporter perks will apply to the *redeemer* of the key.
    - Kaguya Premium is now the only thing able to be purchased from the online store.
- Fixed a bug with $nsfw bomb where it would break if tags were appended.
- Fixed a bug where users would not receive their Kaguya Premium role automatically.
- Fixed a bug where users who no longer have Kaguya Premium wouldn't have their role removed in the Kaguya Support discord server.
- All Kaguya Premium commands are now displayed in their respective command categories, rather than on a separate command page list. All premium commands will have a `{$}` appended to the end of them, after the aliases.
- Fixed a bug where if a user had multiple active Kaguya Premium keys, they would be DM'd as soon as any one of them expired. Now the user will only be notified if all other keys have run out and they are no longer a premium user.
- *Note: The benefits described below do not apply to the Kaguya Support server.*
- Kaguya Premium servers now grant +5% luck to all betting events.
- Kaguya Premium servers now grant +5% luck to all fishing events.
- Kaguya Premium servers now grant +50% bonus to all points and EXP received from $daily.
- Kaguya Premium key redeemers now have priority DM support (DM Stage with any questions or concerns!). Stage will not respond to DMs from non-premium users if related to Kaguya.
- Kaguya Premium key redeemers now receive +100% bonus EXP and points when using $upvote
- New command: $choose
- New command: $reverse
- New game: $dice

### Version 2.3.2
- Added lots of redundancy against crashes that occur in relation to being unable to send users direct messages. (This has gone on for too long!!)

### Version 2.3.1
- Fixed a fatal error where the bot would crash if an attempt was made to send a reminder to a user who no longer shared any guilds with the bot.

### Version 2.3
- **New command:** $myreminders [reminders][mr] -- Allows users to view and delete any existing reminders they have.
- Fixed a bug where users in the Kaguya Support discord server would not get their supporter/premium roles automatically added/removed to/from them when it was necessary.
- **New command:** $addquote [aq] -- Allows users with the manage messages permission to add quotes for their server!
- **New command:** $randomquote [rq] -- Allows users to view a random quote from the server, no permissions needed.
- **New command:** $removequote [deletequote] [dq] [rq] -- Allows users with the manage messages permission to remove quotes from the server.
- **New command:** $allquotes [listquotes] [quotes] -- Allows users with the manage messages permission to view all quotes for the current server.
- Reminders will now be sent in sentence casing, rather than all lower case letters.

### Version 2.2
- New command: $exp -- Allows users to quickly view their global and server exp and ranks.

### Version 2.1.4
- Fixed a bug where after mass-selling a specific fish type, an error message would be thrown stating that the reactions for the confirmation message have been disabled.

### Version 2.1.3
- Slightly tweaked appearance of $flb leaderboard to match the other leaderboard commands.

### Version 2.1.2
- Fixed bug with $fishleaderboard where "Unknown User" would be shown if the user wasn't in the server the command was executed in.

### Version 2.1.1
- Added even more unhandled exception logging (so solutions to problems can be found faster)
- Added a new command: $fishleaderboard [$flb]

### Version 2.1
- Removed April Fool's "uwu-ify'd" text.
- Fixed a bug where it was impossible to sell a fish by their type. Now if you want to sell a specific fish type, you can use `$sell <type>`. Example: `$sell giant sea bass` or `$sell small_salmon`. You can replace the underscores with spaces for the fish types.
- Upvoting on top.gg will now reward users with a constant 750 points and 500 exp. Was formerly...Points: Random between 150-700 | Exp: Random between 75-350.
- Fixed a bug where songs wouldn't automatically play after each other when queued.
- $ss "date created" value is now much more exact.
- **NEW COMMAND:** `$loop` -- Allows a user to repeat a song up to 10 times. Use $h loop for more info!

### Version 2.0.12
- Patched a bug where, when using $scg, if the greeting was already enabled for the server, the footer of the response embed would still show that the server had to use "$tg" in order to enable it.
- Other small improvements.

### Version 2.0.11
- Fixed a fatal error where, upon trying to automatically execute a warnaction after a user reaches the specified "warn threshold" (to auto kick, ban, mute, or shadowban), the bot would crash. This would occur if a guild didn't have Kaguya's permissions set properly. Now, the error will be logged but no action will be taken against the warned user.

### Version 2.0.10
- Fixed a fatal bug where Kaguya would repeatedly crash - this was because the antiraid service was trying to action users that it wasn't supposed to (because they weren't in the server anymore).

### Version 2.0.9
- Added ability for bot owner(s) to blacklist users.

### Version 2.0.8
- Patched an exploit that allowed users to sell the same fish (via ID) over and over.

### Version 2.0.7
- Cleaned up some console logging issues (users won't notice this)
- $daily now rewards a constant 750 points and 275 exp. (Was 35-700 points and 8-112 exp.)
- Fixed a bug where after using $unwarn, a unnecessary notification would be sent after 5 minutes.
- If any of the GIF commands are used without a target, it will now show that you "<action>ed the air!".
- Fixed a fatal bug where Kaguya would crash if it could not send ratelimit DMs to users.

### Version 2.0.6
- If the server's custom greeting is disabled when they set a new greeting, they will be given a clear message displaying that the message needs to be enabled via a separate command.
- Generic stats now logged to database.
- Kaguya will now DM owners with a brief message whenever she joins a new guild.

### Version 2.0.5
- Top.gg stats are now posted every 15 minutes (server and shard counts).
- `$remindme` time responses are now more precise.
- When catching a fish, the "you now have `x` fish" dialogue now accounts for whether you have previously sold fish, meaning it won't tell you you have a certain count of the fish if you've previously sold it.
- Made adjustments to fish level-up rewards. Here's what changed if you were fish level 15: 
    - `6.12% increased chance to catch a rare fish (was 4.54%)`
    - `31.30% base increased fish value (was 28.98%)`
    - `10.00% decreased tax penalty when selling a fish (was 7.50%)`
    - `117.10% increased bait cost (was 143.42%)`
    I made these changes as players would consistently lose a lot of points if they were fishing often. More balance changes will come if needed to these values and even the direct values of some fish, if needed.
- Giant squids and Big Kahunas will now reward many more points (about double) if caught.

### Version 2.0.4
- Got rid of TwitchNotifications logtype - it was accidentally left in the production build.

### Version 2.0.3
- NSFW images are now earned at a rate of 1 every 15 minutes for non-supporters (compared to 1 every 2 hours).

### Version 2.0.2
- Fixed a bug where users weren't getting points or exp for voting (this is separate, but related, to the notification bug that was patched in v2.0.1).
- Fixed a bug where the NSFW image handler timer would not auto reset.

### Version 2.0.1
- Fixed a bug where the $buybait command was displaying an incorrect maximum value for how much bait you could buy based on how many points you have.
- "Total value" renamed to "taxed value" on $myfish.
- Fixed a bug where, upon attempt to buy more bait than your baitbox can hold, the error message would not be thrown.
- Command added to view active Kaguya Supporter / Kaguya Premium subscriptions: $checkexpiration [ce]
- Fixed a bug where $nsfw bomb [tags] wouldn't check for whether the user was a Kaguya Supporter, resulting in a finite usage of the command.
- Fixed a bug where tagged $nsfw bomb usages would never send any images for any user.
- Fixed a bug where, if you had more than one Kaguya Supporter key active at a time, your subscription would essentially count down twice as fast.
- Fixed a bug where the thread for top.gg upvote notifications would break and never be restarted, resulting in lost rewards for voting.
- Fixed a bug where "Message Updated" logs would get sent for messages even if the content of the message (text) hadn't changed.
- Added $faq command.
