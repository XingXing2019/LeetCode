using System;

namespace ThreeConsecutiveOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 3, 5};
            Console.WriteLine(ThreeConsecutiveOdds(arr));
        }
        static bool ThreeConsecutiveOdds(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if(arr[i] % 2 == 0) continue;
                int count = 1;
                for (int j = 1; j < 3; j++)
                {
                    if(arr[i + j] % 2 == 0) break;
                    count++;
                }
                if (count == 3) return true;
            }
            return false;
        }
    }
}
