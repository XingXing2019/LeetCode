//创建StringBuilder型res，遍历S，如果res不为空，且最后一个字母与S[i]相同，则将res最后一个字母去掉。否则将S[i]加入res。最后返回res.Tostring()。
//用stack可以通用操作，但运行速度会大大降低。
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveAllAdjacentDuplicatesInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "abbaca";
            Console.WriteLine(RemoveDuplicates1(S));
        }
        static string RemoveDuplicates1(string S)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < S.Length; i++)
            {
                if(res.Length != 0 && res[res.Length - 1] == S[i])
                    res.Remove(res.Length - 1, 1);
                else
                    res.Append(S[i]);
            }
            return res.ToString();
        }
        static string RemoveDuplicates2(string S)
        {
            Stack<char> container = new Stack<char>();
            for (int i = 0; i < S.Length; i++)
            {
                if (container.Count != 0 && container.Peek() == S[i])
                    container.Pop();
                else
                    container.Push(S[i]);
            }
            string res = "";
            while (container.Count != 0)
                res = container.Pop() + res;
            return res;
        }
    }
}
