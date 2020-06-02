//使用公式法计算最小的时间间隔。
//创建一个长度为26的数组taskFreq记录每个字符出现的频率。遍历tasks数组，记录每个字符出现的频率，记入taskFreq。为taskFreq排序并翻转。
//创建mostFreqCount记录一共有几个字符出现了最高频率。创建maxFreq代表最高频字符的频率，将其设为taskFreq第一个元素。
//遍历taskFreq找出最高频字符的个数。
//假设A和B同为最高频字符，他们都出现了3次，任务间隔n为4。最后任务的格式应为 AB...AB...AB。格式中小数点位置应由其他字符或者休眠代替。
//通过总结，最后计算最少的任务次数minInterval的公式应为 minInterval = (n + 1) * (maxFreq - 1) + mostFreqCount。
//(n + 1)代表每个任务块(例如AB...)的长度，(maxFreq - 1)代表任务块的个数，mostFreqCount代表在要将最高频字符的个数(例如AB)接到最后一个任务块结尾。
//最后返回minInterval和tasks.Length中较大的值。
using System;

namespace TaskScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;
            Console.WriteLine(LeastInterval(tasks, n));
        }
        static int LeastInterval(char[] tasks, int n)
        {
            int[] taskFreq = new int[26];
            for (int i = 0; i < tasks.Length; i++)
                taskFreq[tasks[i] - 'A']++;
            Array.Sort(taskFreq);
            Array.Reverse(taskFreq);
            int mostFreqCount = 0;
            int maxFreq = taskFreq[0];
            for (int i = 0; i < taskFreq.Length; i++)
            {
                if (taskFreq[i] == maxFreq)
                    mostFreqCount++;
                else
                    break;
            }
            int minInterval = (n + 1) * (maxFreq - 1) + mostFreqCount;
            return Math.Max(minInterval, tasks.Length);
        }
    }
}
