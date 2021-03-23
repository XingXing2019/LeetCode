using System;
using System.Collections.Generic;

namespace FlattenNestedListIterator
{
    interface NestedInteger
    {
        bool IsInteger();
        int GetInteger();
        IList<NestedInteger> GetList();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class NestedIterator
    {
        private Stack<int> nums;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            nums = new Stack<int>();
            DFS(nestedList);
        }

        private void DFS(IList<NestedInteger> nestedList)
        {
            for (int i = nestedList.Count - 1; i >= 0; i--)
            {
                if(nestedList[i].IsInteger())
                    nums.Push(nestedList[i].GetInteger());
                else
                    DFS(nestedList[i].GetList());
            }
        }

        public bool HasNext()
        {
            return nums.Count != 0;
        }

        public int Next()
        {
            return nums.Pop();
        }
    }
}
