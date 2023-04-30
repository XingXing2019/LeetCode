using System;

namespace DetermineTheWinnerOfABowlingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int IsWinner(int[] player1, int[] player2)
        {
            int score1 = GetScore(player1), score2 = GetScore(player2);
            if (score1 == score2)
                return 0;
            return score1 > score2 ? 1 : 2;
        }

        public int GetScore(int[] player)
        {
            var res = 0;
            for (int i = 0; i < player.Length; i++)
                res += i >= 2 && player[i - 2] == 10 || i >= 1 && player[i - 1] == 10 ? player[i] * 2 : player[i];
            return res;
        }
    }
}
