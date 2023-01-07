using System;

namespace FindConsecutiveIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class DataStream
    {
        private readonly int _value;
        private readonly int _k;
        private int _count;

        public DataStream(int value, int k)
        {
            _value = value;
            _k = k;
        }

        public bool Consec(int num)
        {
            _count = num == _value ? _count + 1 : 0;
            return _count >= _k;
        }
    }
}
