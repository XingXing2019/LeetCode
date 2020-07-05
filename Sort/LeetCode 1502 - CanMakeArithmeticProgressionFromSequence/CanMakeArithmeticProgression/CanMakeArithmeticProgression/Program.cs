using System;

namespace CanMakeArithmeticProgression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            var diff = arr[1] - arr[0];
            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] != diff)
                    return false;
            }
            return true;
        }
    }
}
