//创建一个列表数组numRecord，长度为20001。用于记录每个数字对应的位置集合。
//遍历values，将当前数字在labels中的位置记录入numRecord的对应数字处。
//创建一个长度为20001的数组labelRecord，用于记录在每个位置上有多少数字被使用过。
//从后向前遍历numRecord(利用贪心算法总是试图取到最大值)，当num_wanted等于0时终止。如果当前数字对应的列表不为空，证明values中有当前数字。
//则遍历该数字对应的位置列表，如果某个位置在labelRecord中记录的次数小于use_limit，并且num_wanted还大于0时，将该数字加入res。并在labelRecord中标记一下，并令num_wanted减一。
using System;
using System.Collections.Generic;

namespace LargestValuesFromLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 9, 8, 8, 7, 6 };
            int[] lables = { 0, 0, 0, 1, 1 };
            int num_wanted = 3;
            int use_limit = 2;
            Console.WriteLine(LargestValsFromLabels(values, lables, num_wanted, use_limit));
        }
        static int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit)
        {
            List<int>[] numRecord = new List<int>[20001];
            for (int i = 0; i < values.Length; i++)
            {
                if (numRecord[values[i]] == null)
                    numRecord[values[i]] = new List<int>();
                numRecord[values[i]].Add(labels[i]);
            }
            int[] labelRecord = new int[20001];
            int res = 0;
            for (int i = numRecord.Length - 1; i >= 0 && num_wanted > 0; i--)
            {
                if(numRecord[i] != null)
                {
                    foreach (var pos in numRecord[i])
                    {
                        if(labelRecord[pos] < use_limit && num_wanted > 0)
                        {
                            res += i;
                            labelRecord[pos]++;
                            num_wanted--;
                        }
                    }
                }
            }
            return res;
        }
    }
}
