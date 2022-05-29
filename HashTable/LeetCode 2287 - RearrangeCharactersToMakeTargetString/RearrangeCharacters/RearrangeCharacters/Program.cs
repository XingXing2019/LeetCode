using System;
using System.Linq;

namespace RearrangeCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int RearrangeCharacters(string s, string target)
        {
            var sDict = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var tDict = target.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = int.MaxValue;
            foreach (var letter in tDict.Keys)
            {
                if (!sDict.ContainsKey(letter)) return 0;
                res = Math.Min(res, sDict[letter] / tDict[letter]);
            }
            return res;
        }
    }
}
