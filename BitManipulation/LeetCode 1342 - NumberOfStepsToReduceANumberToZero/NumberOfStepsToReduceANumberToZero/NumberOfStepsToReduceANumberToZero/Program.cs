//解法一：在num大于0的时候循环，如果num是奇数减1，否则除2。同时step加一。
/解法二：如果是奇数需要两步把那一位消掉，如果是偶数就需要一步就能消掉。但是在最后一次循环中是1的情况，只要一步就可以消掉。所以最后结果需要将额外多计算的一步减去。
using System;

namespace NumberOfStepsToReduceANumberToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 9;
            Console.WriteLine(NumberOfSteps_BitManipulate(num));
        }
        static int NumberOfSteps(int num)
        {
            int step = 0;
            while (num > 0)
            {
                if ((num & 1) == 0)
                    num /= 2;
                else
                    num -= 1;
                step++;
            }
            return step;
        }

        static int NumberOfSteps_BitManipulate(int num)
        {
            int step = 0;
            if (num == 0) return 0;
            while (num != 0)
            {
                step += (num & 1) == 0 ? 1 : 2;
                num >>= 1;
            }
            return step - 1;
        }
    }
}
