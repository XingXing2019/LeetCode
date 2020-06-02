using System;
using System.Collections.Generic;

namespace RLEIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 923381016, 843, 898173122, 924, 540599925, 391, 705283400, 275, 811628709, 850, 895038968, 590, 949764874, 580, 450563107, 660, 996257840, 917, 793325084, 82 };
            var iterator = new RLEIterator(A);
            Console.WriteLine(iterator.Next(612783106));
            Console.WriteLine(iterator.Next(486444202));
            Console.WriteLine(iterator.Next(630147341));
            Console.WriteLine(iterator.Next(845077576));
        }
    }
    public class RLEIterator
    {
        private List<double[]> record;
        private int point;
        private double count;

        public RLEIterator(int[] A)
        {
            record = new List<double[]>();
            record.Add(new[] {(double)A[0], (double)A[1]});
            var p = 0;
            for (int i = 2; i < A.Length - 1; i += 2)
            {
                if(A[i] == 0)
                    continue;
                record.Add(new[] { record[p++][0] + A[i], A[i + 1] });
            }
        }

        public int Next(int n)
        {
            count += n;
            while (point < record.Count && count > record[point][0])
                point++;
            return point < record.Count ? (int) record[point][1] : -1;
        }
    }
}
