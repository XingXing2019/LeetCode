using System;
using System.Collections.Generic;

namespace RankTransformOfAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 100, 100, 100 };
            Console.WriteLine(ArrayRankTransform(arr));
        }
        static int[] ArrayRankTransform(int[] arr)
        {
            var dict = new Dictionary<int, List<int>>();
            var list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]] = new List<int> { i };
                    list.Add(arr[i]);
                }                    
                else
                    dict[arr[i]].Add(i);
            }
            int rank = 1;
            list.Sort();
            foreach (var num in list)
            {
                for (int i = 0; i < dict[num].Count; i++)
                    arr[dict[num][i]] = rank;
                rank++;
            }
            return arr;
        }
    }
}
