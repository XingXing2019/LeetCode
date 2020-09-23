using System;

namespace EncodeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 63;
            Console.WriteLine(Encode(num));
        }
        static string Encode(int num)
        {
            if (num == 0) return "";
            int gap = 2, cur = 1, count = 0;
            while (cur + gap <= num)
            {
                cur += gap;
                gap <<= 1;
                count++;
            }
            var res = Convert.ToString(num - cur, 2);
            var len = res.Length;
            for (int i = 0; i <= count - len; i++)
                res = "0" + res;
            return res;
        }
    }
}
