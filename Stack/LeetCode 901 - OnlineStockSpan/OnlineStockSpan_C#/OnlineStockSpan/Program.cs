using System;
using System.Collections.Generic;

namespace OnlineStockSpan
{
    public class StockSpanner
    {
        private Stack<int[]> record;
        public StockSpanner()
        {
            record = new Stack<int[]>();
        }
        public int Next(int price)
        {
            int count = 1;
            while (record.Count != 0 && price >= record.Peek()[0])
                count += record.Pop()[1];
            record.Push(new int[]{price, count});
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var S = new StockSpanner();
            Console.WriteLine(S.Next(100));
            Console.WriteLine(S.Next(80));
            Console.WriteLine(S.Next(60));
            Console.WriteLine(S.Next(70));
            Console.WriteLine(S.Next(60));
            Console.WriteLine(S.Next(75));
            Console.WriteLine(S.Next(85));
        }
    }
}
