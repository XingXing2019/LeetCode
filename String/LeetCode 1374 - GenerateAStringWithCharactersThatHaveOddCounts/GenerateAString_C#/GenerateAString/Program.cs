using System;

namespace GenerateAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string GenerateTheString(int n)
        {
            int count = n % 2 == 0 ? n - 1 : n;
            string res = "";
            for (int i = 0; i < count; i++)
                res += "a";
            return res.Length < n ? res + "b" : res;
        }
    }

}
