using System;
using System.Collections.Generic;
using System.Linq;

namespace RewardTopKStudents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
        {
            HashSet<string> pos = new HashSet<string>(positive_feedback), neg = new HashSet<string>(negative_feedback);
            var scores = new Dictionary<int, int>();
            for (int i = 0; i < report.Length; i++)
            {
                var words = report[i].Split(' ');
                var score = 0;
                foreach (var word in words)
                {
                    if (pos.Contains(word))
                        score += 3;
                    else if (neg.Contains(word))
                        score -= 1;
                }
                scores[student_id[i]] = score;
            }
            return scores.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).Take(k).ToList();
        }
    }
}
