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
            var res = new int[boxes.Length];
            int prefix = 0, suffix = 0, prefixCount = 0, suffixCount = 0;
            for (int i = 0; i < boxes.Length; i++)
            {
                res[i] += prefixCount * i - prefix;
                if (boxes[i] == '1')
                {
                    prefix += i;
                    prefixCount++;
                }
                res[boxes.Length - i - 1] += suffix - suffixCount * (boxes.Length - i - 1);
                if (boxes[boxes.Length - i - 1] == '1')
                {
                    suffix += boxes.Length - i - 1;
                    suffixCount++;
                }
            }
            return res;
        }
    }
}
