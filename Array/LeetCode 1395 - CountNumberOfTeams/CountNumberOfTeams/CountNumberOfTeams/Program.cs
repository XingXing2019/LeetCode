using System;

namespace CountNumberOfTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rating = { 1, 2, 3, 4 };
            Console.WriteLine(NumTeams(rating));
        }
        static int NumTeams(int[] rating)
        {
            var res = 0;
            var larger = new int[rating.Length];
            var smaller = new int[rating.Length];
            for (int i = 0; i < rating.Length; i++)
            {
                for (int j = i + 1; j < rating.Length; j++)
                {
                    if (rating[j] > rating[i])
                        larger[i]++;
                    else
                        smaller[i]++;
                }
            }
            for (int i = 0; i < rating.Length; i++)
            {
                for (int j = i + 1; j < rating.Length; j++)
                {
                    if (rating[j] > rating[i])
                        res += larger[j];
                    else
                        res += smaller[j];
                }
            }
            return res;
        }
    }
}
