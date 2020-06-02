using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
