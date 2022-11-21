using System;
using System.Collections.Generic;

namespace NearestExitFromEntranceInMaze
{
	class Program
	{
		static void Main(string[] args)
		{
			char[][] maze =
			{
				new[] {'+', '+', '.', '+'},
				new[] {'.', '.', '.', '+'},
				new[] {'+', '+', '+', '.'},
			};
			int[] entrance = {1, 2};
			Console.WriteLine(NearestExit(maze, entrance));
		}
		public static int NearestExit(char[][] maze, int[] entrance)
		{
			int[] dir = {1, 0, -1, 0, 1};
			var visited = new bool[maze.Length][];
			for (int i = 0; i < visited.Length; i++)
				visited[i] = new bool[maze[0].Length];
			var queue = new Queue<int[]>();
			queue.Enqueue(new []{entrance[0], entrance[1], 0});
			visited[entrance[0]][entrance[1]] = true;
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				if ((cur[0] != entrance[0] || cur[1] != entrance[1]) && (cur[0] == 0 || cur[0] == maze.Length - 1 || cur[1] == 0 || cur[1] == maze[0].Length - 1))
					return cur[2];
				for (int i = 0; i < 4; i++)
				{
					int newX = cur[0] + dir[i];
					int newY = cur[1] + dir[i + 1];
					if(newX < 0 || newX >= maze.Length || newY < 0 || newY >= maze[0].Length || visited[newX][newY])
						continue;
					if (maze[newX][newY] == '.')
					{
						visited[newX][newY] = true;
						queue.Enqueue(new []{newX, newY, cur[2] + 1});
					}
				}
			}
			return -1;
		}
	}
}
