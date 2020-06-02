//在数组摸个范围内的最大值等于这个范围右边界的index，则证明可以将这个区域单独划分。
//创建max记录在摸个范围内的最大值，初始值设为-1、创建res记录结果。
//遍历数组，如果当前元素大于max，则替换max。如果当前max等于当前的元素的index，则证明可以在此处划分。使res加一。
//返回res。
using System;

namespace MaxChunksToMakeSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0};
            Console.WriteLine(MaxChunksToSorted(arr));
        }
        static int MaxChunksToSorted(int[] arr)
        {
            int max = -1;
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (max == i)
                    res++;
            }
            return res;
        }
    }
}
