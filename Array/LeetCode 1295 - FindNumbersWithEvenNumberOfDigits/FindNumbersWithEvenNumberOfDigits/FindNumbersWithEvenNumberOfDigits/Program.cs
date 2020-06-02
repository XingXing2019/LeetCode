//创建方法检查一个数字是否为偶数位。逻辑在数字不等于0时，让数字除等于10，每除一次count加一。最后返回count是否为偶数。
//遍历数组中每个数字，如果是偶数为，则结果加一。
using System;

namespace FindNumbersWithEvenNumberOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 10000;
            Console.WriteLine(CheckEven(num));
        }
        static int FindNumbers(int[] nums)
        {
            int count = 0;
            foreach (var n in nums)
                if (CheckEven(n))
                    count++;
            return count;
        }
        static bool CheckEven(int num)
        {
            int count = 0;
            while (num != 0)
            {
                num /= 10;
                count++;
            }
            return count % 2 == 0;
        }
    }
}
