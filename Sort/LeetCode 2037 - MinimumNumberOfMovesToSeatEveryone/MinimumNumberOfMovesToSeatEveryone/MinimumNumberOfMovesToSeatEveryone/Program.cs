using System;

namespace MinimumNumberOfMovesToSeatEveryone
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int MinMovesToSeat(int[] seats, int[] students)
		{
			Array.Sort(seats);
			Array.Sort(students);
			var res = 0;
			for (int i = 0; i < seats.Length; i++)
				res += Math.Abs(seats[i] - students[i]);
			return res;
		}
	}
}
