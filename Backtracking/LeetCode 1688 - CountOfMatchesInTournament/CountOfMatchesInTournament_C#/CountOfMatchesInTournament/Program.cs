using System;

namespace CountOfMatchesInTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int NumberOfMatches(int n)
        {
            var res = 0;
            while (n != 1)
            {
                res += n / 2;
                n = n % 2 == 0 ? n / 2 : n / 2 + 1;
            }
            return res;
        }

        public int NumberOfMatches_O1(int n)
        {
            return n - 1;
        }
    }
}
