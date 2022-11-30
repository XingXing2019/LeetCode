//创建长度为2001的数组occurrences记录每个数字出现的次数，遍历arr，将现有数字加上1000在occurrences数的位置加一。
//创建record字典辅助检查每个数字的次数是否重复。遍历occurrences，当前次数不为零时，如果他没有在record中，则将其计入，否则返回false。遍历结束后仍未返回false，则返回true。
using System;
using System.Collections.Generic;

namespace UniqueNumberOfOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool UniqueOccurrences(int[] arr)
        {
            int[] occurrences = new int[2001];
            foreach (var num in arr)
                occurrences[num + 1000]++;
            var record = new Dictionary<int, int>();
            foreach (var o in occurrences)
            {
                if(o != 0)
                {
                    if (!record.ContainsKey(o))
                        record[o] = 1;
                    else
                        return false;
                }
            }
            return true;           
        }
    }
}
