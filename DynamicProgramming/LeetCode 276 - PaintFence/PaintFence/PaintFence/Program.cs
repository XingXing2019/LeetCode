using System;

namespace PaintFence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumWays(int n, int k)
        {
            if (n == 0) return 0;
            int same = 0, diff = k;
            for (int i = 1; i < n; i++)
            {
                int temp = same;
                same = diff;
                diff = (temp + diff) * (k - 1);
            }
            return same + diff;
        }
    }
}
