//四年一闰，百年不闰，四百年再闰。
using System;

namespace DayOfTheYear
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = "1900-03-25";
            Console.WriteLine(DayOfYear(date));
        }
        static int DayOfYear(string date)
        {
            string[] d = date.Split("-");
            int[] days = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            if (int.Parse(d[0]) % 4 == 0 && int.Parse(d[0]) % 100 != 0 || int.Parse(d[0]) % 400 == 0)
                days[2] = 29;
            int month = int.Parse(d[1]);
            int res = 0;
            for (int i = 0; i < month; i++)
                res += days[i];
            res += int.Parse(d[2]);
            return res;
        }
    }
}
