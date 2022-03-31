//可以使用暴力算法检查每个数字是否合法，因为数字最长为6位，所以时间复杂度为O(n*6).
using System;
using System.Collections.Generic;

namespace SelfDividingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 100;
            Console.WriteLine(CheckValidNumber(num));
        }
        static IList<int> SelfDividingNumbers(int left, int right)
        {
            List<int> res = new List<int>();
            for (int i = left; i <= right; i++)
            {
                if (CheckValidNumber(i))
                    res.Add(i);
            }
            return res;
        }
        static bool CheckValidNumber(int num)
        {
            int tem = num;
            while (tem!= 0)
            {
                int digit = tem % 10;
                if (digit == 0)
                    return false;
                else if (num % digit != 0)
                    return false;
                tem /= 10;
            }
            return true;
        }
    }
}
