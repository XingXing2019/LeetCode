//遍历s，将遍历到的字符记录入一个StringBuilder(temRes)。如果当前字符为左括号，将其index记录入一个列表。
//如果为右括号，则从截取列表中最后一个左括号的位置开始到当前位置的字符存入一个临时数组，再将这个数组中的字符逆序加入temRes。再将列表中的最后一个index删除。
//最后遍历temRes，将不是括号的字符加入res。
using System;
using System.Text;
using System.Collections.Generic;

namespace ReverseSubstringsBetweenParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a(bcdefghijkl(mno)p)q";
            Console.WriteLine(ReverseParentheses(s));
        }
        static string ReverseParentheses(string s)
        {
            var ParenthesePositions = new List<int>();
            var temRes = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                temRes.Append(s[i]);
                if (s[i] == '(')
                    ParenthesePositions.Add(i);
                else if (s[i] == ')')
                {
                    int start = ParenthesePositions[ParenthesePositions.Count - 1];
                    int count = i - ParenthesePositions[ParenthesePositions.Count - 1];
                    var tem = new char[count];
                    temRes.CopyTo(start, tem, 0, count);
                    temRes.Remove(ParenthesePositions[ParenthesePositions.Count - 1], i - ParenthesePositions[ParenthesePositions.Count - 1]);
                    ParenthesePositions.RemoveAt(ParenthesePositions.Count - 1);
                    for (int j = tem.Length-1; j >= 0; j--)
                        temRes.Append(tem[j]);
                }
            }
            string res = "";
            for (int i = 0; i < temRes.Length; i++)
                if (temRes[i] != '(' && temRes[i] != ')')
                    res += temRes[i];
            return res;
        }
    }
}
