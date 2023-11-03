using System;
using System.Collections.Generic;

namespace BuildAnArrayWithStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] target = {1, 3};
            int n = 3;
            Console.WriteLine(BuildArray(target, n));
        }
        static IList<string> BuildArray(int[] target, int n)
        {
            var res = new List<string>();
            int index = 0;
            for (int i = 1; i <= n && index < target.Length; i++)
            {
                if (target[index] == i)
                {
                    res.Add("Push");
                    index++;
                }
                else
                {
                    res.Add("Push");
                    res.Add("Pop");
                }
            }
            return res;
        }
    }
}
