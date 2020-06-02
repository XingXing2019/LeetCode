//创建双指针指向数组头尾，如果两个指针所指数字之和等于target，则返回两个指针。
//如果大于target，则hi左移，否则li右移。
using System;

namespace TwoSumII_InputArrayIsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 7, 11, 15 };
            int target = 9;
            Console.WriteLine(TwoSum(numbers, target));
        }
        static int[] TwoSum(int[] numbers, int target)
        {
            int[] res = new int[2];
            int li = 0, hi = numbers.Length - 1;
            while (li < hi)
            {
                if (numbers[hi] + numbers[li] == target)
                {
                    res[0] = li + 1;
                    res[1] = hi + 1;
                    break;
                }
                else if (numbers[hi] + numbers[li] > target)
                    hi--;
                else
                    li++;
            }
            return res;
        }
    }
}
