using System;
using System.Collections.Generic;

namespace MaximumNumberOfEatenApples
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] apples = {1, 2, 3, 5, 2};
            int[] days = {3, 2, 1, 4, 2};
            Console.WriteLine(EatenApples_SortedList(apples, days));
        }

        static int EatenApples_SortedList(int[] apples, int[] days)
        {
            var list = new SortedList<int, int>();
            int curDay = 0, res = 0;
            while (list.Count > 0 || curDay < apples.Length)
            {
                while (list.Count > 0 && list.Keys[0] < curDay)
                    list.Remove(list.Keys[0]);
                if (curDay < apples.Length && apples[curDay] != 0)
                {
                    list[curDay + days[curDay] - 1] = list.ContainsKey(curDay + days[curDay] - 1)
                        ? list[curDay + days[curDay] - 1] + apples[curDay]
                        : apples[curDay];
                }
                if (list.Count > 0)
                {
                    res++;
                    list[list.Keys[0]]--;
                    if (list[list.Keys[0]] == 0)
                        list.Remove(list.Keys[0]);
                }
                curDay++;
            }
            return res;
        }
    }
}
