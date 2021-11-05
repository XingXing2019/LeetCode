using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfSpacesCleaningRobotCleaned
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] room =
			{
				new[] {0, 1, 0},
				new[] {1, 0, 0},
				new[] {0, 0, 0},
			};

			Console.WriteLine(NumberOfCleanRooms(room));
		}

		public static int NumberOfCleanRooms(int[][] room)
		{
			var record = new HashSet<int>[room.Length][];
			for (int i = 0; i < record.Length; i++)
			{
				record[i] = new HashSet<int>[room[0].Length];
				for (int j = 0; j < record[i].Length; j++)
					record[i][j] = new HashSet<int>();
			}
			int[] dir = {0, 1, 0, -1, 0};
			int x = 0, y = 0, index = 0, res = 0;
			while (record[x][y].Add(index % 4))
			{
				int newX = x + dir[index % 4], newY = y + dir[index % 4 + 1], times = 0;
				while (newX < 0 || newX >= room.Length || newY < 0 || newY >= room[0].Length || room[newX][newY] == 1)
				{
					index++;
					times++;
					if (times > 3) break;
					newX = x + dir[index % 4];
					newY = y + dir[index % 4 + 1];
				}
				if (times > 3) break;
				x = newX;
				y = newY;
			}
			res += record.Sum(t => t.Count(y => y.Count != 0));
			return res;
		}
	}
}
