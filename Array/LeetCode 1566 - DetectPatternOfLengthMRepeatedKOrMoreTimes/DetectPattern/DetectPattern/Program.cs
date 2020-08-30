using System;
using System.Collections.Generic;

namespace DetectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 2, 1, 2, 1, 3};
            int m = 2, k = 3;
            Console.WriteLine(ContainsPattern(arr, m, k));
        }

        static bool ContainsPattern(int[] arr, int m, int k)
        {
            if (arr.Length < m * k) return false;
            var str = string.Join("", arr);
            var patterns = new HashSet<string>();
            for (int i = 0; i <= str.Length - m; i++)
            {
                var pattern = str.Substring(i, m);
                var temp = "";
                for (int j = 0; j < k; j++)
                    temp += pattern;
                patterns.Add(temp);
            }
            foreach (var pattern in patterns)
            {
                for (int i = 0; i <= str.Length - m * k; i++)
                {
                    if (str.Substring(i, m * k) == pattern)
                        return true;
                }
            }
            return false;
        }
    }
}
