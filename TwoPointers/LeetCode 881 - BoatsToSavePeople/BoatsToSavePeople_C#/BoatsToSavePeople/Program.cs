using System;

namespace BoatsToSavePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] people = { 1, 5, 3 };
            int limit = 5;
            Console.WriteLine(NumRescueBoats(people, limit));
        }
        static int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int li = 0, hi = people.Length - 1, res = 0;
            while (li < hi)
            {
                if (people[li] + people[hi] <= limit)
                    li++;
                res++;
                hi--;
            }
            return li > hi ? res : res + 1;
        }
    }
}
