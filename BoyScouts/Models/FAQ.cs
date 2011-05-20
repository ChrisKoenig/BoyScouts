using System;
using System.Collections.Generic;

namespace BoyScouts.Model
{
    public class FAQ
    {
        public string Question { get; set; }

        public List<Answer> Answers { get; set; }
    }

    public class Answer
    {
        public string Description { get; set; }

        public Citation Citation { get; set; }
    }

    public class Citation
    {
        public string Text { get; set; }

        public string Link { get; set; }
    }
}