using System;
using System.Collections.Generic;

namespace PartitionArrayAccordingToGivenPivot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] PivotArray(int[] nums, int pivot)
        {
            var less = new List<int>();
            var greater = new List<int>();
            var equal = new List<int>();
            foreach (var num in nums)
            {
                if (num < pivot)
                    less.Add(num);
                else if (num > pivot)
                    greater.Add(num);
                else 
                    equal.Add(num);
            }
            less.AddRange(equal);
            less.AddRange(greater);
            return less.ToArray();
        }
    }
}
