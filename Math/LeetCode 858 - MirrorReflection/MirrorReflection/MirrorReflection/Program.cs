using System;

namespace MirrorReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MirrorReflection(int p, int q)
        {
            var gcd = GCD(p, q);
            var lcm = p * q / gcd;
            if (lcm / p % 2 == 0)
                return 0;
            return lcm / q % 2 == 0 ? 2 : 1;
        }

        public int GCD(int p, int q)
        {
            return q == 0 ? p : GCD(q, p % q);
        }
    }
}
