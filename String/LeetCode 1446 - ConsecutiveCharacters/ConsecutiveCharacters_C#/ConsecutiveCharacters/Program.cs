using System;

namespace ConsecutiveCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxPower(string s)
        {
            int power = 0, maxPower = int.MinValue;
            char letter = '0';
            foreach (var c in s)
            {
                if (letter == c)
                    power++;
                else
                {
                    letter = c;
                    maxPower = Math.Max(maxPower, power);
                    power = 1;
                }
            }
            maxPower = Math.Max(maxPower, power);
            return maxPower;
        }
    }
}
