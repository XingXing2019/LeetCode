using System;
using System.Linq;

namespace SuperPow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            int[] b = { 1, 0, 0 };
            Console.WriteLine(SuperPow(a, b));
        }

        public static int SuperPow(int a, int[] b)
        {
            return (int) Recursion(a, b);
        }

        public static long Recursion(long a, int[] b)
        {
            int mod = 1337;
            if (b.All(x => x == 0)) return 1;
            if (IsOne(b)) return a;
            var half = Recursion(a, DividTwo(b)) % mod;
            if (b[^1] % 2 == 0)
                return half * half % mod;
            return (half * half * a) % mod;
        }

        public static bool IsOne(int[] b)
        {
            for (int i = 0; i < b.Length - 1; i++)
            {
                if (b[i] != 0)
                    return false;
            }
            return b[^1] == 1;
        }

        public static int[] DividTwo(int[] b)
        {
            int car = 0;
            var res = new int[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                res[i] = (b[i] + car) / 2;
                car = (b[i] + car) % 2 != 0 ? 10 : 0;
            }
            return res;
        }
    }
}
