using System;
using System.Linq;

namespace DividePlayersIntoTeamsOfEqualSkill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] skill = { 3, 2, 5, 1, 3, 4 };
            Console.WriteLine(DividePlayers(skill));
        }

        public static long DividePlayers(int[] skill)
        {
            var sum = skill.Sum();
            if (sum % (skill.Length / 2) != 0)
                return -1;
            var avg = sum / (skill.Length / 2);
            Array.Sort(skill);
            long res = 0;
            for (int i = 0; i < skill.Length / 2; i++)
            {
                if (skill[i] + skill[^(i + 1)] != avg)
                    return -1;
                res += skill[i] * skill[^(i + 1)];
            }
            return res;
        }
    }
}
