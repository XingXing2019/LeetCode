using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PutBoxesIntoTheWarehouseII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] boxes = { 4, 5, 6, 2 };
            int[] warehouse = { 3, 2, 6, 3, 3, 7 };
            Console.WriteLine(MaxBoxesInWarehouse(boxes, warehouse));
        }

        public static int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
        {
            int[] left = new int[warehouse.Length], right = new int[warehouse.Length];
            int leftMin = warehouse[0], rightMin = warehouse[^1];
            for (int i = 0; i < warehouse.Length; i++)
            {
                leftMin = Math.Min(leftMin, warehouse[i]);
                left[i] = leftMin;
                rightMin = Math.Min(rightMin, warehouse[^(i + 1)]);
                right[^(i + 1)] = rightMin;
            }
            for (int i = 0; i < warehouse.Length; i++)
                warehouse[i] = Math.Max(left[i], right[i]);
            boxes = boxes.OrderByDescending(x => x).ToArray();
            warehouse = warehouse.OrderByDescending(x => x).ToArray();
            int p1 = 0, p2 = 0;
            while (p1 < boxes.Length && p2 < warehouse.Length)
            {
                if (boxes[p1] <= warehouse[p2])
                    p2++;
                p1++;
            }
            return p2;
        }
    }
}
