using System;
using System.Collections.Generic;

namespace MostPopularVideoCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] creators = { "a", "a" };
            string[] ids = { "aa", "a" };
            int[] views = { 5, 5 };
            Console.WriteLine(MostPopularCreator(creators, ids, views));
        }

        public static IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views)
        {
            var popularity = new Dictionary<string, long>();
            var videos = new Dictionary<string, long>();
            long max = 0;
            for (int i = 0; i < creators.Length; i++)
            {
                var creator = creators[i];
                if (!popularity.ContainsKey(creator))
                {
                    popularity[creator] = 0;
                    videos[creator] = i;
                }
                popularity[creator] += views[i];
                if (views[i] > views[videos[creator]])
                    videos[creator] = i;
                else if (views[i] == views[videos[creator]] && ids[i].CompareTo(ids[videos[creator]]) < 0)
                    videos[creator] = i;
                max = Math.Max(max, popularity[creator]);
            }
            var res = new List<IList<string>>();
            foreach (var creator in popularity.Keys)
            {
                if (popularity[creator] != max) continue;
                res.Add(new List<string> { creator, ids[videos[creator]] });
            }
            return res;
        }
    }
}
