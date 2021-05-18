using System;
using System.Collections.Generic;

namespace MaximumNumberOfAcceptedInvitations
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = new[]
			{
				new[] {1, 0, 1, 0},
				new[] {1, 0, 0, 0},
				new[] {0, 0, 1, 0},
				new[] {1, 1, 1, 0},
			};
			Console.WriteLine(MaximumInvitations(grid));
		}
		public static int MaximumInvitations(int[][] grid)
		{
			var res = 0;
			var girls = new int[grid[0].Length];
			Array.Fill(girls, -1);
			for (int i = 0; i < grid.Length; i++)
			{
				if (BipartiteMatch(grid, i, girls, new HashSet<int>()))
					res++;
			}
			return res;
		}

		public static bool BipartiteMatch(int[][] grid, int boy, int[] girls, HashSet<int> visited)
		{
			for (int i = 0; i < girls.Length; i++)
			{
				if (grid[boy][i] != 1 || !visited.Add(i)) continue;
				if (girls[i] == -1 || BipartiteMatch(grid, girls[i], girls, visited))
				{
					girls[i] = boy;
					return true;
				}
			}
			return false;
		}
	}
}
