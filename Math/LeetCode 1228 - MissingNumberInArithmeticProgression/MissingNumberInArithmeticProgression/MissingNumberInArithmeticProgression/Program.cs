using System;
using System.Linq;

namespace MissingNumberInArithmeticProgression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MissingNumber(int[] arr)
        {
            return (arr[0] + arr[^1]) * (arr.Length + 1) / 2 - arr.Sum();
        }
    }
}
