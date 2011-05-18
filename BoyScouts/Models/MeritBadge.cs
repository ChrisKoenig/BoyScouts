using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoyScouts.Models
{
    public class MeritBadge
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsEagleRequired { get; set; }

        public string HandbookUrl { get; set; }

        public string Key
        {
            get
            {
                return Name.Substring(0, 1);
            }
        }
    }
}