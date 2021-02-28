using System;
using System.Linq;
using System.Collections.Generic;

namespace CountItemsMatchingARule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            if (ruleKey == "type") return items.Count(x => x[0] == ruleValue);
            if (ruleKey == "color") return items.Count(x => x[1] == ruleValue);
            return items.Count(x => x[2] == ruleValue);
        }
    }
}
