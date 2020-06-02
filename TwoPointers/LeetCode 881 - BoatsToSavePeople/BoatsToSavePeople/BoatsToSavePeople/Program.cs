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
            int boat = 0;
            int light = 0;
            int heavy = people.Length - 1;
            while (light < heavy)
            {
                if(people[light] + people[heavy] > limit)
                {
                    boat++;
                    heavy--;
                }
                else
                {
                    if (heavy - light != 1)
                    {
                        boat++;
                        light++;
                        heavy--;
                    }
                    else
                        break;
                }
            }
            return boat + 1;
        }
    }
}
