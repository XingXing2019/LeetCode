using System;
using System.Linq;

namespace RichestCustomerWealth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaximumWealth(int[][] accounts)
        {
            var res = 0;
            foreach (var account in accounts)
                res = Math.Max(res, account.Sum());
            return res;
        }
    }
}
