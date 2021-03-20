using System;
using System.Collections.Generic;

namespace PalindromePartitioning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<string>> Partition(string s)
        {
            var res = new List<IList<string>>();
            DFS(s, new List<string>(), res);
            return res;
        }

        private void DFS(string remain, List<string> item, List<IList<string>> res)
        {
            if(remain.Length == 0)
                res.Add(new List<string>(item));
            for (int i = 0; i < remain.Length; i++)
            {
                if (CheckPalindrome(remain.Substring(0, i + 1)))
                {
                    item.Add(remain.Substring(0, i + 1));
                    DFS(remain.Substring(i + 1), item, res);
                    item.RemoveAt(item.Count - 1);
                }
            }
        }

        private bool CheckPalindrome(string s)
        {
            int li = 0, hi = s.Length - 1;
            while (li < hi)
            {
                if (s[li++] != s[hi--])
                    return false;
            }
            return true;
        }
    }
}
