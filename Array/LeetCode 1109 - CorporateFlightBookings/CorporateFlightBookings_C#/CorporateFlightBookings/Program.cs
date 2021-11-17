using System;

namespace CorporateFlightBookings
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int[] CorpFlightBookings(int[][] bookings, int n)
		{
			var record = new int[n + 1];
			foreach (var booking in bookings)
			{
				record[booking[0] - 1] += booking[2];
				record[booking[1]] -= booking[2];
			}
			var res = new int[n];
			int sum = 0;
			for (int i = 0; i < res.Length; i++)
			{
				sum += record[i];
				res[i] = sum;
			}
			return res;
		}
	}
}
