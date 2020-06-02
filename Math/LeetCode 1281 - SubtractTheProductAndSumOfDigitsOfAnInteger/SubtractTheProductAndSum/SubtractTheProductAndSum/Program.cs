//获得每位数字，按照要求进行计算。
using System;

namespace SubtractTheProductAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4421;
            Console.WriteLine(SubtractProductAndSum(n));
        }
        static int SubtractProductAndSum(int n)
        {
            string strN = n.ToString();
            int product = 1, sum = 0;
            for (int i = 0; i < strN.Length; i++)
            {
                int tem = strN[i] - '0';
                product *= tem;
                sum += tem;
            }
            return product - sum;
        }
    }
}
