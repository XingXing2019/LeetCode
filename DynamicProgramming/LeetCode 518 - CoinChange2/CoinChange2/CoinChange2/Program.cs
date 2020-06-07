/*
                0   1   2   3   4   5       需要得到的金额

            0   1   0   0   0   0   0
    
            1   1   1   1   1   1   1   

            2   1   1   2   2   3   3   

            3   1   1   2   2   3   4
        前i种硬币
 */

//创建动态数组dp，dp[i][j]代表用前i种硬币想凑成j金额，有几种方法。
//数组初始化条件为如果有0种硬币，那么除了凑成金额0有一种方法，其余所有金额都是0种方法。如果要凑成金额0，无论有几种硬币都只有一种方法。
//dp[i][j]应该等于不取，取一次，取两次。。。第i种硬币凑成金额j所有方法的总和。所以需要记录dp[i-1][j - coins[i - 1] * times]的总和。
using System;

namespace CoinChange2
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = 5;
            int[] coins = {1, 2, 5};
            Console.WriteLine(Change(amount, coins));
        }

        static int Change(int amount, int[] coins)
        {
            var dp = new int[coins.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[amount + 1];
            for (int i = 0; i < dp.Length; i++)
                dp[i][0] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    int count = 0;
                    int temp = j;
                    while (temp >= 0)
                    {
                        count += dp[i - 1][temp];
                        temp -= coins[i - 1];
                    }
                    dp[i][j] = count;
                }
            }
            return dp[^1][^1];
        }
    }
}
