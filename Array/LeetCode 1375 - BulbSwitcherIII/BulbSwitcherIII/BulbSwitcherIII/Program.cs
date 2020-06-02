//用maxBuld记录遍历过得最大灯泡的标号。
//如果最大灯泡标号等于已经遍历过灯泡的数量，则该灯泡之前的所有灯泡都已被打开。
using System;

namespace BulbSwitcherIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] light = {4, 1, 2, 3};
            Console.WriteLine(NumTimesAllBlue(light));
        }
        static int NumTimesAllBlue(int[] light)
        {
            int maxBlud = 0, res = 0;
            for (int i = 0; i < light.Length; i++)
            {
                maxBlud = Math.Max(maxBlud, light[i]);
                if (maxBlud == i + 1)
                    res++;
            }
            return res;
        }
    }
}
