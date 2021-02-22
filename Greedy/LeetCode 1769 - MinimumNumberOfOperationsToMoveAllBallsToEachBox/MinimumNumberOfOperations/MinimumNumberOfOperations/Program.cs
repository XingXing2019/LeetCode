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
                if(boxes[i] == '1') ones.Add(i);
            var res = new int[boxes.Length];
            for (int i = 0; i < res.Length; i++)
                res[i] = ones.Sum(x => Math.Abs(x - i));
            return res;
        }
    }
}
