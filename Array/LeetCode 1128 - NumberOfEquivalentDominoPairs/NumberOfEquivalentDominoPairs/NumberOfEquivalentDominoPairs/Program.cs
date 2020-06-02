//统计相等骨牌的个数。用一个int记录key。让较小的数当十位，较大的数当个位。
//然后用排列组合计算相同的骨牌俩俩结合能组成几个对子。
using System;
using System.Collections.Generic;

namespace NumberOfEquivalentDominoPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] dominoes = new int[4][];
            dominoes[0] = new int[2] { 1, 2 };
            dominoes[1] = new int[2] { 2, 1 };
            dominoes[2] = new int[2] { 3, 4 };
            dominoes[3] = new int[2] { 5, 6 };
            Console.WriteLine(NumEquivDominoPairs(dominoes));
        }
        static int NumEquivDominoPairs(int[][] dominoes)
        {           
            int count = 0;
            var record = new Dictionary<int, int>();
            foreach (var d in dominoes)
            {
                int tem = d[0] > d[1] ? d[1] * 10 + d[0] : d[0] * 10 + d[1];
                if (!record.ContainsKey(tem))
                    record[tem] = 1;
                else
                    record[tem]++;
            }
            foreach (var kv in record)
                count += GetPairs(kv.Value);
            return count;
        }

        static int GetPairs(int n)
        {
            if (n < 3)
                return n - 1;
            return n * (n - 1) / 2;
        }

    }
}
