//创建record数组长度为nums.Length + 1，用于记录每个数字出现的次数。
//遍历nums，将对应数字在record中的记录加一。
//遍历record，返回次数为2和0的数字。
using System;

namespace SetMismatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] FindErrorNums(int[] nums)
        {
            int[] record = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
                record[nums[i]]++;
            int[] res = new int[2];
            for (int i = 1; i < record.Length; i++)
            {
                if (record[i] == 0)
                    res[1] = i;
                else if (record[i] == 2)
                    res[0] = i;
            }
            return res;
        }
    }
}
