using System;

namespace HowManyApples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxNumberOfApples(int[] arr)
        {
            Array.Sort(arr);
            int count = 0, weight = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                weight += arr[i];
                if(weight > 5000)
                    break;
                count++;
            }
            return count;
        }
    }
}
