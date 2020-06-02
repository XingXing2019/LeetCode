//解题关键为理解水槽最大蓄水量是由短板决定的。需要避免暴力算法。
//设置left和right为数组头和数组尾，代表左右两板的位置。设置max代表最大蓄水量。
//在left和right不重合的条件下遍历数组。
//比较left和right在数组中所代表的的数字，取较小的数字作为短板。
//如果短板高度乘以left和right的间距大于max，则替换max。
//之后比较两板的高度，移动较短的板，以求找到长板可以提高蓄水量。
//暴力解法可以再数组长度小于2000的情况下优于这种接法，当数组长度大于10000时，暴力算法所需时间及长。
using System;
using System.Diagnostics;

namespace ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] heigth = new int[10000];
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            Console.WriteLine(MaxArea1(heigth));
            stopwatch1.Stop();
            Console.WriteLine(stopwatch1.ElapsedMilliseconds);
            Console.WriteLine("");
            stopwatch2.Start();
            Console.WriteLine(MaxArea2(heigth));
            stopwatch2.Stop();
            Console.WriteLine(stopwatch2.ElapsedMilliseconds);

        }
        static int MaxArea1(int[] height)
        {
            if (height.Length == 0)
                return 0;
            int left = 0;
            int right = height.Length - 1;
            int max = 0;
            while (left != right)
            {
                int shorterSide = Math.Min(height[left], height[right]);
                if (shorterSide * (right - left) > max)
                    max = shorterSide * (right - left);
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }
            return max;
        }
        static int MaxArea2(int[] height)
        {
            int max = 0;
            for (int left = 0; left < height.Length; left++)
            {
                for (int right = left + 1; right < height.Length; right++)
                {
                    int shorterSide = Math.Min(height[left], height[right]);
                    if (shorterSide * (right - left) > max)
                        max = shorterSide * (right - left);
                }
            }
            return max;
        }
    }
}
