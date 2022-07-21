using System;
using System.Collections.Generic;
using System.Linq;

namespace FindingTheNumberOfVisibleMountains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static int VisibleMountains(int[][] peaks)
        {
            var dict = peaks.GroupBy(x => $"{x[0]}:{x[1]}").ToDictionary(x => x.Key, x => x.Count());
            peaks = peaks.OrderBy(x => x[0]).ToArray();
            var stack = new Stack<int>();
            var pushed = new HashSet<string>();
            for (int i = 0; i < peaks.Length; i++)
            {
                while (stack.Count != 0 && !CanNotCover(peaks, i, stack.Peek()))
                    stack.Pop();
                if (stack.Count == 0 || CanNotCover(peaks, stack.Peek(), i))
                {
                    var peak = peaks[i];
                    pushed.Add($"{peak[0]}:{peak[1]}");
                    stack.Push(i);
                }
            }
            return stack.Count - dict.Count(x => x.Value != 1 && pushed.Contains(x.Key));
        }

        private static bool CanNotCover(int[][] peak, int cur, int last)
        {
            int curX = peak[cur][0], curY = peak[cur][1];
            int lastX = peak[last][0], lastY = peak[last][1];
            return lastY > lastX - (curX - curY) || lastY > (curX + curY) - lastX;
        }
    }
}
