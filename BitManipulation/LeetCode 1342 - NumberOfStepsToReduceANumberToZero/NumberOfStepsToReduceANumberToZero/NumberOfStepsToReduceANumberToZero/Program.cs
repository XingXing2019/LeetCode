//在num大于0的时候循环，如果num是奇数减1，否则除2。同时step加一。
using System;

namespace NumberOfStepsToReduceANumberToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumberOfSteps_BitManipulate(int num)
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
    }
}
