using System;
using System.Linq;

namespace ShortestDistanceToTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int ClosetTarget(string[] words, string target, int startIndex)
        {
            if (!words.Contains(target))
                return -1;
            int dis1 = 0, dis2 = 0;
            int p1 = startIndex, p2 = startIndex;
            while (p1 != startIndex + 1 && words[p1] != target)
            {
                p1--;
                if (p1 < 0) p1 = words.Length - 1;
                dis1++;
            }
            while (p2 != startIndex - 1 && words[p2] != target)
            {
                p2++;
                if (p2 == words.Length) p2 = 0;
                dis2++;
            }
            return Math.Min(dis1, dis2);
        }
    }
}
