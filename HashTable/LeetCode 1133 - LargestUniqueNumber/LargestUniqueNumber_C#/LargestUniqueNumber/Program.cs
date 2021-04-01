using System;

namespace LargestUniqueNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int LargestUniqueNumber(int[] A)
        {
            var record = new int[1001];
            foreach (var num in A)
                record[num]++;
            for (int i = record.Length - 1; i >= 0; i--)
            {
                if (record[i] == 1)
                    return i;
            }
            return -1;
        }
    }
}
