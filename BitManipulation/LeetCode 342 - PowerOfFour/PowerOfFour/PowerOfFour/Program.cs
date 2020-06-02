//如果num为0，返回false。否则在num不等于1的条件下循环。如果num模4不等于0，则返回false。将num右移两位(相当于除以4)。
//遍历结束后仍未返回false证明num等于1，则返回true。
using System;

namespace PowerOfFour
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 65;
            Console.WriteLine(IsPowerOfFour(num));
        }
        static bool IsPowerOfFour(int num)
        {
            if (num == 0)
                return false;
            while (num != 1)
            {
                if (num % 4 != 0)
                    return false;
                num >>= 2;
            }
            return true;
        }
    }
}
