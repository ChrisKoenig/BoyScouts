using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BoyScouts.Models
{
    public class MeritBadgesByFirstLetter : List<MeritBadgesInGroup>
    {
        private static readonly string Groups = "#abcdefghijklmnopqrstuvwxyz";

        private Dictionary<int, MeritBadge> _meritBadgeLookup = new Dictionary<int, MeritBadge>();

        public MeritBadgesByFirstLetter(ObservableCollection<MeritBadge> MeritBadges)
        {
            Dictionary<string, MeritBadgesInGroup> groups = new Dictionary<string, MeritBadgesInGroup>();

            foreach (char c in Groups.ToUpper())
            {
                MeritBadgesInGroup group = new MeritBadgesInGroup(c.ToString());
                this.Add(group);
                groups[c.ToString()] = group;
            }

            foreach (MeritBadge MeritBadge in MeritBadges)
            {
                groups[MeritBadge.Name.Substring(0, 1)].Add(MeritBadge);
            }
        }
    }
}