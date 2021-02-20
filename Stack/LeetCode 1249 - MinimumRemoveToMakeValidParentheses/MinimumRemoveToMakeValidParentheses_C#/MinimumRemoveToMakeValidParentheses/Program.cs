//创建StringBuilder型res，初始值设为s。创建record栈用于记录不能配对的括号的index。
//遍历s，当遇到左括号，则将其index压栈。当遇到右括号，如果栈不为空，且栈顶index在s中为左括号，则将栈顶弹出。否则将当前index压栈。
//最后遍历record栈，将其中记录的index在res中对应元素删除。
using System;
using System.Collections.Generic;
using System.Text;

namespace MinimumRemoveToMakeValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "))a((";
            Console.WriteLine(MinRemoveToMakeValid(s));
        }
        static string MinRemoveToMakeValid(string s)
        {
            Stack<int> record = new Stack<int>();
            StringBuilder res = new StringBuilder(s);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    record.Push(i);
                else if(s[i] == ')')
                {
                    if (record.Count != 0 && s[record.Peek()] == '(')
                        record.Pop();
                    else
                        record.Push(i);
                }
            }
            foreach (var index in record)
                res.Remove(index, 1);
            return res.ToString();
        }
    }
}
