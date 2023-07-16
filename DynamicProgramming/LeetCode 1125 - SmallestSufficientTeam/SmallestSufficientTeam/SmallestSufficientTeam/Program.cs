using System;
using System.Collections.Generic;

namespace SmallestSufficientTeam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] req_skills = { "java", "nodejs", "reactjs" };
            var people = new List<IList<string>>
            {
                new List<string> { "java" },
                new List<string> { "nodejs" },
                new List<string> { "nodejs", "reactjs" },
            };
            Console.WriteLine(SmallestSufficientTeam(req_skills, people));
        }

        public static int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
        {
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < req_skills.Length; i++)
                dict[req_skills[i]] = 1 << i;
            var skills = new int[people.Count];
            for (var i = 0; i < people.Count; i++)
            {
                foreach (var skill in people[i])
                {
                    skills[i] |= dict[skill];
                }
            }
            var dp = new Dictionary<int, List<int>>();
            dp[0] = new List<int>();
            for (var i = 0; i < people.Count; i++)
            {
                var temp = new Dictionary<int, List<int>>(dp);
                foreach (var skill in dp.Keys)
                {
                    var k = skill | skills[i];
                    if (!temp.ContainsKey(k) || dp[skill].Count + 1 < temp[k].Count)
                    {
                        temp[k] = new List<int>(dp[skill]) { i };
                    }
                }
                dp = temp;
            }
            return dp[(1 << req_skills.Length) - 1].ToArray();
        }
    }
}
