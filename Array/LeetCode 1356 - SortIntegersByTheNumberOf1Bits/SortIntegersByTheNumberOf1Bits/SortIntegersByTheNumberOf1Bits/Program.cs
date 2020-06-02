using System;
using System.Collections.Generic;
using System.Linq;

namespace SortIntegersByTheNumberOf1Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8};
            Console.WriteLine(SortByBits(arr));
        }
        static int[] SortByBits(int[] arr)
        {
            var record = new List<int>[32];
            var res = new int[arr.Length];
            foreach (var num in arr)
            {
                int count = Convert.ToString(num, 2).Count(bit => bit.Equals('1'));
                if (record[count] == null)
                    record[count] = new List<int> { num };
                else
                    record[count].Add(num);
            }
            int index = 0;
            foreach (var r in record)
            {
                if (r == null)
                    continue;
                r.Sort();
                foreach (var num in r)
                    res[index++] = num;
            }
            return res;
        }
    }
}
