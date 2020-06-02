//如果出现两个点的斜率与其他点不同，则证明不在一条直线上。
using System;

namespace CheckIfItIsAStraightLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool CheckStraightLine(int[][] coordinates)
        {
            double slope = (double) Math.Abs(coordinates[1][0] - coordinates[0][0]) /
                           (double) Math.Abs(coordinates[1][1] - coordinates[0][1]);
            for (int i = 1; i < coordinates.Length; i++)
            {
                if ((double) Math.Abs(coordinates[i][0] - coordinates[i-1][0]) /
                    (double) Math.Abs(coordinates[i][1] - coordinates[i-1][1]) != slope)
                    return false;
            }
            return true;
        }
    }
}
