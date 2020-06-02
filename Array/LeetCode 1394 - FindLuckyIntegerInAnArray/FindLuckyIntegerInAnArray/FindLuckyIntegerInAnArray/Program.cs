using System;

namespace FindLuckyIntegerInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int FindLucky(int[] arr)
        {
            var record = new int[501];
            foreach (var num in arr)
                record[num]++;
            for (int i = record.Length - 1; i > 0; i--)
                if (i == record[i])
                    return i;
            return -1;
        }
    }
}