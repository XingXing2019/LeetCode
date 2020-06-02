//用一个列表实现栈，然后按要求将数字存入列表，在计算列表中数字和。
using System;
using System.Collections.Generic;

namespace BaseballGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ops = { "5", "-2", "4", "C", "D", "9", "+", "+" };
            Console.WriteLine(CalPoints(ops));
        }
        static int CalPoints(string[] ops)
        {
            List<int> record = new List<int>();
            foreach (var op in ops)
            {
                int len = record.Count;
                if (op == "+")
                    record.Add(record[len - 1] + record[len - 2]);
                else if (op == "D")
                    record.Add((record[len - 1] * 2));
                else if (op == "C")
                    record.RemoveAt(len - 1);
                else
                    record.Add(int.Parse(op));
            }
            int res = 0;
            foreach (var num in record)
                res += num;
            return res;
        }
    }
}
