//二分搜索寻找结果，但要注意可能会出现溢出，所以要用long型存储数据，最后在强制转换成int型。
using System;

namespace ArrangingCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            Console.WriteLine(ArrangeCoins_BinarySearch(n));
        }
        static int ArrangeCoins_BinarySearch(int n)
        {
            if (n < 2) return n;
            long li = 0, hi = n;
            while (li < hi)
            {
                long mid = li + (hi - li) / 2;
                long sum = (1 + mid) * mid / 2;
                if (sum > n)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return (int) li - 1;
        }
        static int ArrangeCoins_Math(int n)
        {
            return (int) (Math.Sqrt(1 + 8 * (double) n) - 1) / 2;
        }
    }
}
