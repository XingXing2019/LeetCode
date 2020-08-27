using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignALeaderboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Leaderboard
    {
        private Dictionary<int, int> record;
        public Leaderboard()
        {
            record = new Dictionary<int, int>();
        }

        public void AddScore(int playerId, int score)
        {
            if (!record.ContainsKey(playerId))
                record[playerId] = 0;
            record[playerId] += score;
        }

        public int Top(int K)
        {
            int res = 0;
            var scores = record.OrderByDescending(x => x.Value).Select(x => x.Value).ToList();
            for (int i = 0; i < K; i++)
                res += scores[i];
            return res;
        }

        public void Reset(int playerId)
        {
            record.Remove(playerId);
        }
    }
}
