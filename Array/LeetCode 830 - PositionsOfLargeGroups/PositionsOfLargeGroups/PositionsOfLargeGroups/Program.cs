//遍历S,如果当前字母与其前一个字母相同，则将其加入tem，如果不同咋检查tem长度是否大于等于3，如果是，则将对应坐标加入res。最后还要更新tem为当前字母。
//遍历结束后还要检查一次最后的tem是否符合条件。
using System;
using System.Collections.Generic;

namespace PositionsOfLargeGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "aaa";
            Console.WriteLine(LargeGroupPositions(S));
        }
        static IList<IList<int>> LargeGroupPositions(string S)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (S.Length < 3)
                return res;
            string tem = S[0].ToString();
            int i = 1;
            for (; i < S.Length; i++)
            {
                if (S[i] == S[i - 1])
                    tem += S[i];
                else
                {
                    if (tem.Length >= 3)
                        res.Add(new int[] { i - tem.Length, i - 1 });
                    tem = S[i].ToString();
                }
            }
            if (tem.Length >= 3)
                res.Add(new int[] { i - tem.Length, i - 1 });
            return res;
        }
    }
}
