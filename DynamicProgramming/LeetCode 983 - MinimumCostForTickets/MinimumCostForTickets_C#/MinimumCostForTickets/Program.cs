//创建dpMin数组记录到第i天为止，所需的最少花销。对于第i天有两种状态，如果不出行，在第i天的最小花销等于他前一天的最小花销。
//如果第i天出行，则有三种买票选择，第一种为只买1天的票，则第i天的最小花销为dpMin[i - 1] + costs[0]。
//第二种选择为买7天票。则第i天的前7天都不再需要考虑，那么第i天的最小花销为dpMin[i - 7] + costs[1]。
//第三种选择为买30天票，则第i天的前30天都不再需要考虑，那么第i天的最小花销为dpMin[i - 30] + costs[2]。
//对于第i天的最小花销，选择三种选择中最小的一个。
//代码实现过程中需要注意不要越界，可以用dpMin[Math.Max(0, i - 7)]实现。则当出现i - 7小于0的情况是会用0代替。
//还需创建bool数组，记录每天的出行情况。
using System;

namespace MinimumCostForTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] days = { 1, 4, 6, 7, 8, 20 };
            int[] costs = { 2, 7, 15 };
            Console.WriteLine(MincostTickets(days, costs));
        }
        static int MincostTickets(int[] days, int[] costs)
        {
            bool[] travelOrNot = new bool[366];
            for (int i = 0; i < days.Length; i++)
                travelOrNot[days[i]] = true;
            int[] dpMin = new int[366];
            for (int i = 1; i <= days[days.Length - 1]; i++)
            {
                if (travelOrNot[i])
                {
                    int choiceOne = dpMin[i - 1] + costs[0];
                    int choiceTwo = dpMin[Math.Max(0, i - 7)] + costs[1];
                    int choiceThree = dpMin[Math.Max(0, i - 30)] + costs[2];
                    dpMin[i] = Math.Min(Math.Min(choiceOne, choiceTwo), choiceThree);
                }
                else
                    dpMin[i] = dpMin[i - 1];
            }
            return dpMin[days[days.Length - 1]];
        }
    }
}
