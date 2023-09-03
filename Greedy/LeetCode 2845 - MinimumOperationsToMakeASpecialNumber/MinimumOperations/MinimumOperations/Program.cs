using System;

namespace MinimumOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = "5";
            Console.WriteLine(MinimumOperations(num));
        }

        public static int MinimumOperations(string num)
        {
            var op1 = CountOperations(num, "00");
            var op2 = CountOperations(num, "25");
            var op3 = CountOperations(num, "50");
            var op4 = CountOperations(num, "75");
            return Math.Min(op1, Math.Min(op2, Math.Min(op3, op4)));
        }

        public static int CountOperations(string num, string target)
        {
            int p1 = num.Length - 1, p2 = target.Length - 1, res = 0;
            while (p1 >= 0 && p2 >= 0)
            {
                if (num[p1] == target[p2])
                    p2--;
                else
                    res++;
                p1--;
            }
            return p2 >= 0 && target != "00" ? int.MaxValue : res;
        }
    }
}
