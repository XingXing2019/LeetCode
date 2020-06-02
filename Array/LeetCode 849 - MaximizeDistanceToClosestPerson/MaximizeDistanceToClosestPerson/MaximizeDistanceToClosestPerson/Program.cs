//找到第一个1和最后一个1的位置，用于计算数组头和尾有多少个连续的0，用front和back记录。
//遍历数组找到最长连续0的个数maxDis。返回front，back和maxDis/2中的最大值。
using System;

namespace MaximizeDistanceToClosestPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seats = { 0,1 };
            Console.WriteLine(MaxDistToClosest(seats));
        }
        static int MaxDistToClosest(int[] seats)
        {
            int startOne = 0;
            int lastOne = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if(seats[i] == 1)
                {
                    startOne = i;
                    break;
                }
            }
            for (int i = seats.Length-1; i >= 0; i--)
            {
                if(seats[i] == 1)
                {
                    lastOne = i;
                    break;
                }
            }
            int front = startOne;
            int back = seats.Length - 1 - lastOne;
            int maxDis = 0;
            for (int i = startOne; i <= lastOne; i++)
            {
                if(seats[i] == 1)
                {
                    int dis = i - startOne;
                    if(dis > 1)
                        maxDis = Math.Max(maxDis, dis);
                    startOne = i;
                }
            }
            return Math.Max(maxDis / 2, Math.Max(front, back));            
        }
    }
}
