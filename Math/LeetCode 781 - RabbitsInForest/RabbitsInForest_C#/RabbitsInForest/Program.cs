//颜色相同的兔子答案一定相同。相反，答案相同的兔子颜色不一定相同。但是，答案不同的兔子颜色一定不同。
//如果有答案为n的兔子个数有x个，则最优解为给x个兔子分组，每组最多有n+1个兔子。
//那么为此答案兔子的最少数量就为(n+1)*分组的个数。
//创建record统计答案相同兔子的数量。然后遍历record，如果当前答案对应的值不为0，则计算最少的分组数。并将其乘以(i+1)计入结果。
using System;

namespace RabbitsInForest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumRabbits(int[] answers)
        {
            int[] record = new int[1000];
            int res = 0;
            foreach (var ans in answers)
                record[ans]++;
            for (int i = 0; i < record.Length; i++)
            {
                if(record[i] != 0)
                {
                    int tem = record[i] % (i + 1) == 0 ? record[i] / (i + 1) : record[i] / (i + 1) + 1;
                    res += (i + 1) * tem;
                }
            }
            return res;
        }
    }
}
