using System;

namespace MinimizeXOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 1, num2 = 12;
            Console.WriteLine(MinimizeXor(num1, num2));
        }

        public static int MinimizeXor(int num1, int num2)
        {
            int count = 0, res = 0, index = 0;
            while (num2 != 0)
            {
                if ((num2 & 1) == 1)
                    count++;
                num2 >>= 1;
            }
            for (int i = 31; i >= 0; i--)
            {
                if (((num1 >> i) & 1) == 1 && count != 0)
                {
                    res += 1 << i;
                    count--;
                }
            }
            while (count != 0)
            {
                if (((res >> index) & 1) != 1)
                {
                    res += 1 << index;
                    count--;
                }
                index++;
            }
            return res;
        }
    }
}
