//创建辅助方法CreateParenthesis用于将一对"()"加原有括号字符串。
//逻辑为先将一对括号分别加到字符串最后，和套在字符串最外层。将所得结果分别存入列表。
//再遍历字符串，如发现"("，则在其后面加上一对括号，并在列表中不存在该新生成字符串时，将其加入列表。
//在主方法中创建动态数组dpString，长度为n + 1，用于动态生成数字所对应的的字符串列表。将dpString[1]设为"()"作为边界条件。
//从i=2处遍历dpString，对当前元素的前一元素所对应的字符串列表中的每一个字符串调用CreateParenthesis方法。
//将新获得的字符串列表中的每个字符串，在不重复的条件下加入一个临时列表，并将其赋予dpString[i]。
//最后返回dpString[n]即为结果。
using System;
using System.Collections.Generic;

namespace GenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Console.WriteLine(GenerateParenthesis(n));
        }
        static IList<string> GenerateParenthesis(int n)
        {
            if (n == 0)
                return new List<string>() { "" };
            List<string>[] dpString = new List<string>[n + 1];
            dpString[1] = new List<string> { "()" };
            for (int i = 2; i < dpString.Length; i++)
            {
                List<string> temString = new List<string>();
                foreach (var str in dpString[i - 1])
                {
                    List<string> resForEachStr = CreateParenthesis(str);
                    foreach (var parenthesis in resForEachStr)
                    {
                        if (!temString.Contains(parenthesis))
                            temString.Add(parenthesis);
                    }
                }
                dpString[i] = temString;
            }
            return dpString[n];
        }
        static List<string> CreateParenthesis(string parenthesis)
        {
            List<string> res = new List<string>();
            string case1 = parenthesis + "()";
            string case2 = "(" + parenthesis + ")";
            res.Add(case1);
            res.Add(case2);
            for (int i = 0; i < parenthesis.Length; i++)
            {
                if (parenthesis[i] == '(')
                {
                    string tem = parenthesis.Insert(i + 1, "()");
                    if (!res.Contains(tem))
                        res.Add(tem);
                }
            }
            return res;
        }

        static IList<string> GenerateParenthesis_BackTracking(int n)
        {
            var res = new List<string>();
            DFS(n, "", res, 0, 0);
            return res;
        }

        static void DFS(int n, string parentheses, List<string> res, int open, int close)
        {
            if (parentheses.Length == n * 2)
            {
                res.Add(parentheses);
                return;
            }
            if (open < n)
                DFS(n, $"{parentheses}(", res, open + 1, close);
            if (close < open)
                DFS(n, $"{parentheses})", res, open, close + 1);
        }
    }
}
