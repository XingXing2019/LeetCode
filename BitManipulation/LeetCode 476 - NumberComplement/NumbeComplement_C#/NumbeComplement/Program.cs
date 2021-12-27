//创建GetBinary，Complement和GetDecimal方法分别负责将十进制变为二进制，取反，将二进制变为十进制。在主方法中调用三个方法。
using System;

namespace NumbeComplement
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            Console.WriteLine(FindComplement(num));
        }
        static int FindComplement1(int num)
        {
            int res = ~num;
            int temp = ~0;
            int step = 0;
            while (num != 0)
            {
                temp >>= 1;
                num >>= 1;
                step++;
            }
            while (step != 0)
            {
                temp <<= 1;
                step--;
            }
            return res ^ temp;
        }
        static int FindComplement(int num)
        {
            int res = ~num;
            int temp = ~0;
            while ((temp & num) != 0)
                temp <<= 1;
            return res ^ temp;
        }
    }
}
