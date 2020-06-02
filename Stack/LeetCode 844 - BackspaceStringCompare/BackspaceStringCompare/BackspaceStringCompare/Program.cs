//创建两个栈存储字符。
//分别遍历字符串，在栈不为空，且当前字符为#时，进行弹栈。在当前字符不为#时，将其压入栈中。
//分别获取结果字符串，比较其是否相等。
using System;
using System.Collections;

namespace BackspaceStringCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "y#fo##f";
            string T = "y#f#o##f";
            Console.WriteLine(BackspaceCompare(S, T));
        }
        static bool BackspaceCompare(string S, string T)
        {
            Stack sStack = new Stack();
            Stack tStack = new Stack();
            for (int i = 0; i < S.Length; i++)
            {
                if (sStack.Count != 0 && S[i] == '#')
                    sStack.Pop();
                else if(S[i] != '#')
                    sStack.Push(S[i]);
            }
            for (int i = 0; i < T.Length; i++)
            {
                if (tStack.Count != 0 && T[i] == '#')
                    tStack.Pop();
                else if (T[i] != '#')
                    tStack.Push(T[i]);
            }
            string sRes = "";
            string tRes = "";
            while (sStack.Count != 0)
                sRes = sStack.Pop() + sRes;
            while (tStack.Count != 0)
                tRes = tStack.Pop() + tRes;
            return sRes == tRes;
        }
    }
}
