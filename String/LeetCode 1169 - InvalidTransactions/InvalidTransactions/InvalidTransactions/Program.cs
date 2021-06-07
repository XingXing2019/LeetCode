using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace InvalidTransactions
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] transactions = { "alice,20,800,mtv", "alice,50,100,mtv", "alice,51,100,frankfurt" };
			Console.WriteLine(InvalidTransactions(transactions));
		}

		class Transaction
		{
			public int _id;
			public string _name;
			public int _time;
			public int _amount;
			public string _city;
			public Transaction(int id, string name, int time, int amount, string city)
			{
				_id = id;
				_name = name;
				_time = time;
				_amount = amount;
				_city = city;
			}
		}

		public static IList<string> InvalidTransactions(string[] transactions)
		{
			var dict = new Dictionary<string, List<Transaction>>();
			var res = new HashSet<int>();
			for (int i = 0; i < transactions.Length; i++)
			{
				var parts = transactions[i].Split(",");
				if (!dict.ContainsKey(parts[0]))
					dict[parts[0]] = new List<Transaction>();
				dict[parts[0]].Add(new Transaction(i, parts[0], int.Parse(parts[1]), int.Parse(parts[2]), parts[3]));
			}
			foreach (var person in dict)
			{
				person.Value.Sort((a, b) => a._time - b._time);
				for (int i = 0; i < person.Value.Count; i++)
				{
					var transaction = person.Value[i];
					for (int j = i - 1; j >= 0; j--)
					{
						if (transaction._time - person.Value[j]._time <= 60 && transaction._city != person.Value[j]._city)
						{
							res.Add(transaction._id);
							res.Add(person.Value[j]._id);
						}
					}
					if (transaction._amount > 1000)
						res.Add(transaction._id);

				}
			}
			return res.Select(x => transactions[x]).ToList();
		}
	}
}
