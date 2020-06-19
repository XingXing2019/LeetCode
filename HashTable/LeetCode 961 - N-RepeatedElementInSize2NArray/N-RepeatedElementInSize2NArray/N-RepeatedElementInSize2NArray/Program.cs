//创建record字典记录数字，遍历A，将为在record中出现的数字记录入record，如果record中的数字再次出现，在将其即为res。
using System;
using System.Collections.Generic;

namespace N_RepeatedElementInSize2NArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int RepeatedNTimes(int[] A)
        {
            var record = new HashSet<int>();
            foreach (var num in A)
                if (!record.Add(num))
                    return num;
            return -1;
        }
    }
}
