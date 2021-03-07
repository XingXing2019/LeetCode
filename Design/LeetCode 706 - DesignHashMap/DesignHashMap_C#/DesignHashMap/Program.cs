using System;

namespace DesignHashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class MyHashMap
    {
        private int[] record;
        /** Initialize your data structure here. */
        public MyHashMap()
        {
            record = new int[1000001];
            for (int i = 0; i < record.Length; i++)
                record[i] = -1;
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            record[key] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return record[key];
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            record[key] = -1;
        }
    }
}
