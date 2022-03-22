using System;
using System.Collections.Generic;

namespace ShortestPathInAHiddenGrid
{

    interface GridMaster
    {
        bool canMove(char direction);
        void move(char direction);
        bool isTarget();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        public int FindShortestPath(GridMaster master)
        {
            var isPath = new bool[1001][];
            var visited = new bool[1001][];
            var target = new[] { -1, -1 };
            for (int i = 0; i < isPath.Length; i++)
            {
                isPath[i] = new bool[1001];
                visited[i] = new bool[1001];
            }
            DFS(master, 501, 501, isPath, visited, ref target);
            if (target[0] == -1 && target[1] == -1)
                return -1;
            return BFS(isPath, target);
        }

        public void DFS(GridMaster master, int x, int y, bool[][] isPath, bool[][] visited, ref int[] target) 
        {
            if (x < 0 || x >= 1001 || y < 0 || y >= 1001 || visited[x][y])
                return;
            visited[x][y] = true;
            if (master.isTarget())
            {
                target[0] = x;
                target[1] = y;
            }
            char[] dir = { 'U', 'D', 'L', 'R' };
            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                if (!master.canMove(dir[i])) continue;
                int newX = x + dx[i], newY = y + dy[i];
                isPath[newX][newY] = true;
                master.move(dir[i]);
                DFS(master, newX, newY, isPath, visited, ref target);
                var back = i % 2 == 0 ? dir[i + 1] : dir[i - 1];
                master.move(back);
            }
        }

        public int BFS(bool[][] isPath, int[] target)
        {
            var queue = new Queue<int[]>();
            var visited = new bool[isPath.Length][];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = new bool[isPath[0].Length];
            visited[501][501] = true;
            queue.Enqueue(new []{501, 501, 0});
            int[] dir = { 1, 0, -1, 0, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == target[0] && cur[1] == target[1])
                    return cur[2];
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
                    if (newX < 0 || newX >= isPath.Length || newY < 0 || newY >= isPath[0].Length || visited[newX][newY] || !isPath[newX][newY])
                        continue;
                    visited[newX][newY] = true;
                    queue.Enqueue(new []{newX, newY, cur[2] + 1});
                }
            }
            return -1;
        }
    }
}
