using System;

namespace CircleAndRectangleOverlapping
{
    class Program
    {
        static void Main(string[] args)
        {
            int radius = 1;
            int x_center = 1;
            int y_center = 1;
            int x1 = 1;
            int y1 = -3;
            int x2 = 2;
            int y2 = -1;
            Console.WriteLine(CheckOverlap(radius, x_center, y_center, x1, y1, x2, y2));
        }
        static bool CheckOverlap(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            double x = (double)(x1 + x2) / 2;
            double y = (double)(y1 + y2) / 2;

            var h = new double[] {x2 - x, y2 - y};
            var v = new double[] {Math.Abs(x - x_center), Math.Abs(y - y_center)};
            var u = new double[] {Math.Max(v[0] - h[0], 0), Math.Max(v[1] - h[1], 0)};

            return radius * radius >= u[0] * u[0] + u[1] * u[1];
        }
    }
}
