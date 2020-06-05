using System;

namespace RandomPickWithWeight
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
        private int[] _weight;

        public Solution(int[] w)
        {
            _random = new Random();
            _weight = new int[w.Length];
            _weight[0] = w[0];
            for (int i = 1; i < w.Length; i++)
                _weight[i] = _weight[i - 1] + w[i];
        }

        public int PickIndex()
        {
            var weight = _random.Next(1, _weight[^1] + 1);
            var pos = Array.BinarySearch(_weight, weight);
            return pos < 0 ? -(pos + 1) : pos;
        }
    }
}
