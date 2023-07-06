using System;
using System.Collections.Generic;

namespace IsArrayAPreorderOfSomeBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsPreorder(IList<IList<int>> nodes)
        {
            var stack = new Stack<int>();
            stack.Push(nodes[0][0]);
            for (int i = 1; i < nodes.Count; i++)
            {
                while (stack.Count != 0 && stack.Peek() != nodes[i][1])
                    stack.Pop();
                if (stack.Count == 0)
                    return false;
                stack.Push(nodes[i][0]);
            }
            return true;
        }
    }
}
