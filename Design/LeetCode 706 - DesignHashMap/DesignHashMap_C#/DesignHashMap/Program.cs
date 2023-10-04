using System;

namespace DesignHashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new MyHashMapLinkedNode();
            map.Put(2, 2);
            map.Put(1003, 1);
            map.Put(2005, 1);
            Console.WriteLine(map.Get(2));
            map.Remove(2);
            Console.WriteLine(map.Get(2));
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

    public class MyHashMapLinkedNode
    {
        class ListNode
        {
            public int value;
            public int key;
            public ListNode next;

            public ListNode(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }

        private ListNode[] record;
        private int prime;
        public MyHashMapLinkedNode()
        {
            prime = 1001;
            record = new ListNode[prime];
        }

        public void Put(int key, int value)
        {
            var mod = key % prime;
            if (record[mod] == null)
                record[mod] = new ListNode(key, value);
            else
            {
                var point = record[mod];
                var pre = new ListNode(-1, -1) { next = record[mod] };
                while (point != null)
                {
                    if (point.key == key)
                    {
                        point.value = value;
                        return;
                    }
                    point = point.next;
                    pre = pre.next;
                }
                pre.next = new ListNode(key, value);
            }
        }

        public int Get(int key)
        {
            var mod = key % prime;
            if (record[mod] == null)
                return -1;
            var point = record[mod];
            while (point != null)
            {
                if (point.key == key)
                    return point.value;
                point = point.next;
            }
            return -1;
        }

        public void Remove(int key)
        {
            var mod = key % prime;
            if (record[mod] == null)
                return;
            var pre = new ListNode(-1, -1) { next = record[mod] };
            var point = record[mod];
            while (point != null)
            {
                if (point.key == key)
                {
                    pre.next = point.next;
                    break;
                }
                pre = pre.next;
                point = point.next;
            }
            if (point != null && pre.value == -1)
                record[mod] = pre.next;
        }
    }
}
