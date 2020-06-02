//遍历weights，找到其中的最大值max和总重量sum。则如果运载为max需要weights.Length天，如果运载为sum需要1天。那么合适的重量一定在max和sum之间，使用二分搜索可以吉所建运算时间。
//在max小于sum的条件下遍历，先计算出二者中值mid。创建day记录天数，初始值设为1。创建weight记录当前货物总重。
//遍历weights将当前货物重量加入weight，如果weight超过mid，则令day加一，代表需要多加一天。并且令weight等于当前货物重量。这样会得到以mid为运载需要几天。
//如果day大于D，证明mid太小，则令max等于mid加一。否则证明mid太大，则令sum等于mid。
//最后返回max即为结果。
using System;

namespace CapacityToShipPackagesWithinDDays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int D = 5;
            Console.WriteLine(ShipWithinDays(weights, D));
        }
        static int ShipWithinDays(int[] weights, int D)
        {
            int max = 0;
            int sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                max = Math.Max(max, weights[i]);
                sum += weights[i];
            }
            while (max < sum)
            {
                int mid = max + (sum - max) / 2;
                int day = 1;
                int weight = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    weight += weights[i];
                    if(weight > mid)
                    {
                        day++;
                        weight = weights[i];
                    }
                }
                if (day > D)
                    max = mid + 1;
                else
                    sum = mid;
            }
            return max;
        }
    }
}
