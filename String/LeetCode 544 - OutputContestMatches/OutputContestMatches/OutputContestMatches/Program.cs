using System;

namespace OutputContestMatches
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string FindContestMatch(int n)
        {
            var teams = new string[n];
            for (int i = 0; i < teams.Length; i++)
                teams[i] = (i + 1).ToString();
            while (n > 1)
            {
                for (int i = 0; i < n / 2; i++)
                    teams[i] = $"({teams[i]},{teams[n - 1 - i]})";
                n /= 2;
            }
            return teams[0];
        }
    }
}
