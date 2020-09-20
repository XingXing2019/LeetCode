using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int low = 10;
            int high = 1000000000;
            Console.WriteLine(SequentialDigits_Traversal(low, high));
        }
        static IList<int> SequentialDigits_BackTracking(int low, int high)
        {           
            List<int> record = new List<int>();
            for (int i = 1; i <= 9; i++)
                GetNums(low, high, record, i);
            record.Sort();
            return record;
        }
        static void GetNums(int low, int high, List<int> record, int num)
        {
            if (num > high)
                return;
            if (num >= low)
                record.Add(num);
            if (num % 10 < 9)
                GetNums(low, high, record, num * 10 + num % 10 + 1);
        }

        static IList<int> SequentialDigits_Traversal(int low, int high)
        {
            var res = new List<int>();
            for (int i = 1; i < 9; i++)
            {
                int num = i;
                int pre = i;
                while (num <= high && pre < 10)
                {
                    if (num >= low && num <= high)
                        res.Add(num);
                    num = num * 10 + pre + 1;
                    pre++;
                }
            }
            res.Sort();
            return res;
        }
    }
}
