//使用二分搜索创建li和hi指针分别指向1和x。在li小于hi的条件下遍历。
//遍历中创建mid指向li和hi的中间值。如果x除以mid小于mid，证明mid太大了，则令hi等于mid，从而下次循环时，在更小值的范围内寻找结果。
//如果x除以midda于mid，证明mid太小了。则令li等于mid + 1，从而下次循环时，在更大值的范围内寻找结果。最后需要返回li - 1。
using System;

namespace Sqrt_x_
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Console.WriteLine(MySqrt(x));
        }
        static int MySqrt(int x)
        {
            if (x <= 1) return x;
            long li = 0, hi = x;
            while (li < hi)
            {
                var mid = li + (hi - li) / 2;
                if (mid * mid == x)
                    return (int)mid;
                if (mid * mid > x)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return (int)li - 1;
        }
    }
}
