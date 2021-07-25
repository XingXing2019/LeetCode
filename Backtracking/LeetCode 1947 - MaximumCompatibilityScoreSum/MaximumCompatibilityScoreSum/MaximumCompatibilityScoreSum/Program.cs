using System;
using System.Collections.Generic;

namespace MaximumCompatibilityScoreSum
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		private int res;
		public int MaxCompatibilitySum(int[][] students, int[][] mentors)
		{
			res = 0;
			DFS(students, 0, mentors, new HashSet<int>(), 0);
			return res;
		}

		public void DFS(int[][] students, int p1, int[][] mentors, HashSet<int> record, int score)
		{
			if (record.Count == mentors.Length)
			{
				res = Math.Max(score, res);
				return;
			}
			for (int i = p1; i < students.Length; i++)
			{
				for (int j = 0; j < mentors.Length; j++)
				{
					if (record.Contains(j)) continue;
					record.Add(j);
					int temp = CalcMark(students[i], mentors[j]);
					DFS(students, i + 1, mentors, record, score + temp);
					record.Remove(j);
				}	
			}
		}

		public int CalcMark(int[] student, int[] mentor)
		{
			int res = 0;
			for (int i = 0; i < student.Length; i++)
				res += student[i] == mentor[i] ? 1 : 0;
			return res;
		}
	}
}
