using System;
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
    public class Rank
    {
        public int SequenceNumber { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Requirements { get; set; }
    }
}