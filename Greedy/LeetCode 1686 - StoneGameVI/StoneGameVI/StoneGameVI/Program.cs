using System;
using System.Linq;

namespace StoneGameVI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int StoneGameVI(int[] aliceValues, int[] bobValues)
        {
            var values = new int[aliceValues.Length][];
            for (int i = 0; i < aliceValues.Length; i++)
                values[i] = new[] {aliceValues[i] + bobValues[i], aliceValues[i], bobValues[i]};
            values = values.OrderByDescending(x => x[0]).ThenByDescending(x => x[2]).ToArray();
            int alice = 0, bob = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (i % 2 == 0)
                    alice += values[i][1];
                else
                    bob += values[i][2];
            }
            return alice == bob ? 0 : alice > bob ? 1 : -1;
        }
    }
}
