using System;

namespace ReachANumber
{
	class Program
	{
		static void Main(string[] args)
		{
			int target = -1000000000;
			Console.WriteLine(ReachNumber(target));
		}

		public static int ReachNumber(int target)
		{
			target = Math.Abs(target);
			int step = (int) ((Math.Sqrt(1 + 8 * (double) target) - 1) / 2);
			target -= (1 + step) * step / 2;
			if (target == 0) return step;
			target -= ++step;
			return target % 2 == 0 ? step : step + 1 + step % 2;
		}
	}
}
