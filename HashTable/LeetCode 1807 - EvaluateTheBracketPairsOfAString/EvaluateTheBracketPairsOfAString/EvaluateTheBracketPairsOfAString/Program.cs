using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluateTheBracketPairsOfAString
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "(name)is(age)yearsold";
            var knowledge = new List<IList<string>>()
            {
                new List<string> {"name", "bob"},
                new List<string> {"age", "two"},
            };
            Console.WriteLine(Evaluate(s, knowledge));
        }
        public static string Evaluate(string s, IList<IList<string>> knowledge)
        {
            var dict = knowledge.ToDictionary(x => x[0], x => x[1]);
            var useTemp = false;
            string res = "", temp = "";
            foreach (var l in s)
            {
                if (l == '(')
                    useTemp = true;
                else if (l == ')')
                {
                    res += dict.ContainsKey(temp) ? dict[temp] : "?";
                    useTemp = false;
                    temp = "";
                }
                else
                {
                    if (useTemp) temp += l;
                    else res += l;
                }
            }
            return res;
        }
    }
}
