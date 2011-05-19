using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoyScouts.Models;

namespace BoyScouts.Messages
{
    public class RankSelectedMessage
    {
        public Rank Rank { get; private set; }

        public RankSelectedMessage(Rank rank)
        {
            Rank = rank;
        }
    }
}