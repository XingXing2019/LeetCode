using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLadderII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string beginWord = "hit", endWord = "cog";
            var wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            Console.WriteLine(FindLadders(beginWord, endWord, wordList));
        }


        class Node
        {
            public string cur;
            public string path;
            public int count;
            public Node(string cur, string path, int count)
            {
                this.cur = cur;
                this.path = path;
                this.count = count;
            }
        }
        public static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var res = new List<IList<string>>();
            if (!wordList.Contains(endWord))
                return res;
            var graph = new Dictionary<string, List<string>>();
            var dp = new Dictionary<string, Dictionary<string, int>> { { beginWord, new Dictionary<string, int>() } };
            for (int i = 0; i < wordList.Count; i++)
            {
                if (!dp.ContainsKey(wordList[i]))
                    dp[wordList[i]] = new Dictionary<string, int>();
                dp[beginWord][wordList[i]] = int.MaxValue;
                dp[wordList[i]][beginWord] = int.MaxValue;
                for (int j = 0; j < wordList.Count; j++)
                {
                    if (i == j) continue;
                    dp[wordList[i]][wordList[j]] = int.MaxValue;
                    if (!IsValid(wordList[i], wordList[j])) continue;
                    if (!graph.ContainsKey(wordList[i]))
                        graph[wordList[i]] = new List<string>();
                    if (!graph.ContainsKey(wordList[j]))
                        graph[wordList[j]] = new List<string>();
                    graph[wordList[i]].Add(wordList[j]);
                    graph[wordList[j]].Add(wordList[i]);
                }
                if (!IsValid(beginWord, wordList[i])) continue;
                if (!graph.ContainsKey(beginWord))
                    graph[beginWord] = new List<string>();
                if (!graph.ContainsKey(wordList[i]))
                    graph[wordList[i]] = new List<string>();
                graph[beginWord].Add(wordList[i]);
                graph[wordList[i]].Add(beginWord);
            }
            var queue = new Queue<Node>();
            queue.Enqueue(new Node(beginWord, beginWord, 1));
            var visited = new HashSet<string>();
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur.cur == endWord)
                {
                    res.Add(cur.path.Split("->"));
                    continue;
                }
                foreach (var next in graph[cur.cur])
                {
                    var path = $"{cur.path}->{next}";
                    if (dp[cur.cur][next] < cur.count + 1 || visited.Contains(path)) continue;
                    dp[cur.cur][next] = cur.count + 1;
                    visited.Add(path);
                    queue.Enqueue(new Node(next, path, cur.count + 1));
                }
            }
            return res;
        }

        public static bool IsValid(string word1, string word2)
        {
            var count = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] != word2[i]) count++;
                if (count > 1) return false;
            }
            return count == 1;
        }
    }
}
