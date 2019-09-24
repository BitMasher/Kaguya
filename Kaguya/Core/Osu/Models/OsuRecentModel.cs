﻿using System;

namespace Kaguya.Core.Osu.Models
{
    public class OsuRecentModel : OsuScoreableModel
    {
        public int beatmap_id { get; set; }
        public int score { get; set; }
        public string rounded_score { get; set; }
        public int maxcombo { get; set; }
        public string perfect { get; set; }
        public int enabled_mods { get; set; }
        public string string_mods { get; set; }
        public string user_id { get; set; }
        public DateTimeOffset date { get; set; }
        public string rank { get; set; }
        public string rankemote { get; set; }
        public double accuracy { get; set; }
        public double pp { get; set; }
        public double fullcombopp { get; set; }
    }
}
