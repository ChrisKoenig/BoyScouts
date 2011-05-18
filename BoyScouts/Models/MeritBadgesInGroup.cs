using System;
using System.Collections.Generic;

namespace BoyScouts.Models
{
    public class MeritBadgesInGroup : List<MeritBadge>
    {
        public MeritBadgesInGroup(string category)
        {
            Key = category;
        }

        public string Key { get; set; }

        public bool HasItems { get { return Count > 0; } }
    }
}