//创建sum记录结果。从1遍历到num的平方根(可以减少遍历次数)。如果i能被num整除，则将i和num与i的商加入sum，最后返回sum-num是否等于num。
using System;

namespace PerfectNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 6;
            Console.WriteLine(CheckPerfectNumber(num));
        }
        static bool CheckPerfectNumber(int num)
        {
            if (num == 0)
                return false;
            int sum = 0;
            for (int i = 1; i < Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    sum += i;
                    sum += num / i;
                }
            }
            return sum - num == num;
        }
    }
}
