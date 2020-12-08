using System;
using System.Collections.Generic;

namespace FurthestBuildingYouCanReach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = {14, 3, 19, 3};
            int bricks = 17, ladders = 0;
            Console.WriteLine(FurthestBuilding(height, bricks, ladders));
        }
        static int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            var record = new List<int>();
            for (int i = 1; i < heights.Length; i++)
            {
                var diff = heights[i] - heights[i - 1];
                if (diff > 0)
                {
                    var index = record.BinarySearch(diff);
                    if (index < 0) index = -(index + 1);
                    record.Insert(index, diff);
                    if (record.Count > ladders)
                    {
                        bricks -= record[0];
                        record.RemoveAt(0);
                    }
                    if (bricks < 0)
                        return i - 1;
                }
            }
            return heights.Length - 1;
        }
    }
}
