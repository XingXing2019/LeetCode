//使用递归，终止条件是n等于0时返回1，n等于1时返回x。然后递归调用n/2。然后判断如果n为偶数，则应该返回temp*temp。n为奇数则应该返回temp*temp*x。
using System;

namespace PowXN
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 2;
            int n = 10;
        }
        public double MyPow_Recursion(double x, int n)
        {
            if (x == 0) return x;
            if( n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            return Recursion(x, n);
        }

        private double Recursion(double x, int n)
        {
            if (n == 0) return 1.0;
            if (n == 1) return x;
            double temp = Recursion(x, n / 2);
            if (n % 2 == 0) return temp * temp;
            return temp * temp * x;
        }
        static double MyPow(double x, int n)
        {
            if (n == 0 || x == 1) return 1;
            if (x == 0) return 0;
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }
            double res = x, left = 1;
            while (N != 1)
            {
                if (N % 2 != 0)
                    left *= res;
                res *= res;
                N /= 2;
            }
            return res * left;
        }
    }
}
