//当n为奇数时，他对4取只可能为1或者3，如果为1则令n减一，如果为3，则令n加一。目的确保n除以2之后还能得到一个偶数。
using System;

namespace IntegerReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Console.WriteLine(IntegerReplacement(n));
        }
        static int IntegerReplacement(int n)
        {
            if (n == int.MaxValue)
                return 32;
            int count = 0;
            while (n != 1)
            {
                if (n % 2 == 0)
                    n /= 2;
                else if (n == 3)
                    n--;
                else
                    n += n % 4 == 3 ? 1 : -1;
                count++;
            }
            return count;
        }
        static int IntegerReplacement2(int n)
        {
            if (n == 1)
                return 0;
            if (n == int.MaxValue)
                return 32;
            if (n % 2 == 0)
                return 1 + IntegerReplacement(n / 2);
            return 1 + Math.Min(IntegerReplacement(n + 1), IntegerReplacement(n - 1));
        }

        static int IntegerReplacement3(int n)
        {
            if (n == 1)
                return 0;
            var dp = new int[n + 1];
            dp[2] = 1;
            for (int i = 3; i < dp.Length; i++)
            {
                if (i % 2 == 0)
                    dp[i] = dp[i / 2] + 1;
                else
                    dp[i] = Math.Min(dp[i - 1] + 1, dp[(i + 1) / 2] + 2);
            }
            return dp[^1];
        }
    }
}
