//创建一个数组saves，用于记录从每个时间开始冷静，能挽救的客人数量。先找到从index为0的时间点开始能挽救多少客人。
//创建maxSave记录最大挽救客人数。originGet记录如果不挽救能得到多少客人。最后结果为二者之和。
//从第二个时间点开始遍历，创建tem设为其前一时间点能挽救的客人数。如果前一时间点暴躁，则tem减去customers[i-1]。如果其X-1个时间点之后暴躁，则tem加上customers[i+X-1]。
//最后将tem设为saves[i]。遍历时需要注意i+X-1不要越界。
using System;

namespace GrumpyBookstoreOwner
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] customers = { 3 };
            int[] grumpy = { 1 };
            int X = 1;
            Console.WriteLine(MaxSatisfied(customers, grumpy, X));
        }
        static int MaxSatisfied(int[] customers, int[] grumpy, int X)
        {
            int[] saves = new int[customers.Length];
            for (int i = 0; i < X; i++)
                if (grumpy[i] == 1)
                    saves[0] += customers[i];
            int maxSave = saves[0];
            int originGet = grumpy[0] == 1 ? 0 : customers[0];
            for (int i = 1; i < customers.Length; i++)
            {
                if (grumpy[i] == 0)
                    originGet += customers[i];
                int tem = saves[i - 1];
                if (grumpy[i - 1] == 1)
                    tem -= customers[i - 1];
                if (i + X - 1 < customers.Length && grumpy[i + X - 1] == 1)
                    tem += customers[i + X - 1];
                saves[i] = tem;
                maxSave = Math.Max(maxSave, saves[i]);
            }
            return originGet + maxSave;
        }
    }
}
