//创建Generate方法，传入一个hoursAndMinutes数组，记录所有小时和分钟的数字，也要将0加入数组，代表代表小时或者分钟的等没有亮。传入h记录当前小时的总数，m记录当前分钟的总数。k定位当前遍历的下一个index，避免重复计算已经亮过的灯。
//当num等于0时，将根据当前h和m将对应时间记入res，并返回。需注意记录的格式。
//遍历hoursAndMinutes，如果当前数字为0，则跳过该次遍历。如果当前i小于5，则要记录小时。如果当前h加上将要记录的小时数会超过11，则跳过，否则更新h。如果当前i大于等于5，则要记录分钟。如果当前m加上将要记录的分钟会超过59，则跳过，否则更新m。
//递归调用Generate，将num-1和i+1传入对应的位置。
//回溯时，要相应的更新h或m。
using System;
using System.Collections.Generic;

namespace BinaryWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 8;
            Console.WriteLine(ReadBinaryWatch(num));
    }
        static IList<string> ReadBinaryWatch(int num)
        {
            int[] hoursAndMinutes = { 0, 1, 2, 4, 8, 0, 1, 2, 4, 8, 16, 32 };
            List<string> res = new List<string>();
            int h = 0;
            int m = 0;
            Generate(num, hoursAndMinutes, res, h, m, 0);
            return res;
        }
        static void Generate(int num, int[] hoursAndMinutes, List<string> res, int h, int m, int k)
        {
            if (num == 0)
            {
                string tem = h.ToString() + ":";
                if (m < 10)
                    tem += "0" + m.ToString();
                else
                    tem += m.ToString();
                res.Add(tem);
                return;
            }
            for (int i = k; i < hoursAndMinutes.Length; i++)
            {
                if (hoursAndMinutes[i] == 0)
                    continue;
                if (i < 5)
                {
                    if (h + hoursAndMinutes[i] >= 12)
                        continue;
                    h += hoursAndMinutes[i];
                }
                else
                {
                    if (m + hoursAndMinutes[i] >= 60)
                        continue;
                    m += hoursAndMinutes[i];
                }                   
                Generate(num - 1, hoursAndMinutes, res, h, m, i + 1);
                if (i < 5)
                    h -= hoursAndMinutes[i];
                else
                    m -= hoursAndMinutes[i];
            }
        }
    }
}
