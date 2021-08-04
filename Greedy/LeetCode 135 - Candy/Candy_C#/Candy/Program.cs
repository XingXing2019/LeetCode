using System;
using System.Linq;

namespace Candy
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] ratings = { 1, 0, 2, 3 };
			Console.WriteLine(Candy(ratings));
		}
		public static int Candy(int[] ratings)
		{
			var candies = new int[ratings.Length];
			Array.Fill(candies, 1);
			for (int i = 1; i < ratings.Length; i++)
			{
				if (ratings[i] > ratings[i - 1])
					candies[i] = Math.Max(candies[i], candies[i - 1] + 1);
			}
			for (int i = ratings.Length - 2; i >= 0; i--)
			{
				if (ratings[i] > ratings[i + 1])
					candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
			}
			return candies.Sum();
		}
	}
}
