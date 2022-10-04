//按照要求对每个domain进行分割处理，然后用一个record字典统计每个subDomain出现的次数，再次遍历record将结果记入res。
using System;
using System.Collections.Generic;

namespace SubdomainVisitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cpdomains = {"900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"};
            Console.WriteLine(SubdomainVisits(cpdomains));
        }
        static IList<string> SubdomainVisits(string[] cpdomains)
        {
            List<string> res = new List<string>();
            var record = new Dictionary<string, int>();
            foreach (var d in cpdomains)
            {
                string[] split = d.Split(" ");
                string[] domains = split[1].Split(".");
                string tem = "";
                for (int i = domains.Length-1; i >= 0; i--)
                {
                    tem = "." + domains[i] + tem;
                    if (!record.ContainsKey(tem))
                        record[tem] = int.Parse(split[0]);
                    else
                        record[tem] += int.Parse(split[0]);
                }
            }
            foreach (var r in record)
                res.Add(r.Value.ToString() + " " + r.Key.Substring(1));
            return res;
        }
    }
}
