//利用一个N是小于10^9这个条件，把小于10^9的2的幂全部记录下来。
//再根据N每一位上的数字做出判断。
using System;

namespace ReorderedPowerOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool ReorderedPowerOf2(int N)
        {
            var powers = new int[30];
            powers[0] = 1;
            powers[1] = 2;
            for (int i = 2; i < powers.Length; i++)
                powers[i] = powers[i - 1] * 2;
            foreach (var power in powers)
            {
                if (CompareNumbers(N, power))
                    return true;
            }
            return false;
        }

        static bool CompareNumbers(int num1, int num2)
        {
            string strNum1 = num1.ToString(), strNum2 = num2.ToString();

            if (strNum1.Length != strNum2.Length)
                return false;
            var record = new int[10];
            foreach (var digit in strNum1)
                record[digit - '0']++;
            foreach (var digit in strNum2)
            {
                record[digit - '0']--;
                if (record[digit - '0'] < 0)
                    return false;
            }
            return true;
        }
    }
}
