using System;

namespace RangeAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] GetModifiedArray(int length, int[][] updates)
        {
            var res = new int[length];
            foreach (var update in updates)
            {
                res[update[0]] += update[2];
                if (update[1] < res.Length - 1)
                    res[update[1] + 1] += -update[2];
            }
            for (int i = 1; i < res.Length; i++)
                res[i] += res[i - 1];
            return res;
        }
    }
}
