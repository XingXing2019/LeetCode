using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _24Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cards = { 7, 2, 6, 6 };
            Console.WriteLine(JudgePoint24(cards));
        }
        public static bool JudgePoint24(int[] cards)
        {
            return Calculate(cards.Select(x => (double)x).ToList());
        }

        private static bool Calculate(List<double> cards)
        {
            if (cards.Count == 1 && Math.Round(cards[0], 2) == 24)
                return true;
            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = 0; j < cards.Count; j++)
                {
                    if (i == j) continue;
                    var newCards = cards.Where((t, k) => k != i && k != j).ToList();
                    for (int k = 0; k < 4; k++)
                    {
                        if (k == 0) newCards.Add(cards[i] + cards[j]);   
                        else if (k == 1) newCards.Add(cards[i] - cards[j]);   
                        else if (k == 2) newCards.Add(cards[i] * cards[j]);   
                        else if (k == 3) newCards.Add(cards[i] / cards[j]);
                        if (Calculate(newCards))
                            return true;
                        newCards.RemoveAt(newCards.Count - 1);
                    }
                }
            }
            return false;
        }

        //private static bool Calculate(double[] cards, HashSet<int> visited, double res)
        //{
        //    if (visited.Count == cards.Length && res == 24)
        //        return true;
        //    for (int i = 0; i < cards.Length; i++)
        //    {
        //        if (!visited.Add(i)) continue;
        //        if (Calculate(cards, visited, res + cards[i]))
        //            return true;
        //        if (Calculate(cards, visited, res - cards[i]))
        //            return true;
        //        if (Calculate(cards, visited, res * cards[i]))
        //            return true;
        //        if (Calculate(cards, visited, res / cards[i]))
        //            return true;
        //        visited.Remove(i);
        //    }
        //    return false;
        //}
    }
}
