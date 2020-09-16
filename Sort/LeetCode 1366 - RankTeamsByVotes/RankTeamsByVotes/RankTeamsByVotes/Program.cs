using System;
using System.Linq;

namespace RankTeamsByVotes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] votes = {"ABC", "ACB", "ABC", "ACB", "ACB"};
            Console.WriteLine(RankTeams(votes));
        }
        static string RankTeams(string[] votes)
        {
            var rank = new int[26][];
            for (int i = 0; i < rank.Length; i++)
            {
                rank[i] = new int[27];
                rank[i][^1] = i + 1;
            }
            foreach (var vote in votes)
            {
                for (int i = 0; i < vote.Length; i++)
                    rank[vote[i] - 'A'][i]++;
            }
            foreach (var team in rank)
            {
                if (team.Count(x => x == 0) == 26)
                    team[26] = -1;
            }
            Array.Sort(rank, (a, b) =>
            {
                for (int i = 0; i < 26; i++)
                {
                    if (a[i] != b[i])
                        return b[i] - a[i];
                }
                return a[26] - b[26];
            });
            var res = "";
            foreach (var team in rank)
            {
                if (team[26] != -1)
                    res += (char) (team[26] - 1 + 'A');
            }
            return res;
        }
    }
}
