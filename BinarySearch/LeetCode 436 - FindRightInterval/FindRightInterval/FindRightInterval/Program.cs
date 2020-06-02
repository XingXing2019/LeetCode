//创建字典dict记录每个interval的index。然后将intervals按照起点排序，再按照终点排序。创建res记录结果。
//遍历排序好的intervals，使用二分搜索找到可能符合条件的interval的index，如果index越界或者index指向interval不符合条件，则根据字典中记录当前interval的位置，将res中相应位置设为-1.
//否则将符合天骄interval的位置记入res。
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindRightInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[4][];
            intervals[0] = new int[2] { 5, 6 };
            intervals[1] = new int[2] { 4, 7 };
            intervals[2] = new int[2] { 9, 10 };
            intervals[3] = new int[2] { 7, 8 };
            Console.WriteLine(FindRightInterval(intervals));
        }
        static int[] FindRightInterval(int[][] intervals)
        {
            var dict = new Dictionary<int[], int>();
            for (int i = 0; i < intervals.Length; i++)
                dict[intervals[i]] = i;
            intervals = intervals.OrderBy(i => i[0]).ThenBy(i => i[1]).ToArray();
            int[] res = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                int li = i + 1, hi = intervals.Length - 1;
                while (li < hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (intervals[mid][0] >= intervals[i][1])
                        hi = mid;
                    else
                        li = mid + 1;
                }
                if (li > intervals.Length - 1 || intervals[li][0] < intervals[i][1])
                    res[dict[intervals[i]]] = -1;
                else
                    res[dict[intervals[i]]] = dict[intervals[li]];
            }
            return res;
        }
    }
}
