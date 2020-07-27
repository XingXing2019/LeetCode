using System;

namespace BulbSwitcherIV
{
    class Program
    {
        static void Main(string[] args)
        {
            var target = "000";
            Console.WriteLine(MinFlips(target));
        }
        static int MinFlips(string target)
        {
            var res = 0;
            var state = '0';
            foreach (var letter in target)
            {
                if (state == '0')
                {
                    if (letter == '1')
                    {
                        res++;
                        state = '1';
                    }
                }
                else if (letter == '0')
                {
                    res++;
                    state = '0';
                }
            }
            return res;
        }
    }
}
