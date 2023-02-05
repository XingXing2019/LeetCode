using System;
using System.Linq;

namespace SeparateTheDigitsInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] SeparateDigits(int[] nums)
        {
            return nums.SelectMany(x => ToDigits(x.ToString())).ToArray();
        }

        private int[] ToDigits(string num)
        {
            var res = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
                res[i] = num[i] - '0';
            return res;
        }
    }
}
