using System;
using System.Collections.Generic;

namespace TotalAppealOfAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long AppealSum(string s)
        {
            long res = 0;
            var positions = new List<int>[26];
            for (int i = 0; i < s.Length; i++)
            {
                if (positions[s[i] - 'a'] == null)
                    positions[s[i] - 'a'] = new List<int>();
                positions[s[i] - 'a'].Add(i);
            }
            foreach (var position in positions)
            {
                if (position == null)
                    continue;
                for (int i = 0; i < position.Count; i++)
                {
                    if (i == 0)
                        res += (position[i] + 1) * (s.Length - position[i]);
                    else
                        res += (position[i] - position[i - 1]) * (s.Length - position[i]);
                }
            }
            return res;
        }
    }
}
