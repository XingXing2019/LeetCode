using System;
using System.Collections.Generic;

namespace FurthestBuildingYouCanReach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = { 4, 12, 2, 7, 3, 18, 20, 3, 19 };
            int bricks = 10, ladders = 2;
            Console.WriteLine(FurthestBuilding_NLogN(height, bricks, ladders));
        }
        static int FurthestBuilding_NLogN(int[] heights, int bricks, int ladders)
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
