using System;

namespace ClosestDivisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 8;
            Console.WriteLine(ClosestDivisors(num));
        }
        static int[] ClosestDivisors(int num)
        {
            var num1 = GetDivisors(num + 1);
            var num2 = GetDivisors(num + 2);
            if (num1[1] - num1[0] < num2[1] - num2[0])
                return num1;
            else
                return num2;
        }

        static int[] GetDivisors(int num)
        {
            int sqrt = (int)Math.Sqrt(num) + 1;
            int[] res = new int[2];
            for (int i = sqrt; i >= 0; i--)
            {
                if (num % i == 0)
                {
                    res[0] = i;
                    res[1] = num / i;
                    break;
                }
            }
            return res;
        }
    }
}
