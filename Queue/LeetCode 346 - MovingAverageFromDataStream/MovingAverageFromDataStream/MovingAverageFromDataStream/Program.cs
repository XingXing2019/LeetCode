using System;
using System.Collections.Generic;

namespace MovingAverageFromDataStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class MovingAverage
    {
        private readonly int _size;
        private Queue<double> _nums;
        private double _sum;
        public MovingAverage(int size)
        {
            _size = size;
            _nums = new Queue<double>();
        }

        public double Next(int val)
        {
            if (_nums.Count >= _size)
                _sum -= _nums.Dequeue();
            _nums.Enqueue(val);
            _sum += val;
            return _sum / _nums.Count;
        }
    }
}
