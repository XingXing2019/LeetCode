using System;
using System.Linq;

namespace FindKLengthSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "havefunonleetcode";
            int K = 5;
            Console.WriteLine(NumKLenSubstrNoRepeats(S, K));
        }
        static int NumKLenSubstrNoRepeats(string S, int K)
        {
            if (S.Length < K) return 0;
            var record = new int[26];
            int li = 0, hi = 0, res = 0;
            while (hi < K)
                record[S[hi++] - 'a']++;
            hi--;
            while (hi < S.Length)
            {
                if (record.All(x => x <= 1))
                    res++;
                record[S[li++] - 'a']--;
                hi++;
                if(hi == S.Length) break;
                record[S[hi] - 'a']++;
            }
            return res;
        }
    }
}
