﻿//创建字典保存括号对。创建Stack保存字符串中的字符。先将字符串中的首字符压入栈中。
//遍历字符串检查每个字符。如当前栈为空，则将当前字符压入栈中。否则验证当前字符合法性。
//创建current保存当前栈顶字符，当current为字典中的key并且当前遍历到的字符和current成键值对时，则将栈顶字符弹出。否则将当前字符压入栈。
//遍历结束后，如栈为空返回true，否则返回false。
using System;
using System.Collections;
using System.Collections.Generic;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsValid(string s)
        {
            var dict = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };
            var stack = new Stack<char>();
            foreach (var letter in s)
            {
                if (stack.Count == 0 || dict.ContainsKey(letter))
                    stack.Push(letter);
                else
                {
                    if (dict.ContainsKey(stack.Peek()) && letter == dict[stack.Peek()])
                        stack.Pop();
                    else
                        stack.Push(letter);
                }
            }
            return stack.Count == 0;
        }
    }
}
