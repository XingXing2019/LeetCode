//贪心算法，能达到A中数字都一样，则翻转后A中的数字一定是原先A中出现最多的数字，或者B中出现最多的数字。
//获得A中和B中出现次数最多的数字，将他们分别存入两个列表。需注意，A或B中出现最多的数字可能不止一个。
//遍历A数组，遇到当前数字不是出现最多的数字，则检查B中相应位置是否为该数字，如果是，则计数加一，否则终止遍历，计数归零，并标记不能通过操作A达到目的。
//对B数组做同样操作。最后根据标记返回相应的结果。
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumDominoRotationsForEqualRow
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 2, 1, 1, 1, 2, 2, 2, 1, 1, 2 };
            int[] B = { 1, 1, 2, 1, 1, 1, 1, 2, 1, 1 };
            Console.WriteLine(MinDominoRotations(A, B));
        }
        static int MinDominoRotations(int[] A, int[] B)
        {
            int[] recordA = new int[7];
            int[] recordB = new int[7];
            for (int i = 0; i < A.Length; i++)
            {
                recordA[A[i]]++;
                recordB[B[i]]++;
            }
            int maxA = 0;
            int maxB = 0;
            for (int i = 0; i < recordA.Length; i++)
            {
                maxA = Math.Max(maxA, recordA[i]);
                maxB = Math.Max(maxB, recordB[i]);
            }
            var numsA = new List<int>();
            var numsB = new List<int>();
            for (int i = 0; i < recordA.Length; i++)
            {
                if (recordA[i] == maxA)
                    numsA.Add(i);
                if (recordB[i] == maxB)
                    numsB.Add(i);
            }
            int countA = 0;
            bool failA = false;
            for (int i = 0; i < numsA.Count; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j] != numsA[i])
                    {
                        if (B[j] == numsA[i])
                            countA++;
                        else
                        {
                            countA = 0;
                            failA = true;
                            break;
                        }
                    }
                }
            }
            int countB = 0;
            bool failB = false;
            for (int i = 0; i < numsB.Count; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (B[j] != numsB[i])
                    {
                        if (A[j] == numsB[i])
                            countB++;
                        else
                        {
                            countB = 0;
                            failB = true;
                            break;
                        }
                    }
                }
            }
            if (failA && failB)
                return -1;
            else if (failA)
                return countB;
            else if (failB)
                return countA;
            else
                return Math.Min(countA, countB);
        }
    }
}
