using System;
using System.Collections.Generic;

namespace FindMedianFromDataStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {1, 2, 3};
            var num = 4;
            Console.WriteLine(list.BinarySearch(num));
        }
    }
    public class MedianFinder
    {
        private List<double> _maxHeap;
        public MedianFinder()
        {
            _maxHeap = new List<double>();
        }

        public void AddNum(int num)
        {
            var index = _maxHeap.BinarySearch(num);
            if (index < 0)
                index = -(index + 1);
            _maxHeap.Insert(index, num);
        }

        public double FindMedian()
        {
            var count = _maxHeap.Count;
            if (count % 2 != 0)
                return _maxHeap[count / 2];
            else
                return (_maxHeap[count / 2] + _maxHeap[count / 2 - 1]) / 2;
        }
    }

}
