using System;

namespace MapSumPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new MapSum();
            map.Insert("apple", 3);
            Console.WriteLine(map.Sum("ap"));
            map.Insert("app", 2);
            Console.WriteLine(map.Sum("ap"));
        }
    }

    class TrieNode
    {
        public bool IsWord { get; set; }
        public int Value { get; set; }
        public TrieNode[] Children { get; set; }
        public TrieNode()
        {
            Children = new TrieNode[26];
        }
    }
    public class MapSum
    {
        private TrieNode root;
        public MapSum()
        {
            root = new TrieNode();
        }

        public void Insert(string key, int val)
        {
            var cur = root;
            foreach (var letter in key)
            {
                if (cur.Children[letter - 'a'] == null)
                    cur.Children[letter - 'a'] = new TrieNode();
                cur = cur.Children[letter - 'a'];
            }
            cur.IsWord = true;
            cur.Value = val;
        }

        public int Sum(string prefix)
        {
            int sum = 0;
            var cur = root;
            foreach (var letter in prefix)
            {
                cur = cur.Children[letter - 'a'];
                if (cur == null)
                    return sum;
            }
            DFS(cur, ref sum);
            return sum;
        }

        private int DFS(TrieNode node, ref int sum)
        {
            if (node == null)
                return 0;
            sum += node.Value;
            foreach (var child in node.Children)
                DFS(child, ref sum);
            return sum;
        }
    }
}
