//创建两个栈一个记录数字，一个记录字母。
//对于每一个字符，如果是数字则压数字栈，如果是字母则压字母栈。
//如果是左括号则同时压栈。
//如果是右括号，则将两个栈中的数字和字母弹栈，直到栈为空，或者栈顶为左括号。再将记录的字母乘以倍数后，在压入字母栈。
//如果注意数字有个能是多位数字，
using System;
using System.Collections.Generic;

namespace DecodeString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "3[a2[c]]";
            Console.WriteLine(DecodeString(s));
        }
        static string DecodeString(string s)
        {
            Stack<string> digits = new Stack<string>(), letters = new Stack<string>();
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                    digits.Push(c.ToString());
                else if(char.IsLetter(c))
                    letters.Push(c.ToString());
                else if (c == '[')
                {
                    letters.Push(c.ToString());
                    digits.Push(c.ToString());
                }
                else
                {
                    string temp = "", times = "", word = "";
                    digits.Pop();
                    while (digits.Count != 0 && digits.Peek() != "[")
                        times = digits.Pop() + times;
                    while (letters.Count != 0 && letters.Peek() != "[")
                        temp = letters.Pop() + temp;
                    letters.Pop();
                    int n = int.Parse(times);
                    for (int i = 0; i < n; i++)
                        word += temp;
                    letters.Push(word);
                }
            }
            var res = "";
            while (letters.Count != 0)
                res = letters.Pop() + res;
            return res;
        }
    }
}
