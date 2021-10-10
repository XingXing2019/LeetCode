using System;
using System.Collections.Generic;

namespace StockPriceFluctuation
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}

	public class StockPrice
	{
		private int maxTime;
		private Dictionary<int, int> timePrice;
		private List<int> prices;
		
		public StockPrice()
		{
			timePrice = new Dictionary<int, int>();
			prices = new List<int>();
		}

		public void Update(int timestamp, int price)
		{
			if (timePrice.ContainsKey(timestamp))
				prices.Remove(timePrice[timestamp]);
			var index = prices.BinarySearch(price);
			if (index < 0) index = ~index;
			prices.Insert(index, price);
			maxTime = Math.Max(maxTime, timestamp);
			timePrice[timestamp] = price;
		}

		public int Current()
		{
			return timePrice[maxTime];
		}

		public int Maximum()
		{
			return prices[^1];
		}

		public int Minimum()
		{
			return prices[0];
		}
	}
}
