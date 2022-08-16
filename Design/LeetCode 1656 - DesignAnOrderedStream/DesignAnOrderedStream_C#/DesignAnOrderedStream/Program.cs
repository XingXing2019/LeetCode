using System;
using System.Collections.Generic;

namespace DesignAnOrderedStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new OrderedStream(5);
            o.Insert(3, "ccccc");
            o.Insert(1, "aaaaa");
            o.Insert(2, "bbbbb");
            o.Insert(5, "eeeee");
            o.Insert(4, "ddddd");
        }
    }

    public class OrderedStream
    {
        private string[] record;
        private int point;
        public OrderedStream(int n)
        {
            record = new string[n];
            point = 0;
        }

        public IList<string> Insert(int id, string value)
        {
            record[id - 1] = value;
            if (id - 1 > point) return new string[0];
            int temp = point;
            while (point < record.Length && record[point] != null)
                point++;
            return record[temp..point];
        }
    }

}
