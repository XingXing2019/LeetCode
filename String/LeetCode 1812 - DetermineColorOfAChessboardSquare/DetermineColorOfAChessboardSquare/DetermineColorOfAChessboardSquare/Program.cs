using System;

namespace DetermineColorOfAChessboardSquare
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool SquareIsWhite(string coordinates)
		{
			return (coordinates[0] - 'a') % 2 != 0 && (coordinates[1] - '0') % 2 != 0 || (coordinates[0] - 'a') % 2 == 0 && (coordinates[1] - '0') % 2 == 0;
		}
	}
}
