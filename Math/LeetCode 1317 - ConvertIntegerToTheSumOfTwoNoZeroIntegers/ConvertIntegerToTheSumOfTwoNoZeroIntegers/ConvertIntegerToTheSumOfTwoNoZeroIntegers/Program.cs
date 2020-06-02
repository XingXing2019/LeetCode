using System;

namespace ConvertIntegerToTheSumOfTwoNoZeroIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1010;
            Console.WriteLine(GetNoZeroIntegers(n));
        }
        static int[] GetNoZeroIntegers(int n)
        {
            int[] res = new int[2];
            for (int i = 1; i < n; i++)
            {
                if (!IsContainZero(i) && !IsContainZero(n - i))
                {
                    res[0] = i;
                    res[1] = n - i;
                    break;
                }
            }
            return res;
        }
        static bool IsContainZero(int num)
        {
            string tem = num.ToString();
            for (int i = 0; i < tem.Length; i++)
                if (tem[i] == '0')
                    return true;
            return false;
        }
    }
}
