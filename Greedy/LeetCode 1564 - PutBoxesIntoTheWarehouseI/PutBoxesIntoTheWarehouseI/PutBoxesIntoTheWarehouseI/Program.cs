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

        static int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
        {

        }
    }
}
