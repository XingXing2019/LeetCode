using System;

namespace ThekStrongestValuesInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {-7, 22, 17, 3};
            int k = 2;
            Console.WriteLine(GetStrongest(arr, k));
        }
        static int[] GetStrongest(int[] arr, int k)
        {
            var res = new int[k];
            Array.Sort(arr);
            int li = 0, hi = arr.Length - 1;
            int median = arr.Length % 2 == 0 ? arr[arr.Length / 2 - 1] : arr[arr.Length / 2];
            int point = 0;
            while (point < k)
            {
                if (Math.Abs(arr[li] - median) > Math.Abs(arr[hi] - median))
                    res[point++] = arr[li++];
                else 
                    res[point++] = arr[hi--];
            }
            return res;
        }
    }
}
