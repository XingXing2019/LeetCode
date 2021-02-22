using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumNumberOfOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] MinOperations(string boxes)
        {
            var ones = new List<int>();
            for (int i = 0; i < boxes.Length; i++)
                if (boxes[i] == '1') ones.Add(i);
            var res = new int[boxes.Length];
            for (int i = 0; i < res.Length; i++)
                res[i] = ones.Sum(x => Math.Abs(x - i));
            return res;
        }

        public int[] MinOperations_N(string boxes)
        {
            var left = new int[boxes.Length][];
            var right = new int[boxes.Length][];
            int prefix = 0, suffix = 0;
            int prefixCount = 0, suffixCount = 0;
            for (int i = 0; i < boxes.Length; i++)
            {
                left[i] = new[] { prefix, prefixCount };
                if (boxes[i] == '1')
                {
                    prefix += i;
                    prefixCount++;
                }
                right[boxes.Length - i - 1] = new[] { suffix, suffixCount };
                if (boxes[boxes.Length - i - 1] == '1')
                {
                    suffix += boxes.Length - i - 1;
                    suffixCount++;
                }
            }
            var res = new int[boxes.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] += left[i][1] * i - left[i][0];
                res[i] += right[i][0] - right[i][1] * i;
            }
            return res;
        }
    }
}
