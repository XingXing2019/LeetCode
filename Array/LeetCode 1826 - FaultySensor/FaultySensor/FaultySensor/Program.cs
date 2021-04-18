using System;

namespace FaultySensor
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int BadSensor(int[] sensor1, int[] sensor2)
		{
			int count1 = CountDiff(sensor1, sensor2);
			int count2 = CountDiff(sensor2, sensor1);
			if (count1 == 0 && count2 == 0 || count1 == 1 && count2 == 1)
				return -1;
			return count1 > 1 ? 1 : 2;
		}

		public int CountDiff(int[] sensor1, int[] sensor2)
		{
			int p1 = 0, p2 = 0, count = 0;
			while (p1 < sensor1.Length)
			{
				if (sensor1[p1] != sensor2[p2])
					count++;
				else
					p2++;
				p1++;
			}
			return count;
		}
	}
}
