using System;

namespace ConvertANumberToHexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = -1;
            Console.WriteLine(ToHex(num));
        }
        static string ToHex(int num)
        {
            if (num == 0) return "0";
            var symbols = "0123456789abcdef";
            long temp = num < 0 ? (1L << 32) + num : num;
            var res = "";
            while (temp != 0)
            {
                res = symbols[(int)(temp % 16)] + res;
                temp /= 16;
            }
            return res;
        }
    }
}
