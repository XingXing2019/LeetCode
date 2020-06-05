using System;

namespace ConvertANumberToHexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 26;
            Console.WriteLine(ToHex_And(num));
        }
        static string ToHex_Long(int num)
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

        static string ToHex_And(int num)
        {
            if (num == 0) return "0";
            var symbols = "0123456789abcdef";
            var temp = 15;
            var res = "";
            var times = 8;
            while (num != 0 && times != 0)
            {
                res = symbols[num & temp] + res;
                num >>= 4;
                times--;
            }
            return res;
        }
    }
}
