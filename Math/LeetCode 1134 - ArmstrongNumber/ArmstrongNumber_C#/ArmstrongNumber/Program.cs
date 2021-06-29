//按照题意逐位求和。
using System;

namespace ArmstrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsArmstrong(int N)
        {
            string strN = N.ToString();
            int k = strN.Length;
            double sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += Math.Pow(strN[i] - '0', k);
                if (sum > N)
                    return false;
            }
            return (int) sum == N;
        }
    }
}
