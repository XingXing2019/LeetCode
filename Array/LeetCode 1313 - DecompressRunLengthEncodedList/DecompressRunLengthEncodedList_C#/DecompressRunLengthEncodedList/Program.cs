//先统计res数组所需的长度，再用一个指针辅助将数字记录入res。
using System;

namespace DecompressRunLengthEncodedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] DecompressRLElist(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i += 2)
                count += nums[i];
            int[] res = new int[count];
            int p = 0;
            for (int i = 0; i < nums.Length; i+=2)
                for (int j = 0; j < nums[i]; j++)
                    res[p++] = nums[i + 1];
            return res;
        }
    }
}
