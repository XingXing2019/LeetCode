//先将数组按照第二列排序，再将数组按照第一列排序。创建left和right代表当前边界。将初始值设为数组第一个子数组的左右边界。创建tem列表用来展示存储结果。
//从第二个元素开始遍历锯齿数组。如果遍历到数组的左边界落在现有左右边界之间，则判断其右边界。如果右边界落在现有左右边界之外，则将现有的右边界延伸到遍历到数组的右边界。
//如果遍历到数组有左边界落在现有左右边界之外，则将现有左右边界存入tem，并将左右边界更新为遍历到数组的左右边界。
//遍历结束后，将左后一次的左右边界人为添加入tem。
//根据tem的大小创建res数组。将tem中的数组存入res。
using System;
using System.Collections.Generic;

namespace MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[][]
            {
                new int[]{1, 3},
                new int[]{2, 6},
                new int[]{8, 10},
                new int[]{15, 18},
            };
            Console.WriteLine(Merge(intervals));
        }
        static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
        static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];
            Sort(intervals, 1);
            Sort(intervals, 0);
            int left = intervals[0][0];
            int right = intervals[0][1];
            List<int[]> tem = new List<int[]>();
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= right)
                {
                    if (intervals[i][1] > right)
                        right = intervals[i][1];
                }
                else
                {
                    tem.Add(new int[] { left, right });
                    left = intervals[i][0];
                    right = intervals[i][1];
                }
            }
            tem.Add(new int[] { left, right });
            int len = tem.Count;
            int[][] res = new int[len][];
            for (int i = 0; i < res.Length; i++)
                res[i] = tem[i];
            return res;
        }
    }
}
