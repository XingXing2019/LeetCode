using System;

namespace MinimumNumberOfOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string current = "02:30", correct = "04:35";
            Console.WriteLine(ConvertTime(current, cor));
        }

        public static int ConvertTime(string current, string correct)
        {
            var diff = Convert(correct) - Convert(current);
            var res = 0;
            res += diff / 60;
            diff %= 60;
            res += diff / 15;
            diff %= 15;
            res += diff / 5;
            diff %= 5;
            return res + diff;
        }

        public static int Convert(string time)
        {
            var temp = time.Split(':');
            int hour = int.Parse(temp[0]), min = int.Parse(temp[1]);
            return hour * 60 + min;
        }
    }
}
