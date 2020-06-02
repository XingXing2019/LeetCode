using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace OnlineElection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] person = {0, 1, 2, 2, 1};
            int[] times = {20, 28, 29, 54, 56};
            var t = new TopVotedCandidate(person, times);
            Console.WriteLine(t.Q(55));
        }
    }
    public class TopVotedCandidate
    {
        private readonly int[] _persons;
        private readonly int[] _times;
        private readonly Dictionary<int, int> winner;

        public TopVotedCandidate(int[] persons, int[] times)
        {
            _persons = persons;
            _times = times;
            winner = new Dictionary<int, int>();
            var votes = new Dictionary<int, int>();
            for (int i = 0; i < times.Length; i++)
            {
                if (!votes.ContainsKey(persons[i]))
                    votes[persons[i]] = 1;
                else
                    votes[persons[i]]++;
                var max = votes.Max(v => v.Value);
                for (int j = i; j >= 0; j--)
                {
                    if (votes[persons[j]] == max)
                    {
                        this.winner[times[i]] = persons[j];
                        break;
                    }
                }
            }
        }

        public int Q(int t)
        {
            int li = 0, hi = _times.Length - 1, index = -1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (t == _times[mid])
                {
                    index = mid;
                    break;
                }
                if (_times[mid] > t)
                    hi = mid;
                else
                    li = mid + 1;
            }
            var mark = index == -1 ? li : index;
            if (t < _times[mark])
                mark--;
            return winner[_times[mark]];
        }
    }
}
