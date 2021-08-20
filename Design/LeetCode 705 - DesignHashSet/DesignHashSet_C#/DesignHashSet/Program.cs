using System;

namespace DesignHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class MyHashSet
    {
        private bool[] record;
        /** Initialize your data structure here. */
        public MyHashSet()
        {
            record =new bool[1000001];
        }

        public void Add(int key)
        {
            record[key] = true;
        }

        public void Remove(int key)
        {
            record[key] = false;
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            return record[key];
        }
    }
}
