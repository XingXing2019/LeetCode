using System;
using System.Collections.Generic;
using System.Text;

namespace SequentialDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int low = 1000;
            int high = 13000;
            Console.WriteLine(SequentialDigits_Traversal(low, high));
        }
        static IList<int> SequentialDigits_BackTracking(int low, int high)
        {           
            List<int> record = new List<int>();
            List<int> candidates = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var c in candidates)
                GetNums(low, high, record, c);
            record.Sort();
            return record;
        }
        static void GetNums(int low, int high, List<int> record, int num)
        {
            int tem = num % 10 + 1;
            if (tem > 9)
                return;
            num = num * 10 + tem;
            if (num >= low && num <= high)
                record.Add(num);
            if (num > high)
                return;
            GetNums(low, high, record, num);
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
