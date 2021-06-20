using System;

namespace TheNumberOfFullRoundsYouHavePlayed
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int NumberOfRounds(string startTime, string finishTime)
		{
			var startHr = int.Parse(startTime.Substring(0, 2));
			var finishHr = int.Parse(finishTime.Substring(0, 2));
			var startMin = int.Parse(startTime.Substring(3));
			var finishMin = int.Parse(finishTime.Substring(3));
			if (startHr > finishHr || startHr == finishHr && startMin > finishMin) 
				finishHr += 24;
			return (finishHr - startHr - 1) * 4 + (60 - startMin) / 15 + finishMin / 15;
		}
	}
}
