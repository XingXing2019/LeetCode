//在num不等于0的时候循环，如果num是奇数，则令其减一，并让count加一。需要判断一次num是否已经是0。再让num除2，并让count加一。
using System;

namespace NumberOfStepsToReduceANumberToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumberOfSteps(int num)
        {
            int count = 0;
            while (num != 0)
            {
                if(num % 2 != 0)
                {
                    num--;
                    count++;
                }
                if (num == 0)
                    break;
                num /= 2;
                count++;
            }
            return count;
        }
    }
}
