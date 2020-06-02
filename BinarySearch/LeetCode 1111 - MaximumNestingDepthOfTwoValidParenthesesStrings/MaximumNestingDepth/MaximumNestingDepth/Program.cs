//创建stackA和stackB两个栈存储括号。遍历seq字符串，如果当前字符为左括号，当stackA中的字符数量小于等于stackB中字符数量时，将其index压入stackA，否则压入stackB。
//如果当前字符为右括号，当stackA中字符数量大于等于stackB中字符数量时，将当前index与stackA栈顶index在res中对应位置设为1。否则将stackB栈顶弹出。
using System;
using System.Collections;

namespace MaximumNestingDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            string seq = "()(())()";
            Console.WriteLine(MaxDepthAfterSplit(seq));
        }
        static int[] MaxDepthAfterSplit(string seq)
        {
            int[] res = new int[seq.Length];
            Stack stackA = new Stack();
            Stack stackB = new Stack();
            for (int i = 0; i < seq.Length; i++)
            {
                if(seq[i] == '(')
                {
                    if (stackA.Count <= stackB.Count)
                        stackA.Push(i);
                    else
                        stackB.Push(i);
                }
                else
                {
                    if (stackA.Count >= stackB.Count)
                    {
                        int top = (int)stackA.Pop();
                        res[i] = 1;
                        res[top] = 1;
                    }
                    else
                        stackB.Pop();
                }
            }
            return res;
        }
    }
}
