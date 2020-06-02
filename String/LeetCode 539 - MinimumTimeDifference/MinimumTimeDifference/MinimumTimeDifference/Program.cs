//思路为先将所有时间转换成分钟形式的整数，然后排序，找出最小的时间间隔。
//创建minutes列表接收分钟形式的时间点，遍历timePoints，将小时与分钟分别转化成数字格式(由于给定时间Wie标准格式，可以利用Substring函数)，再将计算好的分钟格式的时间存入minutes。
//对minutes排序。创建最小时间间隔minMins，初始值设为第一个和最后一个时间点的时间间隔，需要注意有进位问题。
//遍历minutes，如果发现更小的时间间隔，则替换minMins。最后返回minMIns。
using System;
using System.Collections.Generic;

namespace MinimumTimeDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] timePoints = { "23:59", "00:00" };
            Console.WriteLine(FindMinDifference(timePoints));
        }
        static int FindMinDifference(IList<string> timePoints)
        {
            List<int> minutes = new List<int>();
            foreach (var time in timePoints)
            {
                int hours = int.Parse(time.Substring(0, 2));
                int mins = int.Parse(time.Substring(3, 2));
                minutes.Add(hours * 60 + mins);
            }
            minutes.Sort();
            int minMins = 60 * 24 - minutes[minutes.Count - 1] + minutes[0];
            for (int i = 1; i < minutes.Count; i++)
                minMins = Math.Min(minMins, minutes[i] - minutes[i - 1]);
            return minMins;
        }
    }
}
