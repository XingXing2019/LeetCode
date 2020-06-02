//倒着遍历一遍arr，做出相应修改即可、
using System;

namespace ReplaceElementsWithGreatest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {17, 18, 5, 4, 6, 1};
            Console.WriteLine(ReplaceElements(arr));
        }
        static int[] ReplaceElements(int[] arr)
        {
            int greatest = -1;
            for (int i = arr.Length-1; i >= 0; i--)
            {
                int tem = greatest;
                greatest = Math.Max(greatest, arr[i]);
                arr[i] = tem;
            }
            return arr;
        }
    }
}
