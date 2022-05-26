using System;

namespace MinimumCostTreeFromLeafValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 6, 2, 4, 5, 6 };
            Console.WriteLine(MctFromLeafValues(arr));
        }

        public static int MctFromLeafValues(int[] arr)
        {
            var res = 0;
            DFS(arr, ref res);
            return res;
        }

        public static void DFS(int[] arr, ref int sum)
        {
            if (arr.Length == 1) return;
            int index = 0, product = int.MaxValue;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (product <= arr[i] * arr[i + 1]) continue;
                index = i;
                product = arr[i] * arr[i + 1];
            }
            sum += product;
            var newArr = new int[arr.Length - 1];
            var point = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[point++] = i == index ? Math.Max(arr[i], arr[i + 1]) : arr[i];
                if (i == index) i++;
            }
            DFS(newArr, ref sum);
        }
    }
}
