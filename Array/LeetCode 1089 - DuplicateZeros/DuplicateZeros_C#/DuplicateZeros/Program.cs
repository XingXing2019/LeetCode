//创建列表record记录数字，遍历arr将当前数字记入record，如果当前数字为0，则额外在记录一个0.
//遍历arr，将每一位上的数字更新为record中相应的数字。
using System;
using System.Collections.Generic;

namespace DuplicateZeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void DuplicateZeros(int[] arr)
        {
            List<int> record = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                record.Add(arr[i]);
                if (arr[i] == 0)
                    record.Add(0);
            }
            for (int i = 0; i < arr.Length; i++)
                arr[i] = record[i];
        }
    }
}
