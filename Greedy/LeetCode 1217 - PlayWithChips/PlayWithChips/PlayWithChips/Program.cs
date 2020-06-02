//统计奇数和偶数的个数，返回较少的个数。
using System;

namespace PlayWithChips
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinCostToMoveChips(int[] chips)
        {
            int odd = 0, even = 0;
            for (int i = 0; i < chips.Length; i++)
            {
                if (chips[i] % 2 == 0)
                    even++;
                else
                    odd++;
            }
            return Math.Min(even, odd);
        }
    }
}
