//记录C出现的位置在一个列表record中，然后遍历S，找出每个字母与最近的一个C的距离。用一个指针定位record，可以减少无用的遍历。
using System;
using System.Collections.Generic;

namespace ShortestDistanceToACharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "aaab";
            char C = 'b';
            Console.WriteLine(ShortestToChar(S, C));
        }
        static int[] ShortestToChar(string S, char C)
        {
            var record = new List<int>();
            for (int i = 0; i < S.Length; i++)
                if (S[i] == C)
                    record.Add(i);
            int[] res = new int[S.Length];
            int index = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (i > record[index] && index < record.Count - 1)
                    index++;
                if (index > 0)
                    res[i] = Math.Min(Math.Abs(i - record[index - 1]), Math.Abs(i - record[index]));
                else
                    res[i] = Math.Abs(i - record[index]);
            }
            return res;
        }
    }
}
