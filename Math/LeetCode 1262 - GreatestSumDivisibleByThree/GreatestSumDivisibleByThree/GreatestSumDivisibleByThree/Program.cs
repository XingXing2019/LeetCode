//计算nums的总和sum。如果sum % 3 = 0，则返回sum。
//如果sum % 3 = 1，则可以减去最小的一个对3取模等于1的数，或者减去最小的两个对3取模等于2的数字。返回两种情况中较大的结果。
//如果sum % 3 = 2，则可以减去最小的两个对3取模等于1的数，或者减去最小的一个对3取模等于2的数字。返回两种情况中较大的结果。
using System;

namespace GreatestSumDivisibleByThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {4};
            Console.WriteLine(MaxSumDivThree(nums));
        }
        static int MaxSumDivThree(int[] nums)
        {
            int sum = 0;
            int firstMinModuloOne = 10000, secondMinModuloOne = 10000;
            int firstMinModuloTwo = 10000, secondMinModuloTwo = 10000;
            foreach (var num in nums)
            {
                sum += num;
                if (num % 3 == 1)
                {
                    if (num < firstMinModuloOne)
                    {
                        secondMinModuloOne = firstMinModuloOne;
                        firstMinModuloOne = num;
                    }
                    else if (num < secondMinModuloOne)
                        secondMinModuloOne = num;
                }
                else if (num % 3 == 2)
                {
                    if (num < firstMinModuloTwo)
                    {
                        secondMinModuloTwo = firstMinModuloTwo;
                        firstMinModuloTwo = num;
                    }
                    else if (num < secondMinModuloTwo)
                        secondMinModuloTwo = num;
                }
            }
            if (sum % 3 == 0)
                return sum;
            if (sum % 3 == 1)
                return Math.Max(sum - firstMinModuloOne, sum - firstMinModuloTwo - secondMinModuloTwo);
            return Math.Max(sum - firstMinModuloTwo, sum - firstMinModuloOne - secondMinModuloOne);
        }
    }
}
