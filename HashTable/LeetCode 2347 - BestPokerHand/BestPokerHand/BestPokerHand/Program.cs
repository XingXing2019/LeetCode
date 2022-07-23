using System;
using System.Linq;

namespace BestPokerHand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string BestHand(int[] ranks, char[] suits)
        {
            var suitDict = suits.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var rankDict = ranks.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            if (suitDict.Any(x => x.Value == 5))
                return "Flush";
            if (rankDict.Any(x => x.Value >= 3))
                return "Three of a Kind";
            if (rankDict.Any(x => x.Value >= 2))
                return "Pair";
            return "High Card";
        }
    }
}
