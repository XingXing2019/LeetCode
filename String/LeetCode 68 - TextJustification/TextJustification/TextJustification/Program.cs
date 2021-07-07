using System;
using System.Collections.Generic;
using System.Text;

namespace TextJustification
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] words = { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" };
			int maxWidth = 20;
			Console.WriteLine(FullJustify(words, maxWidth));
		}
		public static IList<string> FullJustify(string[] words, int maxWidth)
		{
			int len = 0, index = 0, count = 0;
			var res = new List<string>();
			while (index < words.Length)
			{
				if (len + words[index].Length <= maxWidth - count)
				{
					len += words[index].Length;
					count++;
					index++;
				}
				else
				{
					if (count == 1)
						res.Add($"{words[index - 1]}{new string(' ', maxWidth - words[index - 1].Length)}");
					else
					{
						int space = maxWidth - len, gap = space / (count - 1), left = space - gap * (count - 1);
						var str = new StringBuilder();
						for (int i = index - count; i < index; i++)
						{
							str.Append(words[i]);
							if (i >= index - 1) continue;
							str.Append(left > 0 ? new string(' ', gap + 1) : new string(' ', gap));
							left--;
						}
						res.Add(str.ToString());
					}
					len = 0;
					count = 0;
				}
			}
			len = 0;
			var last = new StringBuilder();
			for (int i = index - count; i < index; i++)
			{
				if (i != index - 1)
				{
					last.Append($"{words[i]} ");
					len += words[i].Length + 1;
				}
				else
					last.Append($"{words[i]}{new string(' ', maxWidth - words[i].Length - len)}");
			}
			res.Add(last.ToString());
			return res;
		}
	}
}
