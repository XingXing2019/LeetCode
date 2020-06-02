using System;
using System.Text;

namespace NumberOfSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder("101");
            Console.WriteLine(PlusOne(str));
        }
        public int NumSteps(string s)
        {
            int step = 0;
            var str = new StringBuilder(s);
            while (str.Length != 1)
            {
                if (str[^1] == '1')
                    PlusOne(str);
                else
                    str.Remove(str.Length - 1, 1);
                step++;
            }
            return step;
        }

        static void PlusOne(StringBuilder str)
        {
            int car = 0, cur = 0;
            str[^1] = '2';
            for (int i = str.Length - 1; i >= 0; i--)
            {
                cur = (str[i] - '0' + car) % 2;
                car = (str[i] - '0' + car) / 2;
                str[i] = cur == 0 ? '0' : '1';
            }
            if (car != 0)
                str.Insert(0, '1');
        }
    }
}
