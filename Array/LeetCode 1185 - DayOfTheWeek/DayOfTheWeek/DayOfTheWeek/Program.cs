//计算到给定日期一共有多少天，再用总天数对7取模，获得对应的日期。取模结果0代表Saturday。
//需特殊注意闰年的情况。闰年算法为当前年份除以4。
//需注意如果当年年份是闰年，则要判断月份是否在三月之前，如果在要将总天数减一。因为闰年是二月的最后一天比其他年份多出一天。
using System;
using System.Collections.Generic;

namespace DayOfTheWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 15;
            int month = 8;
            int year = 1993;
            Console.WriteLine(DayOfTheWeek(day, month, year));
        }
        static string DayOfTheWeek(int day, int month, int year)
        {
            var days = new Dictionary<int, string>() { { 0, "Saturday" }, { 1, "Sunday" }, { 2, "Monday" }, { 3, "Tuesday" }, { 4, "Wednesday" }, { 5, "Thursday" }, { 6, "Friday" } };
            int loopYear = year / 4;
            int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] daySum = new int[13];
            daySum[0] = 0;
            for (int i = 1; i < daySum.Length; i++)
                daySum[i] = daySum[i - 1] + monthDays[i - 1];
            int totalDays = (year - 1) * 365 + loopYear + daySum[month - 1] + day;
            if (year % 4 == 0 && month < 3)
                totalDays--;
            return days[totalDays % 7];
        }
    }
}
