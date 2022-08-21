using System;

namespace MinimumHoursOfTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = 9, initialExperience = 7;
            int[] energy = { 5, 4, 10 };
            int[] experience = { 7, 8, 9 };
            Console.WriteLine(MinNumberOfHours(initialEnergy, initialExperience, energy, experience));
        }

        public static int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
        {
            int lastEnergy = 1, temp = initialExperience;
            for (int i = energy.Length - 1; i >= 0; i--)
            {
                lastEnergy += energy[i];
                energy[i] = lastEnergy;
            }
            while (!Enough(temp, experience))
                temp++;
            return Math.Max(0, energy[0] - initialEnergy) + temp - initialExperience;
        }

        public static bool Enough(int initialExperience, int[] experience)
        {
            for (int i = 0; i < experience.Length; i++)
            {
                if (initialExperience <= experience[i])
                    return false;
                initialExperience += experience[i];
            }
            return true;
        }
    }
}
