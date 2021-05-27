//使用异或位运算
using System;
using System.Linq;

namespace HammingDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 4;
            Console.WriteLine(HammingDistance(x, y));
        }
        static int HammingDistance(int x, int y)
        {
            return Convert.ToString(x ^ y, 2).Count(bit => bit == '1');
        }
        static int HammingDistance_bitManipulate(int x, int y)
        {
            int num = x ^ y;
            int res = 0;
            while (num != 0)
            {
                res += num & 1;
                num >>= 1;
            }
            return res;
        }
    }
}
