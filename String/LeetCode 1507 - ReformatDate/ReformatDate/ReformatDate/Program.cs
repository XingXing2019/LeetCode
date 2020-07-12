//先将date按空格分隔，再按照要求处理年月日。注意如果月和日是一位数，要在前面加0.
using System;

namespace ReformatDate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string ReformatDate(string date)
        {
            var details = date.Split(" ");
            var res = new string[3];
            string[] month = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
            res[0] = details[2];
            res[1] = (Array.IndexOf(month, details[1]) + 1).ToString();
            if (res[1].Length == 1)
                res[1] = "0" + res[1];
            foreach (var c in details[0])
            {
                if (char.IsDigit(c))
                    res[2] += c;
            }
            if (res[2].Length == 1)
                res[2] = "0" + res[2];
            return string.Join('-', res);
        }
    }
}
