using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MaximumSplitOfPositiveEvenIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long finalSum = 12;
            Console.WriteLine(MaximumEvenSplit(finalSum));
        }

        public static IList<long> MaximumEvenSplit(long finalSum)
        {
            if (finalSum % 2 != 0) return new List<long>();
            var num = 2;
            var res = new List<long>();
            while (finalSum - num > num)
            {
                res.Add(num);
                finalSum -= num;
                num += 2;
            }
            res.Add(finalSum);
            return res;
        }
    }
}
