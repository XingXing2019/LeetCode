//创建absent和late记录缺席和迟到的次数。
//遍历字符串，如果遇到A则使absent加一，并使late归零。如果遇到P则使late归零。如果遇到L，则使late加一。
//检查absent和late的次数，如果absent大于一或者late大于二，则返回false。遍历结束后返回true。
using System;

namespace StudentAttendanceRecordI
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine(CheckRecord(s));
        }
        static bool CheckRecord(string s)
        {
            int absent = 0;
            int late = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A')
                {
                    absent++;
                    late = 0;
                }
                else if (s[i] == 'P')
                    late = 0;
                else if (s[i] == 'L')
                    late++;
                if (absent > 1)
                    return false;
                if (late > 2)
                    return false;
            }
            return true;
        }
    }
}
