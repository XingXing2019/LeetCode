//先将intervals按开始时间排序，再用两个指针遍历intervals，当有重叠的时候删掉结束时间较晚的interval。用移动相应指针实现删除操作。
//需要注意，移动左指针的操作要用left=right完成，以免出现left指向已经删除的interval。
using System;
using System.Linq;

namespace NonOverlappingIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            var intervals = new int[][]
            {
                new[] {0, 2},
                new[] {1, 3},
                new[] {2, 4},
                new[] {3, 5},
                new[] {4, 6}
            };
            Console.WriteLine(EraseOverlapIntervals(intervals));
        }
        static int EraseOverlapIntervals(int[][] intervals)
        {
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            var res = 0;
            int left = 0, right = 1;
            while (right < intervals.Length)
            {
                if (intervals[right][0] >= intervals[left][1])
                {
                    left = right;
                    right++;
                }
                else
                {
                    if (intervals[right][1] < intervals[left][1])
                        left = right;
                    right++;
                    res++;
                }
            }
            return res;
        }
    }
}
