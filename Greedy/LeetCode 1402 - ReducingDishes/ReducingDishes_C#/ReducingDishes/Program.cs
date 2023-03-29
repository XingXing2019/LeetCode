using System;

namespace ReducingDishes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxSatisfaction(int[] satisfaction)
        {
            Array.Sort(satisfaction);
            int maxSatisfaction = 0;
            int singleSatisfaction = 0;
            for (int i = satisfaction.Length - 1; i >= 0; i--)
            {
                singleSatisfaction += satisfaction[i];
                if(singleSatisfaction > 0)
                    maxSatisfaction += singleSatisfaction;
                else
                    break;
            }

            return maxSatisfaction;
        }
    }
}
