using System;

namespace MagneticForceBetweenTwoBalls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] position = { 32, 13, 9, 2, 96, 69, 25, 82, 72, 83 };
            int m = 10;
            Console.WriteLine(MaxDistance(position, m));
        }

        public static int MaxDistance(int[] position, int m)
        {
            Array.Sort(position);
            int li = 0, hi = position[^1] - position[0];
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                int index = 0, cur = position[index], count = 0;
                while (index < position.Length)
                {
                    if (position[index] >= cur)
                    {
                        cur = position[index] + mid;
                        count++;
                    }
                    index++;
                }
                if (count >= m) li = mid + 1;
                else hi = mid - 1;
            }
            return hi;
        }
    }
}
