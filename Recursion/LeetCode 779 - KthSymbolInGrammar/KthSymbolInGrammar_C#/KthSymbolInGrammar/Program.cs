/*
            0

        0        1

    0      1  1       0
 */

//可以将这道题想象成一颗二叉树。如果父节点是0，则左子树为0，右子树为1。如果父节点为1，则左子树为1，右子树为0。
//递归求解，边界条件为第一行，N为1，K为1时，返回0。根据第N行第K列的父节点，决定返回值。
//如果K为偶数，则根据(N-1, K / 2)位置返回结果。如果是0则返回1，否则返回0.
//如果K为奇数，则根据(N-1, (K + 1) / 2)位置返回结果，如果是0，则返回0，否则返回1.
using System;

namespace KthSymbolInGrammar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int KthGrammar(int N, int K)
        {
            if (N == 1 && K == 1) return 0;
            if (K % 2 == 0)
                return KthGrammar(N - 1, K / 2) == 0 ? 1 : 0;
            return KthGrammar(N - 1, (K + 1) / 2) == 1 ? 1 : 0;
        }
    }
}
