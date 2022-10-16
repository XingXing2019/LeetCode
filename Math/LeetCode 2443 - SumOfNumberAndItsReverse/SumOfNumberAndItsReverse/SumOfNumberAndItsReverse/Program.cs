using System;

namespace SumOfNumberAndItsReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = 100;
            Console.WriteLine(SumOfNumberAndReverse(num));
        }

        public static bool SumOfNumberAndReverse(int num)
        {
            if (num == 0) return true;
            for (int i = 1; i <= num; i++)
            {
                if (!IsValid(i, num)) continue;
                return true;
            }
            return false;
        }
        
        public static bool IsValid(int num, int target)
        {
            int reverse = 0, copy = num;
            while (copy != 0)
            {
                reverse = reverse * 10 + copy % 10;
                copy /= 10;
            }
            if (num + reverse == target)
                return true;
            while (num % 10 != 0 && num + reverse <= target)
            {
                if (num + reverse == target)
                    return true;
                reverse *= 10;
            }
            return false;
        }
    }
}
