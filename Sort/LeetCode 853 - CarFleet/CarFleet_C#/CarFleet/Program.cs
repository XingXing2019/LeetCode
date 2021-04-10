using System;
using System.Linq;

namespace CarFleet
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 10;
            int[] position = { 0, 4, 2 }, speed = { 2, 1, 3 };
            Console.WriteLine(CarFleet(target, position, speed));
        }
        static int CarFleet(int target, int[] position, int[] speed)
        {
            if (position.Length == 0) return 0;
            var cars = new int[position.Length][];
            for (int i = 0; i < position.Length; i++)
                cars[i] = new[] {position[i], speed[i]};
            cars = cars.OrderBy(x => x[0]).ToArray();
            var times = new double[position.Length];
            for (int i = 0; i < cars.Length; i++)
                times[i] = (double) (target - cars[i][0]) / cars[i][1];
            int res = 1;
            double temp = times[^1];
            for (int i = times.Length - 1; i >= 0; i--)
            {
                if (!(times[i] > temp)) continue;
                res++;
                temp = times[i];
            }
            return res;
        }
    }
}
