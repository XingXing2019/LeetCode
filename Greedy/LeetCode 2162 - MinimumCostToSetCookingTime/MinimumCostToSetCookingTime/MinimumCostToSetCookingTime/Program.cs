using System;

namespace MinimumCostToSetCookingTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startAt = 1, moveCost = 3, pushCost = 2, targetSeconds = 6008;
            Console.WriteLine(MinCostSetTime(startAt, moveCost, pushCost, targetSeconds));
        }
        public static int MinCostSetTime(int startAt, int moveCost, int pushCost, int targetSeconds)
        {
            var min = targetSeconds / 60;
            var sec = targetSeconds % 60;
            var res = int.MaxValue;
            var target = "";
            if (min < 100)
            {
                if (min != 0) target += min;
                target += target == "" ? sec.ToString() : sec.ToString("00");
                res = CalcCost(target, startAt, moveCost, pushCost);
            }
            if (sec + 60 <= 99 && min > 0)
            {
                min--;
                target = min == 0 ? (sec + 60).ToString("00") : min + (sec + 60).ToString("00");
                res = Math.Min(res, CalcCost(target, startAt, moveCost, pushCost));
            }
            return res;
        }

        public static int CalcCost(string target, int startAt, int moveCost, int pushCost)
        {
            var res = 0;
            foreach (var digit in target)
            {
                if (startAt != digit - '0')
                    res += moveCost;
                res += pushCost;
                startAt = digit - '0';
            }
            return res;
        }
    }
}
