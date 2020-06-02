//统计A和B中1的位置，分别存入列表oneInA和oneInB。这里有一个技巧是不用存位置坐标，存入r * 100 + c。
//创建一个字典记录位置差相同坐标的个数。
//遍历oneInA，将每一个位置坐标与oneInB的每一个坐标的差和相同差的个数存入字典。
//最后返回最大的相同差的个数。如果使用Linq则需要特殊处理字典为空的情况。
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageOverlap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] A = new int[1][];
            A[0] = new int[1] { 0 };

            int[][] B = new int[3][];
            B[0] = new int[1] { 0 };

            Console.WriteLine(LargestOverlap(A, B));
        }
        static int LargestOverlap(int[][] A, int[][] B)
        {
            List<int> oneInA = new List<int>();
            List<int> oneInB = new List<int>();
            for (int r = 0; r < A.Length; r++)
            {
                for (int c = 0; c < A[0].Length; c++)
                {
                    if (A[r][c] == 1)
                        oneInA.Add(r * 100 + c);
                    if (B[r][c] == 1)
                        oneInB.Add(r * 100 + c);
                }
            }
            var dict = new Dictionary<int, int>();            
            for (int i = 0; i < oneInA.Count; i++)
            {
                for (int j = 0; j < oneInB.Count; j++)
                {
                    int tem = oneInA[i] - oneInB[j];
                    if (!dict.ContainsKey(tem))
                        dict[tem] = 1;
                    else
                        dict[tem]++;
                }
            }
            if (dict.Count == 0)
                return 0;
            return dict.Max(r => r.Value);
        }
    }
}
