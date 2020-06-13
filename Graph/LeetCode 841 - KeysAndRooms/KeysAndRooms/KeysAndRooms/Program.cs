//典型图论，利用队列先进先出的特点辅助遍历房间。先将0号房间入队，并在visit中做标记。
//在队列不为空的条件下循环。弹出对头代表现在所在的房间，再将当前所在房间钥匙中，所有没进过的房间入队，并在visit中标记。
//循环结束后没有和0号房间关联的房间一定没有被标记过、
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
            Console.WriteLine(CanVisitAllRooms(rooms));
        }
        static bool CanVisitAllRooms(IList<IList<int>> rooms)
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
    }
}
