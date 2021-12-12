
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindGoodDaysToRobTheBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] security = { 1, 2, 3, 4, 5, 6 };
            int k = 0;
            Console.WriteLine(GoodDaysToRobBank(security, k));
        }
        public static IList<int> GoodDaysToRobBank(int[] security, int time)
        {
            if (time == 0)
                return security.Select((value, index) => index).ToList();
            int countDesc = 0, countAsc = 0;
            bool[] Desc = new bool[security.Length], Asc = new bool[security.Length];
            for (int i = 1; i < security.Length; i++)
            {
                if (security[i] > security[i - 1])
                    countDesc = 0;
                else
                {
                    countDesc++;
                    if (countDesc >= time)
                        Desc[i] = true;
                }
                if (security[^(i + 1)] > security[^i])
                    countAsc = 0;
                else
                {
                    countAsc++;
                    if (countAsc >= time)
                        Asc[^(i + 1)] = true;
                }
            }
            var res = new List<int>();
            for (int i = 0; i < security.Length; i++)
            {
                if (Desc[i] && Asc[i])
                    res.Add(i);
            }
            return res;
        }
    }
}
