using System;
using System.Collections.Generic;
using System.Text;

namespace RestoreIPAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "25525511135";
            Console.WriteLine(RestoreIpAddresses(s));
        }
        static IList<string> RestoreIpAddresses(string s)
        {
            var res = new List<string>();
            DFS(new List<string>(), s, res);
            return res;
        }

        static void DFS(List<string> parts, string remain, List<string> res)
        {
            if (parts.Count == 4)
            {
                if(remain.Length == 0)
                    res.Add(string.Join('.', parts));
                return;
            }
            for (int i = 1; i <= 3 && i <= remain.Length; i++)
            {
                var part = remain.Substring(0, i);
                if(part.Length > 1 && part[0] == '0' || int.Parse(part) > 255) continue;
                parts.Add(part);
                DFS(parts, remain.Substring(i), res);
                parts.RemoveAt(parts.Count - 1);
            }
        }
    }
}
