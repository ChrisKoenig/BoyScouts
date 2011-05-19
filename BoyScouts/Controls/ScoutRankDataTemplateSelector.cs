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
using BoyScouts.Controls;
using BoyScouts.Models;

namespace BoyScouts.Controls
{
    public class ScoutRankDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Odd { get; set; }

        public DataTemplate Even { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Rank rank = item as Rank;

            if (rank == null)
                return base.SelectTemplate(item, container);

            if (rank.SequenceNumber % 2 == 0)
                return Even;
            else
                return Odd;
        }
    }
}