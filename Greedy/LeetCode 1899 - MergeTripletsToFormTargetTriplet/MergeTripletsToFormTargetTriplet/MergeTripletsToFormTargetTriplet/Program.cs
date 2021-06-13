using System;
using System.Linq;

namespace MergeTripletsToFormTargetTriplet
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] triplets = new int[][]
			{
				new int[] {3, 5, 1},
				new int[] {3, 10, 7}
			};
			int[] target = {3, 5, 7};
			Console.WriteLine(MergeTriplets(triplets, target));
		}

		public static bool MergeTriplets(int[][] triplets, int[] target)
		{
			var candidates = triplets.Where(x => IsCandidate(x, target)).ToArray();
			for (int i = 0; i < target.Length; i++)
			{
				var hasTarget = false;
				foreach (var candidate in candidates)
				{
					if (candidate[i] == target[i])
						hasTarget = true;
				}
				if (!hasTarget) return false;
			}
			return true;
		}

		private static bool IsCandidate(int[] triplet, int[] target)
		{
			var hasEqual = false;
			for (int i = 0; i < triplet.Length; i++)
			{
				if (triplet[i] > target[i])
					return false;
				if (triplet[i] == target[i])
					hasEqual = true;
			}
			return hasEqual;
		}
	}
}
