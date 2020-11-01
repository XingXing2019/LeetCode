using System;
using System.Collections.Generic;

namespace CheckArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {49, 18, 16};
            var pieces = new int[][]
            {
                new[] {16, 18, 49}
            };
            Console.WriteLine(CanFormArray(arr, pieces));
        }
        static bool CanFormArray(int[] arr, int[][] pieces)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
                dict[arr[i]] = i;
            foreach (var piece in pieces)
            {
                if (!dict.ContainsKey(piece[0])) return false;
                for (int i = 0; i < piece.Length; i++)
                {
                    if (dict[piece[0]] + i >= arr.Length || piece[i] != arr[dict[piece[0]] + i])
                        return false;
                }
            }
            return true;
        }
    }
}
