//想要得到z升水，要满足z = a * x + b * y，且a和b都为整数。
//根据貝祖定理，只有z为a和b最大公约数的倍数时，才能满足上述等式。
//所以这代替就转化成为求a和b最大公约数。
using System;

namespace WaterAndJugProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (z > x + y) return false;
            int gcd = GetGreatestCommonDivisor(x, y);
            return z == 0 || z % gcd == 0;
        }

        static int GetGreatestCommonDivisor(int x, int y)
        {
            if (x == 0 || y == 0) return int.MinValue;
            for (int i = Math.Min(x, y); i > 0; i--) 
                if (x % i == 0 && y % i == 0)
                    return i;
            return 1;
        }
    }
}
