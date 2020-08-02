using System;
using System.Linq;

namespace FindTheWinnerOfAnArrayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 11, 22, 33, 44, 55, 66, 77, 88, 99 };
            int k = 1000000000;
            Console.WriteLine(GetWinner(arr, k));
        }
        static int GetWinner(int[] arr, int k)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int count = k;
                bool found = true;
                for (int j = i - 1; j < arr.Length && count > 0; j++)
                {
                    if(j < 0 || j == i) continue;
                    if (arr[i] > arr[j])
                        count--;
                    else
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return arr[i];
            }
            return -1;
        }
    }
}
