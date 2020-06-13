using System;
using System.Reflection.Metadata.Ecma335;

namespace PowXN
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 2;
            int n = 10;
            Console.WriteLine(MyPow(x, n));
        }
        static double MyPow(double x, int n)
        {
            if (x == 1 || x == 0) return x;
            if (n == 0) return 1.0d;
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            return Recursion(x, n);
        }

        static double Recursion(double x, int n)
        {
            if (n == 0) return 1.0d;
            if (n == 1) return x;
            double temp = Recursion(x, n / 2);
            if (n % 2 == 0) return temp * temp;
            return temp * temp * x;
        }
    }
}
