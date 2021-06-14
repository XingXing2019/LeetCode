using System;
using System.Linq;

namespace MaximumUnitsOnATruck
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] boxTypes = new[]
            {
                new[] {1, 3},
                new[] {2, 2},
                new[] {3, 1}
            };
            int truckSize = 4;
            Console.WriteLine(MaximumUnits(boxTypes, truckSize));
        }
        static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            boxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();
            int res = 0;
            for (int i = 0; i < boxTypes.Length && truckSize > 0; i++)
            {
                res += Math.Min(truckSize, boxTypes[i][0]) * boxTypes[i][1];
                truckSize -= boxTypes[i][0];
            }
            return res;
        }
    }
}
