using System;

namespace RepeatedStringMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "abcd";
            string B = "cdabcdab";
            Console.WriteLine(RepeatedStringMatch(A, B));
        }
        static int RepeatedStringMatch(string A, string B)
        {
            string tem = A;
            int times = 1;
            while (tem.Length < B.Length)
            {
                times++;
                tem += A;
            }
            if (tem.Contains(B))
                return times;
            else
            {
                times++;
                tem += A;
                if (tem.Contains(B))
                    return times;
                else
                    return -1;
            }
        }
    }
}
