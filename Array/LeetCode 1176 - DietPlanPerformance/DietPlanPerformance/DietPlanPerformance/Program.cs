using System;
using System.Collections.Generic;
using System.Linq;

namespace DietPlanPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] calories = { 1, 2, 3, 4, 5 };
            int k = 1, lower = 3, high = 3;
            Console.WriteLine(DietPlanPerformance(calories, k, lower, high));
        }
        static int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {
            int res = 0, li = 0, hi = k - 1;
            int calory = calories[..k].Sum();
            if (calory > upper)
                res++;
            else if (calory < lower)
                res--;
            while (hi < calories.Length)
            {
                calory -= calories[li++];
                hi++;
                if(hi >= calories.Length) break;
                calory += calories[hi];
                if (calory > upper)
                    res++;
                else if (calory < lower)
                    res--;
            }
            return res;
        }
    }
}
