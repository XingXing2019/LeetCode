//创建两个栈letterContainer和numContainer分别存储字母和字母的个数、先将第一个字母压入letterContainer，1压入numContainer。
//从第二个字母遍历s，如果当前字母和letterContainer栈顶相同，则令其在numContainer的个数加一。然后当numContainer栈顶的个数等于k时，将letterContainer和numContainer栈顶弹出。
//遍历结束后将letterContainer中剩下的字母乘以其在numContainer中的个数，并加入res。

//第二种方法是将a-z每个字母的k倍作为pattern存入一个长度为26的数组。遍历s，将每个字母加入StringBuilder型的res，每次检查其最后k个字母是否是之前创建的pattern，如果是则将最后k个字母去掉。
//但是这种方法提交会超时。
using System;
using System.Text;
using System.Collections.Generic;

namespace RemoveAllAdjacentDuplicatesInStringII
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "deeedbbcccbdaa";
            int k = 3;
            Console.WriteLine(RemoveDuplicates1(s, k));
        }
        static string RemoveDuplicates1(string s, int k)
        {
            Stack<char> letterContainer = new Stack<char>();
            Stack<int> numContainer = new Stack<int>();
            letterContainer.Push(s[0]);
            numContainer.Push(1);
            for (int i = 1; i < s.Length; i++)
            {
                if (letterContainer.Count != 0 && s[i] == letterContainer.Peek())
                {
                    int num = numContainer.Pop() + 1;
                    numContainer.Push(num);
                }
                else
                {
                    letterContainer.Push(s[i]);
                    numContainer.Push(1);
                }
                if(numContainer.Count != 0 && numContainer.Peek() == k)
                {
                    letterContainer.Pop();
                    numContainer.Pop();
                }
            }
            string res = "";
            while (letterContainer.Count != 0)
            {
                int num = numContainer.Pop();
                char letter = letterContainer.Pop();
                for (int i = 0; i < num; i++)
                    res = letter + res;
            }
            return res;
        }
        static string RemoveDuplicates2(string s, int k)
        {
            StringBuilder res = new StringBuilder();
            string[] patterns = new string[26];
            for (int i = 0; i < patterns.Length; i++)
            {
                string tem = "";
                for (int j = 0; j < k; j++)
                    tem += (char)(i + 97);
                patterns[i] = tem;
            }
            for (int i = 0; i < s.Length; i++)
            {
                res.Append(s[i]);
                int len = res.Length;
                if (len >= k && res.ToString().Substring(len - k) == patterns[res[len - 1] - 'a'])
                    res.Remove(res.Length - k, k);
            }
            return res.ToString();
        }
    }
}
