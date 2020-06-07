using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LargestTimeForGivenDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {2, 0, 6, 6};
            Console.WriteLine(LargestTimeFromDigits(A));
        }
        static string LargestTimeFromDigits(int[] A)
        {
            var record = new HashSet<string>();
            var time = new StringBuilder();
            var visit = new bool[4];
            DFS(A, record, time, visit);
            var times = record.OrderBy(x => x).ToArray();
            var temp = times.LastOrDefault(IsValidTime);
            if (temp == null) return "";
            var res = new StringBuilder(temp);
            res.Insert(2, ":");
            return res.ToString();
        }

        static void DFS(int[] A, HashSet<string> record, StringBuilder time, bool[] visit)
        {
            if (time.Length == 4)
                record.Add(time.ToString());
            for (int i = 0; i < A.Length; i++)
            {
                if(visit[i]) continue;
                visit[i] = true;
                time.Append(A[i]);
                DFS(A, record, time, visit);
                time.Remove(time.Length - 1, 1);
                visit[i] = false;
            }
        }

        static bool IsValidTime(string time)
        {
            return int.Parse(time) < 2400 && int.Parse(time.Substring(0, 2)) < 24 && int.Parse(time.Substring(2)) < 60;
        }
    }
}
