using System;

namespace PutBoxesIntoTheWarehouseI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxes = { 4, 3, 4, 1 };
            int[] warehouses = { 5, 3, 3, 4, 1 };
            Console.WriteLine(MaxBoxesInWarehouse_BruteForce(boxes, warehouses));
        }
        static int MaxBoxesInWarehouse_BruteForce(int[] boxes, int[] warehouse)
        {
            Array.Sort(boxes);
            int lastRoom = warehouse.Length - 1;
            int res = 0;
            for (int i = 0; i < boxes.Length; i++)
            {
                for (int j = 0; j < lastRoom; j++)
                {
                    if (boxes[i] > warehouse[j])
                    {
                        lastRoom = j;
                        break;
                    }
                }
                if (lastRoom != warehouse.Length - 1)
                    lastRoom--;
                res += lastRoom >= 0 ? 1 : 0;
                if (lastRoom < 0) break;
            }
            return res;
        }

        static int MaxBoxesInWarehouse_TwoPointers(int[] boxes, int[] warehouse)
        {
            var maxHeight = new int[warehouse.Length];
            var min = warehouse[0];
            for (int i = 0; i < warehouse.Length; i++)
            {
                min = Math.Min(min, warehouse[i]);
                maxHeight[i] = min;
            }
            Array.Sort(boxes);
            int p1 = maxHeight.Length - 1, p2 = 0;
            while (p1 >= 0 && p2 < boxes.Length)
            {
                if (boxes[p2] <= maxHeight[p1])
                    p2++;
                p1--;
            }
            return p2;
        }
    }
}
