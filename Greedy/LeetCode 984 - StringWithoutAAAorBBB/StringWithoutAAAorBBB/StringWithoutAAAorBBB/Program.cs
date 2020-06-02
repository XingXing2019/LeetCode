using System;

namespace StringWithoutAAAorBBB
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 4, B = 1;
            Console.WriteLine(StrWithout3a3b(A, B));
        }
        static string StrWithout3a3b(int A, int B)
        {
            if (A > B)
                return Generate(A, 'a', B, 'b');
            return Generate(B, 'b', A, 'a');
        }

        static string Generate(int A, char a, int B, char b)
        {
            var res = "";
            while (A != B && B > 0)
            {
                res += a + a.ToString() + b;
                A -= 2;
                B--;
            }
            while (A > 0)
            {
                res += a;
                A--;
                if (B > 0)
                {
                    res += b;
                    B--;
                }
            }
            return res;
        }
    }
}
