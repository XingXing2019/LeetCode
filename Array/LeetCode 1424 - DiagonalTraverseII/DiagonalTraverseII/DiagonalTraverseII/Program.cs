using System;
using System.Collections.Generic;

namespace DiagonalTraverseII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> nums = new List<IList<int>>();
            nums.Add(new List<int> { 1, 2, 3 });
            nums.Add(new List<int> { 4, 5, 6 });
            nums.Add(new List<int> { 7, 8, 9 });
            Console.WriteLine(FindDiagonalOrder(nums));
        }
        static int[] FindDiagonalOrder(IList<IList<int>> nums)
        {
            var res = new List<int>();
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[]{0, 0});
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var currPos = queue.Dequeue();
                    res.Add(nums[currPos[0]][currPos[1]]);
                    if(currPos[1] == 0 && currPos[0] + 1 < nums.Count)
                        queue.Enqueue(new int[]{currPos[0] + 1, 0});
                    if (currPos[1] + 1 < nums[currPos[0]].Count)
                        queue.Enqueue(new int[] {currPos[0], currPos[1] + 1});
                }
            }
            return res.ToArray();
        }
    }
}
