using System;
using System.Linq;

namespace BuddyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "aaa";
            string B = "aaa";
            Console.WriteLine(BuddyStrings(A, B));
        }
        static bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length)
                return false;            
            var record = new int[26];
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                    count++;
                record[A[i] - 'a']++;
            }
            bool flag = record.Any(letter => letter >= 2);
            for (int i = 0; i < B.Length; i++)
            {
                record[B[i] - 'a']--;
                if (record[B[i] - 'a'] < 0)
                    return false;
            }
            return count == 2 || count == 0 && flag;
        }
    }
}
