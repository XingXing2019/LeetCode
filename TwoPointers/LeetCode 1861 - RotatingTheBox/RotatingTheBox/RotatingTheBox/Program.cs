using System;

namespace RotatingTheBox
{
	class Program
	{
		static void Main(string[] args)
		{
			char[][] box = new char[][]
			{
				new char[] {'#', '.', '*', '.'},
				new char[] {'#', '#', '*', '.'},
			};
			Console.WriteLine(RotateTheBox(box));
		}
		public static char[][] RotateTheBox(char[][] box)
		{
			var temp = new char[box.Length][];
			for (int r = 0; r < temp.Length; r++)
			{
				temp[r] = new char[box[0].Length];
				Array.Fill(temp[r], '.');
			}
			for (int r = 0; r < box.Length; r++)
			{
				int p1 = box[r].Length - 1, p2 = box[r].Length - 1;
				while (p1 >= 0)
				{
					if (box[r][p1] == '#')
						temp[r][p2--] = '#';
					else if (box[r][p1] == '*')
					{
						temp[r][p1] = '*';
						p2 = p1 - 1;
					}
					p1--;
				}
			}
			var res = new char[box[0].Length][];
			for (int r = 0; r < box.Length; r++)
			{
				for (int c = 0; c < box[0].Length; c++)
				{
					if (res[c] == null) res[c] = new char[box.Length];
					res[c][r] = temp[^(r + 1)][c];
				}
			}
			return res;
		}
	}
}
