//创建GetCloseDistance方法，运用二分搜索找到一个house与最近heater的距离。
//在主方法中创建radius记录结果。对houses和heaters排序。
//遍历houses，对每一个house调用GetCloseDistance方法，找到离他最近heater与他的距离。如果比radius大就更新radius。最后返回radius。
using System;

namespace Heaters
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static int FindRadius(int[] houses, int[] heaters)
        {
            int radius = 0;
            Array.Sort(houses);
            Array.Sort(heaters);
            foreach (var house in houses)
                radius = Math.Max(radius, GetClosestDistance(house, heaters));
            return radius;
        }
        static int GetClosestDistance(int house, int[] heaters)
        {
            int li = 0;
            int hi = heaters.Length - 1;
            while (hi - li > 1)
            {
                int mid = li + (hi - li) / 2;
                if (heaters[mid] == house)
                    return 0;
                else if (heaters[mid] < house)
                    li = mid;
                else
                    hi = mid;
            }
            return Math.Min(Math.Abs(house - heaters[li]), Math.Abs(heaters[hi] - house));
        }
    }
}
