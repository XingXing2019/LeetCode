//按照要求统计数字，但是中位数有可能是两个不同数的平均值，要特殊讨论。
using System;

namespace StatisticsFromALargeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static double[] SampleStats(int[] count)
        {
            double[] res = new double[5];
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] != 0)
                {
                    res[0] = i;
                    break;
                }
            }
            for (int i = count.Length-1; i >= 0; i--)
            {
                if (count[i] != 0)
                {
                    res[1] = i;
                    break;
                }
            }
            double sum = 0;
            int totalCount = 0;
            int mode = count[0];
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] != 0)
                {
                    sum += i * count[i];
                    totalCount += count[i];
                    mode = Math.Max(mode, count[i]);
                }
            }
            res[2] = sum / totalCount;
            res[3] = FindMedian(totalCount, count);
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] == mode)
                {
                    res[4] = i;
                    break;
                }
            }
            return res;
        }

        static double FindMedian(int totalCount, int[] count)
        {
            int kthNum = totalCount / 2;
            double res = 0;
            if (totalCount % 2 == 0)
            {
                int tem = 0;
                for (int i = 0; i < count.Length; i++)
                {
                    tem += count[i];
                    if (tem == kthNum)
                        return (double) (i * 2 + 1) / 2;
                    else if(tem > kthNum)
                        return i;
                }
            }
            else
            {
                kthNum++;
                int tem = 0;
                for (int i = 0; i < count.Length; i++)
                {
                    tem += count[i];
                    if (tem >= kthNum)
                        return i;
                }
            }
            return res;
        }
    }
}
