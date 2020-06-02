//将四个点存入一个二维数组points，然后用Linq先对其按照纵坐标排序，再按横坐标排序。
//根据排好序的points计算四条边的长度。在计算一条对角线的长度。
//要组成正方形，必须四条边长相等，并且两条边和对角线能构成直角三角形。
using System;
using System.Linq;

namespace ValidSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p1 = {-1, -1};
            int[] p2 = {2, -2};
            int[] p3 = {1, 0};
            int[] p4 = {0, -3};
            Console.WriteLine(ValidSquare(p1, p2, p3, p4));
        }
        static bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            int[][] points = new int[4][];
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
            points[3] = p4;
            points = points.OrderBy(p => p[1]).ToArray();
            points = points.OrderBy(p => p[0]).ToArray();
            int len1 = (points[0][0] - points[1][0]) * (points[0][0] - points[1][0]) + (points[0][1] - points[1][1]) * (points[0][1] - points[1][1]);
            int len2 = (points[0][0] - points[2][0]) * (points[0][0] - points[2][0]) + (points[0][1] - points[2][1]) * (points[0][1] - points[2][1]);
            int len3 = (points[3][0] - points[1][0]) * (points[3][0] - points[1][0]) + (points[3][1] - points[1][1]) * (points[3][1] - points[1][1]);
            int len4 = (points[3][0] - points[2][0]) * (points[3][0] - points[2][0]) + (points[3][1] - points[2][1]) * (points[3][1] - points[2][1]);
            if (len1 == 0)
                return false;
            bool isEqualLen = len1 == len2 && len1 == len3 && len1 == len4;
            int diagonal = (points[1][1] - points[2][1]) * (points[1][1] - points[2][1]) + (points[1][0] - points[2][0]) * (points[1][0] - points[2][0]);
            bool isEqualAngle = len1 + len2 == diagonal;
            return isEqualLen && isEqualAngle;
        }
    }
}
