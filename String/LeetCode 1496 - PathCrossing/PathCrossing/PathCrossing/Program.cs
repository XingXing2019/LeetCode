//根据path记录坐标，将坐标存入set，如果存不进去，证明有重叠
using System;
using System.Collections.Generic;

namespace PathCrossing
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "NESWW";
            Console.WriteLine(IsPathCrossing(path));
        }
        static bool IsPathCrossing(string path)
        {
            int x = 0, y = 0;
            var set = new HashSet<string>();
            set.Add($"{x},{y}");
            foreach (var direction in path)
            {
                if (direction == 'N')
                    y++;
                else if (direction == 'S')
                    y--;
                else if (direction == 'E')
                    x++;
                else
                    x--;
                if (!set.Add($"{x},{y}"))
                    return true;
            }
            return false;
        }
    }
}
