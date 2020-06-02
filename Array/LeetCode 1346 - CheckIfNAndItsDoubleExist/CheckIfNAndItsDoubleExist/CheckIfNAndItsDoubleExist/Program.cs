using System;
using System.Collections.Generic;

namespace CheckIfNAndItsDoubleExist
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 7, 11 };
            Console.WriteLine(CheckIfExist(arr));
        }
        static bool CheckIfExist(int[] arr)
        {
            var dict = new Dictionary<double, int>();
            foreach (var num in arr)
            {
                if (dict.ContainsKey(num * 2) || dict.ContainsKey((double)num / 2))
                    return true;
                else
                    dict[num] = 1;
            }
            return false;
        }
    }
}
