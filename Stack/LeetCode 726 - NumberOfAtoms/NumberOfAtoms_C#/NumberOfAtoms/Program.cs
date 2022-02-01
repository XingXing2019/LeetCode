using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberOfAtoms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static string CountOfAtoms(string formula)
        {
            var dict = Count(GenerateFormula(formula) + 'A');
            return string.Join("", dict.OrderBy(x => x.Key).Select(x => x.Key + (x.Value == 1 ? string.Empty : x.Value.ToString())));
        }

        public static string GenerateFormula(string formula)
        {
            var first = formula.IndexOf('(');
            if (first == -1) return formula;
            var res = formula.Substring(0, first);
            int open = 1, close = 0, count = 0, index = first + 1;
            while (index < formula.Length && open != close)
            {
                if (formula[index] == '(') open++;
                else if (formula[index] == ')') close++;
                index++;
            }
            var temp = GenerateFormula(formula.Substring(first + 1, index - first - 2));
            while (index < formula.Length && char.IsDigit(formula[index]))
            {
                count = count * 10 + (formula[index] - '0');
                index++;
            }
            res += temp;
            for (int i = 1; i < count; i++)
                res += temp;
            return res + GenerateFormula(formula.Substring(index));
        }

        public static Dictionary<string, int> Count(string formula)
        {
            var element = new StringBuilder();
            var count = 0;
            var dict = new Dictionary<string, int>();
            foreach (var l in formula)
            {
                if (char.IsDigit(l))
                    count = count * 10 + (l - '0');
                else
                {
                    if (char.IsUpper(l) && element.Length != 0)
                    {
                        if (!dict.ContainsKey(element.ToString()))
                            dict[element.ToString()] = 0;
                        dict[element.ToString()] += Math.Max(1, count);
                        count = 0;
                        element = new StringBuilder();
                    }
                    element.Append(l);
                }
            }
            return dict;
        }
    }
}
