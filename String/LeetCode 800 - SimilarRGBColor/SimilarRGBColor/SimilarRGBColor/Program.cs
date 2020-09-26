using System;

namespace SimilarRGBColor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string SimilarRGB(string color)
        {
            var r = Convert.ToInt32(color.Substring(1, 2), 16);
            var g = Convert.ToInt32(color.Substring(3, 2), 16);
            var b = Convert.ToInt32(color.Substring(5, 2), 16);
            return $"#{GetMin(r).ToString("x2")}{GetMin(g).ToString("x2")}{GetMin(b).ToString("x2")}";
        }

        private int GetMin(int num)
        {
            int curr = int.MaxValue;
            int res = 0;
            for (int i = 0; i < 16; i++)
            {
                int candidate = i * 16 + i;
                int diff = candidate - num;
                diff *= diff;
                if (diff < curr)
                {
                    curr = diff;
                    res = candidate;
                }
            }
            return res;
        }
    }
}
