using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeTwoArraysEqualByReversingSubArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CanBeEqual(int[] target, int[] arr)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < target.Length; i++)
            {
                if (!dict.ContainsKey(target[i]))
                    dict[target[i]] = 1;
                else
                    dict[target[i]]++;
                if (!dict.ContainsKey(arr[i]))
                    dict[arr[i]] = -1;
                else
                    dict[arr[i]]--;
            }
            return dict.All(x => x.Value == 0);
        }
    }
}
