using System;
using System.Collections.Generic;
using System.Linq;

namespace GetWatchedVideosByYourFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            var watchedVideos = new List<IList<string>>
            {
                new List<string> {"A", "B"},
                new List<string> {"C"},
                new List<string> {"B", "C"},
                new List<string> {"D"},
            };
            var friends = new int[][]
            {
                new[] {1, 2},
                new[] {0, 3},
                new[] {0, 3},
                new[] {1, 2},
            };
            int id = 0, level = 2;
            Console.WriteLine(WatchedVideosByFriends(watchedVideos, friends, id, level));
        }
        static IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            var queue = new Queue<int>();
            queue.Enqueue(id);
            var visited = new HashSet<int> {id};
            var levelFriends = new HashSet<int>();
            while (queue.Count != 0)
            {
                var count = queue.Count;
                level--;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    foreach (var next in friends[cur])
                    {
                        if (visited.Add(next))
                        {
                            queue.Enqueue(next);
                            if (level == 0)
                                levelFriends.Add(next);
                        }
                    }
                }
                if(level == 0) break;
            }
            var dict = new Dictionary<string, int>();
            foreach (var friend in levelFriends)
            {
                var videos = watchedVideos[friend];
                foreach (var video in videos)
                {
                    if (!dict.ContainsKey(video))
                        dict[video] = 0;
                    dict[video]++;
                }
            }
            return dict.OrderBy(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).ToList();
        }
    }
}
