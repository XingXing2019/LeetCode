//设置V，X，XX代表$5，$10，$15的个数。遍历数组检查每个bill的值。
//如果bill是$5，不找零，V加一。
//如果bill是$10，找$5，V减一，XX加一。
//如果bill是$20，找$10，检查X是否为0。如为0，用$5找零，V减三。如不为0，用$10和$5找零，X减一，V减一。
//没完成依次上述过程，检查V，X和XX，任何一个为负立即返回false。
//遍历结束后如没有返回false，即返回true。
using System;

namespace LemonadeChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bills = { 5, 5, 10, 20, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 5, 5, 20, 5, 20, 5 };
            Console.WriteLine(LemonadeChange(bills));
        }
        static bool LemonadeChange(int[] bills)
        {
            int V = 0;
            int X = 0;
            int XX = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                switch (bills[i])
                {
                    case 5:
                        V++;
                        break;
                    case 10:
                        V--;
                        X++;
                        break;
                    case 20:
                        if(X != 0)
                        {
                            V--;
                            X--;
                        }
                        else 
                            V -= 3;
                        XX++;
                        break;
                }
                if (V < 0 || X < 0 || XX < 0)
                    return false;
            }
            return true;
        }
    }
}
