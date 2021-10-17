using System;

namespace SimpleBankSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}

	public class Bank
	{
		private long[] _balance;
		public Bank(long[] balance)
		{
			_balance = balance;
		}

		public bool Transfer(int account1, int account2, long money)
		{
			if (account1 > _balance.Length || account2 > _balance.Length || _balance[account1 - 1] < money)
				return false;
			_balance[account1 - 1] -= money;
			_balance[account2 - 1] += money;
			return true;
		}

		public bool Deposit(int account, long money)
		{
			if (account > _balance.Length)
				return false;
			_balance[account - 1] += money;
			return true;
		}

		public bool Withdraw(int account, long money)
		{
			if (account > _balance.Length || _balance[account - 1] < money)
				return false;
			_balance[account - 1] -= money;
			return true;
		}
	}
}
