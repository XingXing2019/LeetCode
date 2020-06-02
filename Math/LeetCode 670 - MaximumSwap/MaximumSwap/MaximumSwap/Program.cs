//创建record列表记录每一位上的数字，创建maxNumAftPos字典记录每一位后面最大的数字。创建done代表是否完成调换。
//创建max记录每一位后面最大的数字，初始值设为-1，代表最后一位后面没有比他大的数字。创建pos代表每个数字的位置，初始值设为0，因为将数字加入record后，最后一位数字刚好会在index为0的位置。
//将num中每一位的数字从后向前加入record。同时更新max并移动，将pos和其对应的max加入maxNumAftPos。注意操作顺序。
//从record最后一个数字(相当于num的最高位)向前遍历，如果发现当前遍历到的数字所在位置，在maxNumAftPos记录中其后面有比他打的最大数字，
//则需从record第一个数字(相当于num的最低位)，向后遍历，找到这个数字后与当期i指向数字对调，将done设为true，并终止遍历。
//如果发现当前数字后面没有比他更大的数字，则跳过本轮遍历。
//如果done为true，则终止整个遍历。
//最后将record中已调整好位置的数字，拼接入res返回即可。
using System;
using System.Collections.Generic;

namespace MaximumSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1434;
            Console.WriteLine(MaximumSwap(num));
        }
        static int MaximumSwap(int num)
        {
            List<int> record = new List<int>();
            Dictionary<int, int> maxNumAftPos = new Dictionary<int, int>();
            bool done = false;
            int max = -1;
            int pos = 0;
            while (num != 0)
            {
                int tem = num % 10;
                maxNumAftPos[pos] = max;
                pos++;
                max = Math.Max(max, tem);
                record.Add(tem);
                num /= 10;
            }
            for (int i = record.Count - 1; i >= 0; i--)
            {
                if (record[i] < maxNumAftPos[i])
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (record[j] == maxNumAftPos[i])
                        {
                            int tem = record[j];
                            record[j] = record[i];
                            record[i] = tem;
                            done = true;
                            break;
                        }
                    }
                }
                else
                    continue;
                if (done)
                    break;
            }
            int res = 0;
            for (int i = record.Count - 1; i >= 0; i--)
                res = res * 10 + record[i];
            return res;
        }
    }
}
