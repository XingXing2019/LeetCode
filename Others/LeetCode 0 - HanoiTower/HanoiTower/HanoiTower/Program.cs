//使用递归思想。
//每次先调用MoveTower方法将最底部一个盘之上的所有盘移到辅助轴。
//再将最底部盘移动到终点轴。
//再调用MoveTower方法将辅助轴上所有盘移动到终点轴。
using System;

namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDiscs = 5;
            char begin = 'A';
            char tem = 'B';
            char target = 'C';
            MoveTower(numOfDiscs, begin, target, tem);
        }
        static void Move(char start, char end)
        {
            Console.WriteLine($"Move one disc from {start} to {end}");
        }
        static void MoveTower(int numOfDiscs, char begin, char target, char tem)
        {
            if(numOfDiscs == 1)
            {
                Move(begin, target);
            }
            else
            {
                MoveTower(numOfDiscs - 1, begin, tem, target);
                Move(begin, target);
                MoveTower(numOfDiscs - 1, tem, target, begin);
            }
        }
    }
}
