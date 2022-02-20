//用Linq对intervals排序，先将intervals对第二个数字按降序排序，在对其按第一个数字安升序排序。排序结束后，则会使范围最大的interval排在前面。
//将left和right边界分别设为intervals的第一个边界对。然后从第二个interval开始遍历。如果其右边界在right之内，则令remove加一，代表其可以被删除。否则更新left和right。
//最后返回interval中原有的个数减去被删除的个数。
using System;
using System.Linq;

namespace RemoveCoveredIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[3][];
            intervals[0] = new int[] {1, 4};
            intervals[1] = new int[] {3, 6};
            intervals[2] = new int[] {2, 8};
            Console.WriteLine(RemoveCoveredIntervals(intervals));
        }
        static int RemoveCoveredIntervals(int[][] intervals)
        {
            var orderedIntervals = intervals.OrderByDescending(i => i[1]).OrderBy(i => i[0]).ToArray();
            int left = orderedIntervals[0][0], right = orderedIntervals[0][1];
            int remove = 0;
            for (int i = 1; i < orderedIntervals.Length; i++)
            {
                if (orderedIntervals[i][1] <= right)
                    remove++;
                else
                {
                    left = orderedIntervals[i][0];
                    right = orderedIntervals[i][1];
                }
            }
            return intervals.Length - remove;
        }
    }
}
