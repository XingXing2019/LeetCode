//思路为动态规划思想，创建dpMin用于记录达到每个amount所需的最小数量。dpMin[i]的值应为dpMin[i - coins[j]]中最小值加1。
//就是说想要达到现在i的最小数量，就是让i所对应的的金额减去coins中所有的面值后，在这些所对应金额中找到一个需要最小数量的金额，让其所对应的的数量在加1(刚才减去的面值)。
//创建dpMin数组，其长度设为amount+1，代表从0到amount所有金额所需的最少coin数量。将所有元素初始值设为-1。
//将0金额设为0，coins中所有面值所对应的的金额设为1。代表达到金额0，需要0枚硬币。达到coins中所存储的面值，只需1枚coins中面值的硬币。
//用i指针从金额1开始遍历数组，创建min记录最小所需硬币数量，初始值设为int.MaxValue。
//用j指针遍历coins，在当前金额i不小于j所指向面值(防止出现越界情况)，以及dpMin中所记录的i-coins[j]不为-1(证明该金额已经可以达到)时，如果dpMin[i - coins[j]]所需硬币数量小于min，则用其替换min。
//在对j遍历结束后，要达到当前i金额所需最少硬币数量就是min + 1。
//最后返回dpMin中amount所对应的最小硬币数量即可。
using System;
using System.Linq;

namespace CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 1 };
            int amount = 0;
            Console.WriteLine(CoinChange(coins, amount));
        }
        static int CoinChange(int[] coins, int amount)
        {
            var dp = new int[amount + 1];
            for (int i = 1; i < dp.Length; i++)
                dp[i] = -1;
            for (int i = 0; i < coins.Length && coins[i] <= amount; i++)
                dp[coins[i]] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                if(dp[i] == 1) continue;
                int min = int.MaxValue;
                for (int j = 0; j < coins.Length; j++)
                {
                    if(i - coins[j] < 0 || dp[i - coins[j]] == -1)
                        continue;
                    min = Math.Min(min, dp[i - coins[j]] + 1);
                }
                dp[i] = min == int.MaxValue ? -1 : min;
            }
            return dp[amount];
        }
    }
}
