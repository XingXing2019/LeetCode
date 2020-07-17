using System;
using System.Collections.Generic;

namespace MinimumCostToConnectSticks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sticks = { 2, 4, 3, 2, 3 };
            Console.WriteLine(ConnectSticks(sticks));
        }
        static int ConnectSticks(int[] sticks)
        {
            Array.Sort(sticks);
            var list = new Queue<int>(sticks);
            var sum = new Queue<int>();
            var minCost = 0;
            while (list.Count + sum.Count > 1)
            {
                var cost = GetMin(list, sum) + GetMin(list, sum);
                sum .Enqueue(cost);
                minCost += cost;
            }
            return minCost;
        }
        static int GetMin(Queue<int> list, Queue<int> sum)
        {
            if (list.Count == 0)
                return sum.Dequeue();
            if (sum.Count == 0)
                return list.Dequeue();
            return list.Peek() > sum.Peek() ? sum.Dequeue() : list.Dequeue();
        }
    }
}
