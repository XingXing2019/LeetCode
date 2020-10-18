using System;

namespace MeanOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public double TrimMean(int[] arr)
        {
            Array.Sort(arr);
            int start = arr.Length / 20;
            double sum = 0;
            for (int i = start; i < arr.Length - start; i++)
                sum += arr[i];
            return sum / (arr.Length - 2 * start);
        }
    }
}
