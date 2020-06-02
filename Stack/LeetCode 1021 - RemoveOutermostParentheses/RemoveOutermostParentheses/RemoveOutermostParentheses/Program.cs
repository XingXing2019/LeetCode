//创建res记录结果，创建left和right分别记录左括号和右括号的个数。创建index记录起始位置。
//遍历字符串，遇到左括号则left加一，遇到右括号则right加一。
//当left等于right时，截取最外层括号之内的字符串加入res。将left和right归零。并将index设为i+1。
using System;

namespace RemoveOutermostParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "";
            Console.WriteLine(RemoveOuterParentheses(S));
        }
        static string RemoveOuterParentheses(string S)
        {
            string res = "";
            int left = 0;
            int right = 0;
            int index = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                    left++;
                else
                    right++;
                if(left == right)
                {
                    res += S.Substring(index + 1, left + right - 2);
                    left = 0;
                    right = 0;
                    index = i + 1;
                }
            }
            return res;
        }
    }
}
