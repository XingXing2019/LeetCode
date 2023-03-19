using System;

namespace DistributeMoneyToMaximumChildren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money = 16, children = 10;
            Console.WriteLine(DistMoney(money, children));
        }

        public static int DistMoney(int money, int children)
        {
            money -= children;
            if (money < 0) return -1;
            int count = money / 7, left = money % 7;
            if (count > children)
                return children - 1;
            if (count == children)
                return left == 0 ? children : children - 1;
            return left == 3 && children - count == 1 ? count - 1 : count;
        }
    }
}
