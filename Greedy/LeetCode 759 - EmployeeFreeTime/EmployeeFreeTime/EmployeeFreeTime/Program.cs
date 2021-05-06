using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeFreeTime
{
	public class Interval
	{
		public int start;
		public int end;

		public Interval() { }
		public Interval(int _start, int _end)
		{
			start = _start;
			end = _end;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
		{
			List<int[]> record = new List<int[]>();
			foreach (var s in schedule)
			{
				foreach (var interval in s)
				{
					record.Add(new[] { interval.start, 1 });
					record.Add(new[] { interval.end, -1 });
				}
			}
			record = record.OrderBy(x => x[0]).ToList();
			int time = 0, start = int.MinValue;
			var res = new List<Interval>();
			foreach (var r in record)
			{
				time += r[1];
				if (time == 0)
					start = r[0];
				else if (time == 1)
				{
					if (start != int.MinValue && start != r[0])
						res.Add(new Interval(start, r[0]));
					start = int.MinValue;
				}
			}
			return res;
		}
	}
}
