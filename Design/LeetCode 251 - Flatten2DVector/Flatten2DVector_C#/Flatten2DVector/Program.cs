using System;
using System.Collections.Generic;

namespace Flatten2DVector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Vector2D
    {
        private List<int> record;
        private int point;
        public Vector2D(int[][] v)
        {
            record = new List<int>();
            point = 0;
            foreach (var numbers in v)
            {
                foreach (var number in numbers)
                {
                    record.Add(number);
                }   
            }
        }

        public int Next()
        {
            return record[point++];
        }

        public bool HasNext()
        {
            return point < record.Count;
        }
    }
}
