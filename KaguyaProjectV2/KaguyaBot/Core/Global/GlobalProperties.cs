﻿using Discord;
using System;

namespace KaguyaProjectV2.KaguyaBot.Core.Global
{
    /// <summary>
    /// A static class containing helpful objects, such as <see cref="Emoji"/>s that are referenced often.
    /// </summary>
    public static class GlobalProperties
    {
        /// <summary>
        /// Returns an Emoji[8] containing the numeric emojis 1-9.
        /// EmojisOneThroughNine[0] returns the Emoji for "1".
        /// </summary>
        /// <returns></returns>
        public static Emoji[] EmojisOneThroughNine() => new Emoji[]
        {
            new Emoji("1⃣"),
            new Emoji("2⃣"),
            new Emoji("3⃣"),
            new Emoji("4⃣"),
            new Emoji("5⃣"),
            new Emoji("6⃣"),
            new Emoji("7⃣"),
            new Emoji("8⃣"),
            new Emoji("9⃣")
        };

        /// <summary>
        /// The default emoji with reaction replies that use a check mark.
        /// </summary>
        /// <returns></returns>
        public static Emoji CheckMarkEmoji() => new Emoji("✅");

        /// <summary>
        /// The "no-entry" emoji. Default "cancel" emoji reaction for reaction replies.
        /// </summary>
        /// <returns></returns>
        public static Emoji NoEntryEmoji() => new Emoji("⛔");

        /// <summary>
        /// Calculates the Kaguya Exp/Fish level for the provided exp.
        /// </summary>
        /// <param name="userExp"></param>
        /// <returns></returns>
        public static double CalculateLevelFromExp(int userExp)
        {
            if (userExp < 65) // Can't have the square root of a negative!!
                return 0;

            return Math.Sqrt((userExp / 8) - 8);
        }

        /// <summary>
        /// Returns the amount of experience points needed to reach the specified level.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int CalculateExpFromLevel(double level) => (int) (8 * Math.Pow(level, 2)) + 64; // Inverse of CalculateLevel()
    }
}