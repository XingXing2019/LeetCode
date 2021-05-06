using System;

namespace RecoverATreeFromPreorderTraversal
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			//		 0123456789
			var S = "1-2--3---4-5--6---7";
			RecoverFromPreorder(S);
		}

		public static TreeNode RecoverFromPreorder(string S, int len = 1)
		{
			if (S.Length == 0) return null;
			int num = 0, index = 0;
			while (index < S.Length && S[index] != '-')
			{
				num *= 10;
				num += S[index++] - '0';
			}
			var root = new TreeNode(num);
			int count = 0, li = -1, hi = -1;
			for (int i = index; i < S.Length; i++)
			{
				if (S[i] == '-')
					count++;
				else
				{
					if (count == len && li == -1)
						li = i;
					else if (count == len && hi == -1)
						hi = i;
					if (li != -1 && hi != -1) break;
					count = 0;
				}
			}
			var left = li == -1 ? "" : hi == -1 ? S.Substring(li) : S.Substring(li, hi - li - len);
			var right = hi == -1 ? "" : S.Substring(hi);
			root.left = RecoverFromPreorder(left, len + 1);
			root.right = RecoverFromPreorder(right, len + 1);
			return root;
		}
	}
}
