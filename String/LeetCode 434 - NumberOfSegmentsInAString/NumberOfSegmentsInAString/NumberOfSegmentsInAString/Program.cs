//利用Split函数将字符串分割为字符串数组，返回数组中不为空元素的个数。
using System;

namespace NumberOfSegmentsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " John";
            Console.WriteLine(CountSegments(s));
        }
        static int CountSegments(string s)
        {
            var strArray = s.Split(" ");
            int count = 0;
            foreach (var word in strArray)
                if (word != "")
                    count++;
            return count;
        }
    }
}
