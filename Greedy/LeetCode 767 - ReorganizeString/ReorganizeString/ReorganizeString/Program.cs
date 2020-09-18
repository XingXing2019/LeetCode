using System;
using System.Collections.Generic;
using System.Linq;

namespace ReorganizeString
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = "tndsewnllhroiajrmmwgbxeygibxxlhobmhwmcuhiiiewcluehpmzrjzffnrptwbkayjghpusewdwrbkhvjnveuo";
            Console.WriteLine(ReorganizeString(S));
        }
        static string ReorganizeString(string S)
        {
            var records = new int[26];
            foreach (var letter in S)
                records[letter - 'a']++;
            var letterCount = new List<int[]>();
            for (int i = 0; i < records.Length; i++)
            {
                if (records[i] != 0)
                    letterCount.Add(new[] {i, records[i]});
            }
            letterCount = letterCount.OrderByDescending(x => x[1]).ToList();
            if (S.Length % 2 == 0 && letterCount[0][1] > S.Length / 2 ||
                S.Length % 2 != 0 && letterCount[0][1] > S.Length / 2 + 1)
                return "";
            var letters = new char[S.Length];
            int point = 0;
            foreach (var count in letterCount)
            {
                while (count[1] != 0)
                {
                    letters[point] = (char) (count[0] + 'a');
                    point += 2;
                    count[1]--;
                    if (point >= S.Length)
                        point = 1;
                }
            }
            return String.Join("", letters);
        }
    }
}
