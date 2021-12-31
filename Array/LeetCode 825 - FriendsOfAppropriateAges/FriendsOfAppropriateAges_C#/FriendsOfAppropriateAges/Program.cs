using System;

namespace FriendsOfAppropriateAges
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ages = { 73, 106, 39, 6, 26, 15, 30, 100, 71, 35, 46, 112, 6, 60, 110 };
            Console.WriteLine(NumFriendRequests(ages));
        }
        static int NumFriendRequests(int[] ages)
        {
            int[] numInAge = new int[121];
            int[] sumInAge = new int[121];
            for (int i = 0; i < ages.Length; i++)
                numInAge[ages[i]]++;
            for (int i = 1; i < sumInAge.Length; i++)
                sumInAge[i] = numInAge[i] + sumInAge[i - 1];
            int count = 0;
            for (int i = 15; i < sumInAge.Length; i++)
            {
                if (numInAge[i] == 0)
                    continue;
                int tem = sumInAge[i] - sumInAge[(int)(0.5 * i + 7)];
                count += tem * numInAge[i] - numInAge[i];
            }
            return count;
        }
    }
}
