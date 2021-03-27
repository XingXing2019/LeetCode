//分别统计两个数组的总和totalA和totalB，然后计算出需要交换数字的差值。
//创建一个字典辅助寻找符合条件的数字。在统计A总和时，顺便将A中的数字计入字典。 
//遍历B，在字典中寻找能满足条件的数字对，计入结果。需注意判断totalA和totalB那个值更大，要分别讨论。
using System;
using System.Collections.Generic;

namespace FairCandySwap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 28, 30, 31, 26, 27, 1, 8, 16, 12, 10, 35, 23, 9, 33, 9, 15, 11, 34, 26, 1 };
            int[] B = { 71, 18, 27, 11, 60, 56, 26, 100, 40, 14 };
            Console.WriteLine(FairCandySwap(A, B));
        }
        static int[] FairCandySwap(int[] A, int[] B)
        {
            int totalA = 0, totalB = 0;
            var dict = new Dictionary<int, int>();
            foreach (var num in A)
            {
                totalA += num;
                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                    dict[num]++;
            }
            foreach (var num in B)
                totalB += num;
            int gap = Math.Abs(totalA - (totalA + totalB) / 2);
            int[] res = new int[2];
            if (totalA > totalB)
            {
                foreach (var num in B)
                {
                    if (dict.ContainsKey(gap + num))
                    {
                        res[0] = gap + num;
                        res[1] = num;
                    }
                }
            }
            else
            {
                foreach (var num in B)
                {
                    if (dict.ContainsKey(num - gap))
                    {
                        res[0] = num - gap;
                        res[1] = num;
                    }
                }
            }
            return res;
        }

    }
}
