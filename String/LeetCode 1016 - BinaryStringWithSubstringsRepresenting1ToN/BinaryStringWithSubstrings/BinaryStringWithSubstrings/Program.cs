//创建方法得到字符串型二进制数。
//从大到小遍历N中的数字，如发现不是S的子串则返回false。否则遍历结束后返回true。
//技巧为只需遍历到N的一半，因为比N一半小的数字一定是比N一半大的数字的子串。
using System;
using System.Text;

namespace BinaryStringWithSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "100011110111101001001111111010111011000101000100011001000000000000001101000001111001000010011111110101100000101000100011100111100101000000010111011001000111011011010101011101010111011000100010001011001011110101010011000101000100101010110111110001101100001110011001110001111010100111000001101101110011";
            int N = 15;
            Console.WriteLine(QueryString(S, N));
        }
        static bool QueryString(string S, int N)
        {
            for (int i = N; i > N / 2; i--)
                if (!S.Contains(GetBinary(i)))
                    return false; 
            return true;
        }
        static string GetBinary(int N)
        {
            string res = "";
            while (N != 0)
            {
                res = N % 2 + res;
                N /= 2;
            }
            return res;
        }
    }
}
