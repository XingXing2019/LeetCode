using System;

namespace ThousandSeparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string ThousandSeparator(int n)
        {
            if (n == 0) return "0";
            var res = "";
            var count = 0;
            while (n != 0)
            {
                count++;
                res = n % 10 + res;
                n /= 10;
                if (n != 0 && count == 3)
                {
                    res = "." + res;
                    count = 0;
                }
            }
            return res;
        }
    }
}
