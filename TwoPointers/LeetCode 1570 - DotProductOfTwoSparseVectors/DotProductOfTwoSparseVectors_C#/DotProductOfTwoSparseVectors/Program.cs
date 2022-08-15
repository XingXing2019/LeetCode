using System;
using System.Collections.Generic;

namespace DotProductOfTwoSparseVectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var vec1 = new SparseVector(new[] {1, 0, 0, 2, 3});
            var vec2 = new SparseVector(new[] {0, 3, 0, 4, 0});
            Console.WriteLine(vec1.DotProduct(vec2));
        }
    }
    public class SparseVector
    {
        public Dictionary<int, int> nonZero;
        public SparseVector(int[] nums)
        {
            nonZero = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                    nonZero[i] = nums[i];
            }
        }

        public int DotProduct(SparseVector vec)
        {
            var res = 0;
            foreach (var kv in nonZero)
            {
                if (vec.nonZero.ContainsKey(kv.Key))
                    res += kv.Value * vec.nonZero[kv.Key];
            }
            return res;
        }
    }
}
