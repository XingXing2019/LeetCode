//创建li指针指向0，创建hi指针指向c正型平方根。
//在里小于等于hi的条件下遍历。创建tem记录li平方加hi平方的结果。
//如果tem等于c则返回true，如果tem大于c，则让hi左移一位，否则让li右移一位。
//遍历结束后如仍未返回true，则返回false。
using System;

namespace SumOfSquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 3;
            Console.WriteLine(JudgeSquareSum(c));
        }
        static bool JudgeSquareSum(int c)
        {
            int li = 0;
            int hi = (int)Math.Sqrt(c);
            while (li <= hi)
            {
                int tem = li * li + hi * hi;
                if (tem == c)
                    return true;
                else if (tem > c)
                    hi--;
                else
                    li++;
            }
            return false;
        }
    }
}
