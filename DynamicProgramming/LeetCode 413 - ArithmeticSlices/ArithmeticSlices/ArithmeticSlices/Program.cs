//创建动态数组dp，代表以每个数字为结尾的数组中有多少个等差数组。创建diff记录公差，初始值设为A中前两个数字之差。创建count记录连续等差数组中数字的个数，初始值设为2。
//从第三个数字开始遍历。如果当前数字与其前一数字之差等于diff，则令count加一。如果count大于等于3则将dp[i]设为dp[i-1] + count - 2。否则为dp[i-1].
//如果当前数字与其前一数字之差不等于diff，则令count等于2，并将diff更新为当前数字与其前一数字之差。并将dp[i]设为dp[i-1]。
//最后返回dp中最后一个数字。
//第二种方法为创建dp数组代表当前数字能与其前面数字组成等差数组的个数。创建sum记录等差数组的总和。
//从第三个数字开始遍历。如果其能与之前两个的数字组成等差数组，则将dp[i]设为dp[i-1]+1。并将其加入sum。
//最后返回sum。
using System;

namespace ArithmeticSlices
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 3, -1, -5, -9 };
            Console.WriteLine(NumberOfArithmeticSlices1(A));
        }        
        static int NumberOfArithmeticSlices1(int[] A)
        {
            if (A.Length < 3)
                return 0;
            int[] dp = new int[A.Length];
            int diff = A[1] - A[0];
            int count = 2;
            for (int i = 2; i < dp.Length; i++)
            {
                if(A[i] - A[i - 1] == diff)
                {
                    count++;
                    if (count >= 3)
                        dp[i] = dp[i - 1] + (count - 2);
                    else
                        dp[i] = dp[i - 1];
                }
                else
                {
                    count = 2;
                    diff = A[i] - A[i - 1];
                    dp[i] = dp[i - 1];
                }
            }
            return dp[dp.Length - 1];
        }
        static int NumberOfArithmeticSlices2(int[] A)
        {
            int sum = 0;
            int[] dp = new int[A.Length];
            for (int i = 2; i < dp.Length; i++)
            {
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                {
                    dp[i] = dp[i - 1] + 1;
                    sum += dp[i];
                }
            }
            return sum;
        }
    }
}
