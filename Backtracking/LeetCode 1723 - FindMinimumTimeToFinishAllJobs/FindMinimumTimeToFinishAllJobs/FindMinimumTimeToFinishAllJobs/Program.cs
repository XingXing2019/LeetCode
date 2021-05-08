using System;
using System.Linq;

namespace FindMinimumTimeToFinishAllJobs
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] jobs = { 11, 2, 20, 18, 2, 1, 7, 11, 7, 10 };
			int k = 9;
			Console.WriteLine(MinimumTimeRequired(jobs, k));
		}

		public static int MinimumTimeRequired(int[] jobs, int k)
		{
			var workers = new int[k];
			Array.Sort(jobs);
			int res = jobs.Sum();
			DFS(jobs, 0, workers, ref res);
			return res;
		}

		public static void DFS(int[] jobs, int index, int[] workers, ref int res)
		{
			if (index == jobs.Length)
			{
				res = Math.Min(res, workers.Max());
				return;
			}
			for (int i = 0; i < workers.Length; i++)
			{
				if (workers[i] + jobs[index] >= res) continue;
				workers[i] += jobs[index];
				DFS(jobs, index + 1, workers, ref res);
				workers[i] -= jobs[index];
				if (workers[i] == 0) break;
			}
		}
	}
}
