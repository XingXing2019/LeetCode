using System;
using System.Collections.Generic;

namespace MinimumCostOfAPathWithSpecialRoads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] start = { 1, 1 }, target = { 1, 1 };
            int[][] specialRoads = new int[][] { new[] { 1, 1, 1, 1, 1 } };
            Console.WriteLine(MinimumCost(start, target, specialRoads));
        }

        public static int MinimumCost(int[] start, int[] target, int[][] specialRoads)
        {
            var dp = new Dictionary<string, int>();
            foreach (var road in specialRoads)
            {
                dp[$"{road[0]}:{road[1]}"] = int.MaxValue;
                dp[$"{road[2]}:{road[3]}"] = int.MaxValue;
            }
            dp[$"{start[0]}:{start[1]}"] = 0;
            dp[$"{target[0]}:{target[1]}"] = Math.Abs(start[0] - target[0]) + Math.Abs(start[1] - target[1]);
            var queue = new Queue<KeyValuePair<string, int>>();
            queue.Enqueue(new KeyValuePair<string, int>($"{start[0]}:{start[1]}", 0));
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                var parts = cur.Key.Split(':');
                int curX = int.Parse(parts[0]), curY = int.Parse(parts[1]), curCost = cur.Value;
                foreach (var road in specialRoads)
                {
                    int fromX = road[0], fromY = road[1], toX = road[2], toY = road[3];
                    if (curX != fromX || curY != fromY)
                    {
                        var cost = Math.Abs(curX - fromX) + Math.Abs(curY - fromY);
                        if (curCost + cost < dp[$"{fromX}:{fromY}"])
                        {
                            dp[$"{fromX}:{fromY}"] = curCost + cost;
                            queue.Enqueue(new KeyValuePair<string, int>($"{fromX}:{fromY}", curCost + cost));
                        }
                    }
                    else
                    {
                        var cost = road[4];
                        if (curCost + cost < dp[$"{toX}:{toY}"])
                        {
                            dp[$"{toX}:{toY}"] = curCost + cost;
                            queue.Enqueue(new KeyValuePair<string, int>($"{toX}:{toY}", curCost + cost));
                        }
                    }
                    if (curX != toX || curY != toY)
                    {
                        var cost = Math.Abs(curX - toX) + Math.Abs(curY - toY);
                        if (curCost + cost < dp[$"{toX}:{toY}"])
                        {
                            dp[$"{toX}:{toY}"] = curCost + cost;
                            queue.Enqueue(new KeyValuePair<string, int>($"{toX}:{toY}", curCost + cost));
                        }
                    }
                    if (curX != target[0] || curY != target[1])
                    {
                        var cost = Math.Abs(curX - target[0]) + Math.Abs(curY - target[1]);
                        if (curCost + cost < dp[$"{target[0]}:{target[1]}"])
                        {
                            dp[$"{target[0]}:{target[1]}"] = curCost + cost;
                            queue.Enqueue(new KeyValuePair<string, int>($"{target[0]}:{target[1]}", curCost + cost));
                        }
                    }
                }
            }
            return dp[$"{target[0]}:{target[1]}"];
        }
    }
}
