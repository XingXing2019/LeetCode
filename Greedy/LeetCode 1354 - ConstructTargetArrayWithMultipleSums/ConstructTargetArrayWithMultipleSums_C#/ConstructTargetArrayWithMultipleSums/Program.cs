using System;

namespace ConstructTargetArrayWithMultipleSums
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] target = {3, 5, 9};
			Console.WriteLine(IsPossible(target));
		}
		public static bool IsPossible(int[] target)
		{
			Array.Sort(target);
			var prefix = new int[target.Length];
			for (int i = 0; i < prefix.Length; i++)
				prefix[i] = i == 0 ? target[0] : prefix[i - 1] + target[i];
			for (int i = target.Length - 1; i >= 0; i--)
			{
				int prefixSum = i == 0 ? 0 : prefix[i - 1];
				if (target[i] - prefixSum - (target.Length - i - 1) != 1)
					return false;
			}
			return true;
		}
	}
}
