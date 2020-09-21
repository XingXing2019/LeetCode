//由于trips长度小于等于1000，并且上车和下车点为0-1000。所以可以使用暴力枚举。
//创建长度为1001的数组distance，用于记录车在每个位置乘客的数量。
//遍历trips数组中的每一个trip，将当前trip乘客的数量加到distance相应的位置上(上车点和下车点之间，包括上车点不包括下车点)。
//遍历distance数组，如果在某个位置乘客数大于capacity则返回false。如不存在这样的位置，则返回true。
using System;
using System.Collections.Generic;

namespace CarPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] trips = new int[6][];
            trips[0] = new int[] { 3, 5, 9 };
            trips[1] = new int[] { 4, 2, 5 };
            trips[2] = new int[] { 3, 4, 6 };
            trips[3] = new int[] { 9, 1, 4 };
            trips[4] = new int[] { 5, 6, 8 };
            trips[5] = new int[] { 5, 4, 6 };
            int capacity = 14;
            Console.WriteLine(CarPooling(trips, capacity));
        }
       
        static bool CarPooling(int[][] trips, int capacity)
        {
            var distance = new int[1001];
            foreach (var trip in trips)
            {
                for (int i = trip[1]; i < trip[2]; i++)
                {
                    distance[i] += trip[0];
                    if (distance[i] > capacity)
                        return false;
                }
            }
            return true;
        }
    }
}
