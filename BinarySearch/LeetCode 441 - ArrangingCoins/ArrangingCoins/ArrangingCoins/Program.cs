//二分搜索寻找结果，但要注意可能会出现溢出，所以要用long型存储数据，最后在强制转换成int型。
using System;

namespace ArrangingCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            Console.WriteLine(ArrangeCoins(n));
        }
        static int ArrangeCoins(int n)
        {
            if(n == 0)
                return 0;
            long li = 1, hi = n;
            while (li < hi)
            {
                long mid = li + (hi - li) / 2;
                long tem = (1 + mid) * mid / 2 + mid + 1;
                if (tem > n)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return (int)li;
        }
    }
}
