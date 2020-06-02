using System;
using System.Linq;

namespace MinimumIncrementToMakeArrayUnique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2, 2 };
            Console.WriteLine(MinIncrementForUnique(A));
        }
        static int MinIncrementForUnique(int[] A)
        {
            int[] record = new int[80000];
            foreach (var num in A)
                record[num]++;
            int index = 0;
            int count = 0;
            for (int i = 0; i < record.Length; i++)
            {
                if(record[i] != 0)
                {
                    index = i;
                    while (record[i] != 1)
                    {
                        for (int j = Math.Max( index, i); j < record.Length; j++)
                        {
                            if(record[j] == 0)
                            {
                                record[j] = 1;
                                count += j - i;
                                index = j;
                                break;
                            }
                        }
                        record[i]--;
                    }
                }
            }
            return count;
        }
    }
}
