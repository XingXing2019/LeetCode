//贪心算法。创建一个大小为最大的difficulty+1的数组record，将每个难度对应的最大收益记录入数组。
//遍历record，用一个p变量记录之前找到的最大收益。如果发现当前难度收益不如之前较小难度收益，则替换之。
//遍历worker，将其能力所及的profit加入结果。
using System;
using System.Linq;

namespace MostProfitAssigningWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] difficulty = { 66, 1, 28, 73, 53, 35, 45, 60, 100, 44, 59, 94, 27, 88, 7, 18, 83, 18, 72, 63 };
            int[] profit = { 66, 20, 84, 81, 56, 40, 37, 82, 53, 45, 43, 96, 67, 27, 12, 54, 98, 19, 47, 77 };
            int[] worker = { 61, 33, 68, 38, 63, 45, 1, 10, 53, 23, 66, 70, 14, 51, 94, 18, 28, 78, 100, 16 };
            Console.WriteLine(MaxProfitAssignment(difficulty, profit, worker));
        }
        static int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            int res = 0;
            int maxDifficulty = difficulty.Max(d => d);
            int[] record = new int[maxDifficulty + 1];
            for (int i = 0; i < difficulty.Length; i++)
                record[difficulty[i]] = Math.Max(record[difficulty[i]], profit[i]);
            int p = record[0];
            for (int i = 0; i < record.Length; i++)
            {
                p = Math.Max(p, record[i]);
                record[i] = Math.Max(p, record[i]);
            }
            for (int i = 0; i < worker.Length; i++)
            {
                int index = Math.Min(record.Length - 1, worker[i]);
                res += record[index];
            }
            return res;
        }
    }
}
