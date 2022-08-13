using System;
using System.Collections.Generic;

namespace SumOfTotalStrengthOfWizards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] strength = { 1, 3, 1, 2 };
            Console.WriteLine(TotalStrength(strength));
        }

        public static int TotalStrength(int[] strength)
        {
            long res = 0, mod = 1_000_000_000 + 7;
            var leftSmaller = new int[strength.Length];
            Array.Fill(leftSmaller, -1);
            var rightSmaller = new int[strength.Length];
            Array.Fill(rightSmaller, strength.Length);
            var stack = new Stack<int>();
            for (int i = 0; i < strength.Length; i++)
            {
                while (stack.Count != 0 && strength[stack.Peek()] >= strength[i])
                    rightSmaller[stack.Pop()] = i;
                if (stack.Count != 0)
                    leftSmaller[i] = stack.Peek();
                stack.Push(i);
            }
            var preSum = new long[strength.Length + 1];
            var prePrefix = new long[strength.Length + 2];
            for (int i = 0; i < strength.Length; i++)
                preSum[i + 1] = (preSum[i] + strength[i]) % mod;
            for (int i = 0; i <= strength.Length; i++)
                prePrefix[i + 1] = (prePrefix[i] + preSum[i]) % mod;
            for (int i = 0; i < strength.Length; i++)
            {
                int left = i - leftSmaller[i], right = rightSmaller[i] - i;
                var sum = (prePrefix[rightSmaller[i] + 1] - prePrefix[i + 1]) * left % mod + mod - (prePrefix[i + 1] - prePrefix[leftSmaller[i] + 1]) * right % mod;
                res = (res + sum * strength[i] % mod) % mod;
            }
            return (int)(res % mod);
        }
    }
}
