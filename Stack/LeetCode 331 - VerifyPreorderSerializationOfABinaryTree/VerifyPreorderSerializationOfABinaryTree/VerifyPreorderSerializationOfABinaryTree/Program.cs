using System;

namespace VerifyPreorderSerializationOfABinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool IsValidSerialization(string preorder)
		{
			var nodes = preorder.Split(",");
			int slot = 1;
			for (int i = 0; i < nodes.Length; i++)
			{
				slot += nodes[i] == "#" ? -1 : 1;
				if (slot == 0 && i != nodes.Length - 1)
					return false;
			}
			return slot == 0;
		}
	}
}
