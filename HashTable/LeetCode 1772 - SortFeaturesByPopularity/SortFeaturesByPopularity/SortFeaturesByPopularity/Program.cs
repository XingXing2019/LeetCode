using System;
using System.Collections.Generic;
using System.Linq;

namespace SortFeaturesByPopularity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string[] SortFeatures(string[] features, string[] responses)
        {
            var dict = new Dictionary<string, int[]>();
            for (int i = 0; i < features.Length; i++)
                dict.Add(features[i], new[] {i, 0});
            foreach (var response in responses)
            {
                var words = response.Split(' ');
                var set = new HashSet<string>();
                foreach (var word in words)
                {
                    if(!dict.ContainsKey(word)) continue;
                    if(set.Add(word)) dict[word][1]++;
                }
            }
            return dict.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Value[0]).Select(x => x.Key).ToArray();
        }
    }
}
