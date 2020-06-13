//解法一：广度优先搜索。利用队列先进先出的特点辅助遍历房间。先将0号房间入队，并在visit中做标记。
//在队列不为空的条件下循环。弹出对头代表现在所在的房间，再将当前所在房间钥匙中，所有没进过的房间入队，并在visit中标记。
//循环结束后没有和0号房间关联的房间一定没有被标记过、

//解法二：深度优先搜索。深度搜索每个房间中钥匙能进入的房间。边界条件是进过的房间返回。
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysAndRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            var rooms = new List<IList<int>>()
            {
                new List<int>{1, 3},
                new List<int>{3, 0, 1},
                new List<int>{2},
                new List<int>{0}
            };
            Console.WriteLine(CanVisitAllRooms_BFS(rooms));
        }
        static bool CanVisitAllRooms_BFS(IList<IList<int>> rooms)
        {
            var visit = new bool[rooms.Count];
            var queue = new Queue<int>();
            queue.Enqueue(0);
            visit[0] = true;
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in rooms[cur])
                {
                    if (visit[next]) continue;
                    queue.Enqueue(next);
                    visit[next] = true;
                }
            }
            return visit.All(x => x);
        }

        static bool CanVisitAllRooms_DFS(IList<IList<int>> rooms)
        {
            var visit = new HashSet<int>();
            DFS(0, rooms, visit);
            return rooms.Count == visit.Count;
        }

        static void DFS(int cur, IList<IList<int>> rooms, HashSet<int> visit)
        {
            if (!visit.Add(cur)) return;
            foreach (var next in rooms[cur])
                DFS(next, rooms, visit);
        }
    }
}
