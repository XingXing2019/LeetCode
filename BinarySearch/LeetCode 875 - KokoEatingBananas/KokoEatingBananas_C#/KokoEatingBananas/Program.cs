//首先找到piles中的最大值，如果每小时吃一个，则总时间为piles中所有数字总和。如果每小时吃最大值个，则总时间为piles的长度。
//在最大值和1之间进行二分搜索。找到一个最小值能满足总时间不超过H。
//需要注意计算总时间时要考虑piles中的数字能不能被mid整除，如不能整除，总时间需要加上piles中的数字除以mid再加一。
using System;
using System.Linq;

namespace KokoEatingBananas
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] piles = { 30, 11, 23, 4, 20 };
            int H = 5;
            Console.WriteLine(MinEatingSpeed(piles, H));
        }
        static int MinEatingSpeed(int[] piles, int H)
        {
            int li = 1, hi = piles.Max();
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int hour = 0;
                foreach (var pile in piles)
                    hour += pile % mid == 0 ? pile / mid : pile / mid + 1;
                if (hour > H)
                    li = mid + 1;
                else
                    hi = mid;
            }
            return li;
        }
    }
}
