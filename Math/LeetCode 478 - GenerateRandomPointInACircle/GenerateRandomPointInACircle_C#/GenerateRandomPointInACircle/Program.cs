using System;

namespace GenerateRandomPointInACircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        private Random _random;
        private double _radius;
        private double _x;
        private double _y;
        public Solution(double radius, double x_center, double y_center)
        {
            _random = new Random();
            _radius = radius;
            _x = x_center;
            _y = y_center;
        }

        public double[] RandPoint()
        {
            double x = 0, y = 0;
            do
            {
                x = (_random.NextDouble() > 0.5 ? 1 : -1) * _random.NextDouble() * _radius;
                y = (_random.NextDouble() > 0.5 ? 1 : -1) * _random.NextDouble() * _radius;
            }
            while (x * x + y * y > _radius * _radius);
            return new[] { _x + x, _y + y };
        }
    }
}
