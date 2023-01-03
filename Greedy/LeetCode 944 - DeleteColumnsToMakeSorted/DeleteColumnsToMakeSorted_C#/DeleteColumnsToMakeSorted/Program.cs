using System;

namespace DeleteColumnsToMakeSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinDeletionSize(string[] A)
        {
            int count = 0;
            for (int i = 0; i < A[0].Length; i++)
            {
                for (int j = 1; j < A.Length; j++)
                {
                    if(A[j][i] - A[j - 1][i] < 0)
                    {
                        count++;
                        break;  
                    }
                }
            }
            return count;
        }
    }
}
