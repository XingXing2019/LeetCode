//创建CheckMatch方法，检查字符串p是否能通过添加小写字母与q匹配。创建pointer指针指向q首字母，创建found代表p中字母已在q中找到的个数。
//遍历p中的每个字母，用pointer指针在q中前进寻找相同的字母，找到后则令found加一，并停止遍历，并将pointer再前移一位。
//需要注意，如果pointer指针指向的为大写字母，则应在其与当前遍历到p中字母不相同的时候返回false。因为此时证明q中包含p中没有的大写字母，则一定不符合条件。
//遍历p结束后如果没有在q中找到所有字母(found小于p长度)，则返回false。否则继续判断q中时候还有大写字母，如果有返回false。以上过程结束后如果仍未返回false，则返回true。
//在主方法中对每个单词调用CheckMatch方法，将结果记入res，并返回。
using System;
using System.Collections.Generic;

namespace CamelcaseMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string q = "FooBar";
            string p = "FoBaT";
            Console.WriteLine(CheckMatch(q, p));
        }
        static IList<bool> CamelMatch(string[] queries, string pattern)
        {
            bool[] res = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                res[i] = CheckMatch(queries[i], pattern);
            return res;
        }
        static bool CheckMatch(string q, string p)
        {
            int pointer = 0;
            int found = 0;
            for (int i = 0; i < p.Length; i++)
            {
                while (pointer < q.Length)
                {
                    if (q[pointer] >= 65 && q[pointer] <= 90)
                    {
                        if (q[pointer] == p[i])
                        {
                            found++;
                            break;
                        }
                        else
                            return false;
                    }
                    else if (q[pointer] >= 97 && q[pointer] <= 122)
                    {
                        if (q[pointer] == p[i])
                        {
                            found++;
                            break;
                        }
                    }
                    pointer++;
                }
                pointer++;
            }
            if (found < p.Length)
                return false;
            while (pointer < q.Length)
            {
                if (q[pointer] >= 65 && q[pointer] <= 90)
                    return false;
                pointer++;
            }
            return true;
        }
    }
}
