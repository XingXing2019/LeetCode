using System;
using System.Collections.Generic;

namespace FrogJump
{
	class Program
	{
		static void Main(string[] args)
		{
			
		}

		private HashSet<int> stonePos;
		private int target;
		private Dictionary<int, HashSet<int>> failedPos;
		private int[] dir;
		public bool CanCross(int[] stones)
		{
			stonePos = new HashSet<int>(stones);
			target = stones[^1];
			failedPos = new Dictionary<int, HashSet<int>>();
			dir = new[] {-1, 1, 0};
			return DFS(0, 0);
		}

		public bool DFS(int pos, int jump)
		{
			if (pos == target) return true;
			if (!stonePos.Contains(pos)) return false;
			if (failedPos.ContainsKey(pos) && failedPos[pos].Contains(jump)) return false;
			for (int i = 0; i < dir.Length; i++)
			{
				int nextJump = jump + dir[i];
				if(nextJump < 1) continue;
				if (DFS(pos + nextJump, nextJump))
					return true;
			}
			if (!failedPos.ContainsKey(pos))
				failedPos[pos] = new HashSet<int>();
			failedPos[pos].Add(jump);
			return false;
		}
	}
}
