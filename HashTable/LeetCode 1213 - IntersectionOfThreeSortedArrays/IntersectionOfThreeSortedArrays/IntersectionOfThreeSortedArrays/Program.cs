using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectionOfThreeSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            var record = new int[2001];
            foreach (var num in arr1)
                record[num]++;
            foreach (var num in arr2)
                record[num]++;
            foreach (var num in arr3)
                record[num]++;
            var res = new List<int>();
            for (int i = 0; i < record.Length; i++)
            {
                if(record[i] == 3)
                    res.Add(i);
            }
            return res;
        }
    }
}
