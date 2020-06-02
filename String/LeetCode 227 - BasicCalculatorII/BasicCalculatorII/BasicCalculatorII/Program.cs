//人为将字符串末尾加上'@'号，作为终止最后一个获取数字的条件。
//遍历字符串，用字符串tem临时存储数字，如果遇到+或者-，则一起存入tem，这样可通过int.Parse得到正确的正负数。
//如果遇到*或者/，则存入符号栈。到下一次得到数字后，再将其弹出，结合符号栈中的*或者/号，进行相应运算。
//将计算的数字都存入，数字栈。最后将数字栈中的数字相加即为结果。
using System;
using System.Collections;

namespace BasicCalculatorII
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "+5*5-14/3*2+1";
            Console.WriteLine(Calculate(s));
        }
        static int Calculate(string s)
        {
            s += '@';
            Stack numStack = new Stack();
            Stack operatorStack = new Stack();
            string tem = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] - '0' >= 0 && s[i] - '0' <= 9)
                    tem += s[i];
                else if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/' || s[i] == '@')
                {
                    if (tem != "")
                    {
                        numStack.Push(int.Parse(tem));
                        tem = "";
                    }
                    if (s[i] == '+' || s[i] == '-')
                        tem = s[i] + tem;
                    if (operatorStack.Count != 0 && (char)operatorStack.Peek() == '*')
                    {
                        numStack.Push((int)numStack.Pop() * (int)numStack.Pop());
                        operatorStack.Pop();
                    }
                    else if (operatorStack.Count != 0 && (char)operatorStack.Peek() == '/')
                    {
                        int tem1 = (int)numStack.Pop();
                        int tem2 = (int)numStack.Pop();
                        numStack.Push(tem2 / tem1);
                        operatorStack.Pop();
                    }
                    if (s[i] == '*' || s[i] == '/')
                        operatorStack.Push(s[i]);
                }
            }
            int res = 0;
            while (numStack.Count != 0)
                res += (int)numStack.Pop();
            return res;
        }
    }
}
