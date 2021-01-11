using System;
using System.Collections.Generic;
using System.Linq;

namespace ReorderDataInLogFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] logs = { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo", "a2 act car" };
            Console.WriteLine(ReorderLogFiles_Linq(logs));
        }
        static string[] ReorderLogFiles_Sort(string[] logs)
        {
            var let = logs.Where(x => char.IsLetter(x[x.IndexOf(' ') + 1])).ToList();
            var dig = logs.Where(x => char.IsDigit(x[x.IndexOf(' ') + 1])).ToList();
            let.Sort((a, b) =>
                {
                    string a_substr = a.Substring(a.IndexOf(' ') + 1);
                    string b_substr = b.Substring(b.IndexOf(' ') + 1);
                    var result = String.Compare(a_substr, b_substr, StringComparison.Ordinal);
                    if (result == 0)
                        result = String.Compare(a.Substring(0, a.IndexOf(' ')), b.Substring(0, b.IndexOf(' ')), StringComparison.Ordinal);
                    return result;
                });
            var res = new List<string>();
            res.AddRange(let);
            res.AddRange(dig);
            return res.ToArray();
        }
        public string[] ReorderLogFiles_Linq(string[] logs)
        {
            var lets = logs.Where(x => !char.IsDigit(x[^1])).OrderBy(x => x.Substring(x.IndexOf(' '))).ThenBy(x => x).ToList();
            var digs = logs.Where(x => char.IsDigit(x[^1]));
            lets.AddRange(digs);
            return lets.ToArray();
        }
    }
}
