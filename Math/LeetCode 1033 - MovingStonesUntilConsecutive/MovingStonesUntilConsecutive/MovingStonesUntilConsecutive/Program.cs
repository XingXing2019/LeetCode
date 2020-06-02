using System;

namespace MovingStonesUntilConsecutive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] NumMovesStones(int a, int b, int c)
        {
            int[] tem = {a, b, c};
            Array.Sort(tem);
            var res = new int[2];
            if (tem[0] + 1 == tem[1] && tem[1] + 1 == tem[2])
                res[0] = 0;
            else if (tem[1] - tem[0] <= 2 || tem[2] - tem[1] <= 2)
                res[0] = 1;
            else
                res[0] = 2;
            res[1] = tem[2] - tem[0] - 2;
            return res;
        }
    }
}
