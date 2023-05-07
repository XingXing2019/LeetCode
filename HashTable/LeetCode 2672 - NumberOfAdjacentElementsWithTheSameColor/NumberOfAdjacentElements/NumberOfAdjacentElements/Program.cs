using System;

namespace NumberOfAdjacentElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] ColorTheArray(int n, int[][] queries)
        {
            var record = new int[n];
            var res = new int[queries.Length];
            var count = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                int index = queries[i][0], color = queries[i][1], last = record[index];
                if (record[index] != color)
                {
                    record[index] = color;
                    if (index != 0)
                    {
                        if (record[index - 1] == color)
                            count++;
                        if (record[index - 1] == last && last != 0)
                            count--;
                    }
                    if (index != n - 1)
                    {
                        if (record[index + 1] == color)
                            count++;
                        if (record[index + 1] == last && last != 0)
                            count--;
                    }
                }
                res[i] = count;
            }
            return res;
        }
    }
}
