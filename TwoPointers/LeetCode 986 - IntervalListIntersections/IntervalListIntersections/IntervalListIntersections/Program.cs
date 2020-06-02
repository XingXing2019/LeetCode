//创建两个指针，分别指向A和B中的数字对。再两者都不越界的条件下遍历。先用两个指针获取到startA，endAnger，startB，endB。
//如果两个间隔有重叠部分，第一种情况为startA在B区间内。这种情况又有两种情况，第一种情况为endA在B区间内，则将startA和endA加入结果，并使pointA加一。第二种情况为endA在B区间外，则将startA和endB加入结果，并使pointB加一。
//两个区间有重叠的第二种情况为startB在A区间内。操作方法与之前同理。
//两个区间没有重叠的第一种情况为A区间在B区间左边，则令pointA加一，第二种情况为A区间在B区间右边，则令pointB加一。
using System;
using System.Collections.Generic;

namespace IntervalListIntersections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            int pointA = 0, pointB = 0;
            var temp = new List<int[]>();
            while (pointA < A.Length && pointB < B.Length)
            {
                int startA = A[pointA][0], endA = A[pointA][1];
                int startB = B[pointB][0], endB = B[pointB][1];
                int left = Math.Max(startA, startB);
                int right = Math.Min(endA, endB);
                if (left <= right)
                {
                    temp.Add(new []{left, right});
                    if (endA >= startB && endA <= endB)
                        pointA++;
                    else if (endB >= startA && endB <= endA)
                        pointB++;
                }
                if (endA < startB)
                    pointA++;
                else if (endB < startA)
                    pointB++;
            }
            return temp.ToArray();
        }
    }
}
