using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterRestaurants
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
		{
			return restaurants.Where(x => x[2] >= veganFriendly && x[3] <= maxPrice && x[4] <= maxDistance)
				.OrderByDescending(x => x[1]).ThenByDescending(x => x[0]).Select(x => x[0]).ToList();
		}
	}
}
