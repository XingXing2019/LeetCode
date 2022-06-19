using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace SearchSuggestionsSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = {"mobile", "mouse", "moneypot", "monitor", "mousepad"};
            string searchWord = "mouse";
            Console.WriteLine(SuggestedProducts(products, searchWord));
        }
        static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Array.Sort(products);
            var dict = new Dictionary<string, List<string>>();
            for (int len = 1; len <= searchWord.Length; len++)
            {
                string pewfix = searchWord.Substring(0, len);
                dict[pewfix] = SelectWords(products, pewfix);
            }
            var res = new List<IList<string>>();
            for (int len = 1; len <= searchWord.Length; len++)
            {
                string tem = searchWord.Substring(0, len);
                res.Add(dict[tem]);
            }
            return res;
        }

        static List<string> SelectWords(string[] products, string prefix)
        {
            var res = new List<string>();
            for (int i = 0; i < products.Length && res.Count < 3; i++)
                if(products[i].StartsWith(prefix))
                    res.Add(products[i]);
            return res;
        }


        class TrieNode
        {
            public TrieNode[] children;
            public List<string> words;

            public TrieNode()
            {
                children = new TrieNode[26];
                words = new List<string>();
            }
        }

        public IList<IList<string>> SuggestedProducts_Trie(string[] products, string searchWord)
        {
            var root = new TrieNode();
            products = products.OrderBy(x => x).ToArray();
            foreach (var product in products)
            {
                var point = root;
                foreach (var l in product)
                {
                    if (point.children[l - 'a'] == null)
                        point.children[l - 'a'] = new TrieNode();
                    point = point.children[l - 'a'];
                    point.words.Add(product);
                }
            }
            var res = new List<IList<string>>();
            foreach (var l in searchWord)
            {
                if (root.children[l - 'a'] == null)
                    root.children[l - 'a'] = new TrieNode();
                root = root.children[l - 'a'];
                var temp = new List<string>();
                for (int i = 0; i < 3 && i < root.words.Count; i++)
                    temp.Add(root.words[i]);
                res.Add(temp);
            }
            return res;
        }
    }
}
