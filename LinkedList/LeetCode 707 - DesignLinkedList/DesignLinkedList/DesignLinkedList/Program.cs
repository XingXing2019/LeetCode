//用列表实现链表，可以调用列表中已有的方法。
using System;
using System.Collections.Generic;

namespace DesignLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyLinkedList();
            list.AddAtHead(7);
            list.AddAtHead(2);
            list.AddAtHead(1);

            list.AddAtIndex(3, 0);
            list.DeleteAtIndex(2);


            list.AddAtHead(6);
            list.AddAtTail(4);

            Console.WriteLine(list.Get(4));
        }
    }
    public class MyLinkedList
    {
        private List<int> nums;
        public MyLinkedList()
        {
            nums = new List<int>();
        }
        public int Get(int index)
        {
            if (index > nums.Count - 1 || index < 0)
                return -1;
            return nums[index];
        }
        public void AddAtHead(int val)
        {
            nums.Insert(0, val);
        }

        public void AddAtTail(int val)
        {
            nums.Add(val);
        }

        public void AddAtIndex(int index, int val)
        {
            if(index == nums.Count)
                nums.Add(val);
            else if (index <= nums.Count - 1 && index >= 0)
                nums.Insert(index, val);
        }

        public void DeleteAtIndex(int index)
        {
            if (index <= nums.Count - 1 && index >= 0)
                nums.RemoveAt(index);
        }
    }

}
