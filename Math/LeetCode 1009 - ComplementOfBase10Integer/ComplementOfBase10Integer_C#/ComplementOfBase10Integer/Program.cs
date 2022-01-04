//将N转化字符串型二进制，按位取反加入res。
using System;

namespace ComplementOfBase10Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            Console.WriteLine(BitwiseComplement(N));
        }
        static int BitwiseComplement(int N)
        {
            string binaryN = GetBinary(N);
            int res = binaryN[0] == '0' ? 1 : 0;
            for (int i = 1; i < binaryN.Length; i++)
            {
                if (binaryN[i] == '1')
                    res = res * 2;
                else
                    res = res * 2 + 1;
            }
            return res; 
        }
        static string GetBinary(int N)
        {
            if (N == 0)
                return "0";
            string binaryN = "";
            while (N != 0)
            {
                binaryN = N % 2 + binaryN;
                N /= 2;
            }
            return binaryN;
        }
    }
}
