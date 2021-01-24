using System;

namespace LatestTimeByReplacingHiddenDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public string MaximumTime(string time)
        {
            var res = new char[5];
            res[2] = ':';
            if (time[0] != '?')
                res[0] = time[0];
            else
            {
                if (time[1] == '?' || time[1] - '0' < 4) res[0] = '2';
                else res[0] = '1';
            }
            if (time[1] != '?')
                res[1] = time[1];
            else
            {
                if (res[0] == '0' || res[0] == '1') res[1] = '9';
                else res[1] = '3';
            }
            res[3] = time[3] == '?' ? '5' : time[3];
            res[4] = time[4] == '?' ? '9' : time[4];
            return string.Join("", res);
        }
    }
}
