using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoyScouts.Models;

namespace BoyScouts.Messages
{
    public class MeritBadgeSelectedMessage
    {
        public MeritBadge MeritBadge { get; set; }

        public MeritBadgeSelectedMessage(MeritBadge value)
        {
            // TODO: Complete member initialization
            this.MeritBadge = value;
        }
    }
}