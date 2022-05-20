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
            int[][] intervals = new int[3][];
            intervals[0] = new int[2] { 3, 4 };
            intervals[1] = new int[2] { 2, 3 };
            intervals[2] = new int[2] { 1, 2 };
            Console.WriteLine(FindRightInterval_BuildingIn(intervals));
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

        static int[] FindRightInterval_BuildingIn(int[][] intervals)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < intervals.Length; i++)
                dict[intervals[i][0]] = i;
            var starts = intervals.Select(x => x[0]).OrderBy(x => x).ToArray();
            var res = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                var index = Array.BinarySearch(starts, intervals[i][1]);
                if (index < 0) index = ~index;
                res[i] = index < starts.Length ? dict[starts[index]] : -1;
            }
            return res;
        }
    }
}
