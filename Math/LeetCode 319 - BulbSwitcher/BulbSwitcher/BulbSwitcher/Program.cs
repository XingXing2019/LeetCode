//只有被按过奇数次的灯才会在最后保持亮着。
//对于第n盏灯，假如n = 6。则n = 1 * 6 = 2 * 3 = 3 * 2 = 6 * 1，n会被按偶数次。
//对于所有n，他的因子都是成对出现的，除非n是完全平方数。
//这道题就是要找到1-n之间有多少个完全平方数。
using System;

namespace BulbSwitcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int BulbSwitch(int n)
        {
            return (int) Math.Sqrt(n);
        }
    }
}
